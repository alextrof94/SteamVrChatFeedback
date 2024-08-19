using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Web;
using TwitchLib.Api;
using TwitchLib.Api.Interfaces;
using TwitchLib.Client.Models;
using TwitchLib.PubSub;
using Valve.VR;
using static System.Formats.Asn1.AsnWriter;

namespace SteamVrChatFeedback
{
    public partial class Form1 : Form
    {
        readonly static string AppVersion = "1.1.3";
        readonly static string AppName = "SteamVrChatFeedback";
        readonly string PathToExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
        bool AppLoaded = false;
        string[] args;

        List<string> WhiteList = new List<string>();
        List<string> IgnoreList = new List<string>();
        List<HapticAnimation> HapticAnimations = new List<HapticAnimation>();

        // Twitch
        readonly static string TlAddressOAuth = "https://turnlive.ru/oauthreceiver/returnurl.php";
        readonly static string TwAddress = "https://id.twitch.tv/";
        readonly static string TwAddressToken = "oauth2/authorize";
        readonly static string TwScope = "chat:read";
        readonly static string TwServiceString = "service=twitch";
        readonly static string TwRedirectUrl = TlAddressOAuth + "?protocol=" + Program.uriSchemeConfiguration.GetValueOrDefault("UriScheme") + "&" + TwServiceString;
        string TwCodeForRenewAuth = "";
        TwitchAPI TwitchApi = new TwitchAPI();
        bool TwitchSubConnected = false;
        TwitchPubSub TwitchSub = new TwitchPubSub();

        public TwitchLib.Client.TwitchClient? client;

        // OpenVR
        bool HapticPlaying = false;
        CVRSystem VrSystem;
        bool VrStarted = false;
        uint LeftHandId;
        uint RightHandId;
        ushort hapticForce = 50;
        HapticAnimation PlayingHapticAnimation;

        public Form1(string[] argsIn)
        {
            args = argsIn;
            InitializeComponent();
        }

        public void GotNewArguments(List<string> arguments)
        {
            arguments.RemoveAll(x => x == "\r\n" || string.IsNullOrWhiteSpace(x));

            if (arguments.Any(x => x.Contains(Program.uriSchemeConfiguration.GetValueOrDefault("UriScheme") + "://oauth=true") && x.Contains(TwServiceString)))
            {
                // oauth twitch
                string code = arguments.FirstOrDefault(x => x.Contains(Program.uriSchemeConfiguration.GetValueOrDefault("UriScheme") + "://oauth=true"));
                code = code.Substring(code.IndexOf("code=") + "code=".Length);
                if (code.Contains("&"))
                    code = code.Substring(0, code.IndexOf("&"));
                if (code.Contains("/"))
                    code = code.Substring(0, code.IndexOf("/"));
                TwCodeForRenewAuth = code;
                StartTwitchReading();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CbController.Items.Clear();
            CbController.Items.AddRange(Translations.GetString("Controllers").Split('|'));
            LoadAllData();
            TryToInitVr();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.TwAccessToken))
                StartTwitchReading();
        }

        private void LoadAllData()
        {
            if (File.Exists(PathToExe + "WhiteList.json"))
                WhiteList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(PathToExe + "WhiteList.json"));
            if (File.Exists(PathToExe + "IgnoreList.json"))
                IgnoreList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(PathToExe + "IgnoreList.json"));

            if (File.Exists(PathToExe + "HapticAnimations.json"))
                HapticAnimations = JsonConvert.DeserializeObject<List<HapticAnimation>>(File.ReadAllText(PathToExe + "HapticAnimations.json"));
            CbHapticAnimations.Items.AddRange(HapticAnimations.ToArray());
            if (!string.IsNullOrEmpty(Properties.Settings.Default.HapticAnimationName))
                CbHapticAnimations.SelectedItem = CbHapticAnimations.Items.Cast<HapticAnimation>().First(x => x.Name == Properties.Settings.Default.HapticAnimationName);
            if (CbHapticAnimations.SelectedIndex < 0)
                CbHapticAnimations.SelectedIndex = 0;

            CbController.SelectedIndex = Properties.Settings.Default.Controller;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.TwChannel))
                TbTwChannelName.Text = Properties.Settings.Default.TwChannel;

            if (Properties.Settings.Default.HapticForce < 256)
                TbHapticForce.Value = Properties.Settings.Default.HapticForce;
            if (TbHapticForce.Value == 255)
                hapticForce = 65535;
            else
                hapticForce = (ushort)(Math.Pow(TbHapticForce.Value, 2) + 1);
            TtHint.SetToolTip(TbHapticForce, hapticForce.ToString());

            var flags = Properties.Settings.Default.Flags;
            var checkBoxes = Extensions.FindAllChildrenByType<CheckBox>(this);
            for (int i = 0; i < flags.Length; i++)
            {
                var checkBox = checkBoxes.FirstOrDefault(x => x.Tag.Equals(i.ToString()));
                if (checkBox != null)
                    checkBox.Checked = (flags[i] == '1');
            }
            if (!flags.Contains("1"))
            {
                CbMsgAll.Checked = true;
                SaveCbs(CbMsgAll, int.Parse(CbMsgAll.Tag.ToString()));
            }

            AppLoaded = true;

            if (CbHideOnStart.Checked)
            {
                WindowState = FormWindowState.Minimized;
            }

            CbsSetEnable();
        }

        private void BuDonate_Click(object sender, EventArgs e)
        {
            OpenBrowser("https://www.donationalerts.com/r/goodvrgames");
        }

        private void OpenBrowser(string url)
        {
            string args = $"/c start \"\" \"{url}\"";
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = args,
                UseShellExecute = true
            });
        }

        private void LlOpenGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenBrowser("https://github.com/alextrof94/SteamVrChatFeedback");
        }

        private string DoGetRequest(string url)
        {
            string res = "";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    res = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, AppName);
            }
            return res;
        }

        private void BuOpenWhiteList_Click(object sender, EventArgs e)
        {
            FormEditList form = new FormEditList();
            form.Text = AppName + " - White List";
            form.Lines = WhiteList;
            form.ShowDialog();
            File.WriteAllText(PathToExe + "WhiteList.json", JsonConvert.SerializeObject(WhiteList));
        }

        private void BuOpenIgnoreList_Click(object sender, EventArgs e)
        {
            FormEditList form = new FormEditList();
            form.Text = AppName + " - Ignore List";
            form.Lines = IgnoreList;
            form.ShowDialog();
            File.WriteAllText(PathToExe + "IgnoreList.json", JsonConvert.SerializeObject(IgnoreList));

        }

        private void CbsSetEnable()
        {
            var checkBoxes = Extensions.FindAllChildrenByType<CheckBox>(this);

            for (int i = 1; i < 20; i++)
            {
                var checkingCb = checkBoxes.FirstOrDefault(x => x.Tag.Equals(i.ToString()));
                if (checkingCb != null)
                    checkingCb.Enabled = !CbMsgAll.Checked;
            }

            BuOpenWhiteList.Enabled = (CbMsgWhiteList.Checked && !CbMsgAll.Checked);
        }

        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (!AppLoaded) return;

            var cb = (CheckBox)sender;
            var cbIndex = int.Parse((string)cb.Tag);

            if (cb.Name == "CbStartWithSteamVR")
            {
                if (!VrStarted)
                {
                    if (CbStartWithSteamVR.Checked)
                        CbStartWithSteamVR.Checked = false;
                    return;
                }
                TryToSetAutorun();
            }

            SaveCbs(cb, cbIndex);

            CbsSetEnable();
        }

        private void SaveCbs(CheckBox cb, int cbIndex)
        {
            string flags = Properties.Settings.Default.Flags;
            while (flags.Length <= 30)
                flags += "0";

            StringBuilder flagsSb = new StringBuilder(flags);
            flagsSb[cbIndex] = (cb.Checked) ? '1' : '0';

            Properties.Settings.Default.Flags = flagsSb.ToString();
            Properties.Settings.Default.Save();
        }

        private void NiMain_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        private void TryToSetAutorun()
        {
            string appKey = Program.uriSchemeConfiguration.GetValueOrDefault("AppName");
            if (CbStartWithSteamVR.Checked)
            {
                if (!OpenVR.Applications.IsApplicationInstalled(appKey))
                {
                    var manifestError = OpenVR.Applications.AddApplicationManifest(Path.GetFullPath(PathToExe + "app.vrmanifest"), false);
                    if (manifestError == EVRApplicationError.None)
                    {
                        OpenVR.Applications.SetApplicationAutoLaunch(appKey, true);
                    }
                }
            }
            else
            {
                if (OpenVR.Applications.IsApplicationInstalled(appKey))
                {
                    OpenVR.Applications.SetApplicationAutoLaunch(appKey, false);
                    Thread.Sleep(100);
                    OpenVR.Applications.RemoveApplicationManifest(Path.GetFullPath(PathToExe + "app.vrmanifest"));
                }
            }
        }

        private void CbController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!AppLoaded) return;
            Properties.Settings.Default.Controller = CbController.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void CbHapticAnimationNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!AppLoaded) return;
            string selected = CbHapticAnimations.SelectedItem.ToString();
            Properties.Settings.Default.HapticAnimationName = selected;
            Properties.Settings.Default.Save();
        }

        private void BuTwConnect_Click(object sender, EventArgs e)
        {
            if (TwitchSubConnected)
            {
                StopTwitchReadings();
                ClearTwitchAuth();
            }
            else
                StartTwitchReading();
        }

        private void BuTestHaptic_Click(object sender, EventArgs e)
        {
            StartHaptickFeedback((HapticAnimation)CbHapticAnimations.SelectedItem);
        }

        private void TiTwCheckExpired_Tick(object sender, EventArgs e)
        {
            TiTwCheckExpired.Enabled = false;
            if (TwitchSubConnected)
            {
                if (Properties.Settings.Default.TwExpiresIn <= DateTime.UtcNow)
                {
                    StopTwitchReadings();
                    StartTwitchReading();
                }
            }
        }

        private void TimerCheckForVR_Tick(object sender, EventArgs e)
        {
            TryToInitVr();
        }

        private void TimerCheckForControllers_Tick(object sender, EventArgs e)
        {
            if (LeftHandId == 0 || LeftHandId > 255)
                LeftHandId = VrSystem.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.LeftHand);

            if (RightHandId == 0 || RightHandId > 255)
                RightHandId = VrSystem.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.RightHand);

            BuVrL.BackColor = (LeftHandId == 0 || LeftHandId > 255) ? Color.LightPink : Color.LightGreen;
            BuVrR.BackColor = (RightHandId == 0 || RightHandId > 255) ? Color.LightPink : Color.LightGreen;
        }


        private void TbHapticForce_Scroll(object sender, EventArgs e)
        {
            if (!AppLoaded) return;

            if (TbHapticForce.Value == 255)
                hapticForce = 65535;
            else
                hapticForce = (ushort)(Math.Pow(TbHapticForce.Value, 2) + 1);
            TtHint.SetToolTip(TbHapticForce, hapticForce.ToString());

            Properties.Settings.Default.HapticForce = TbHapticForce.Value;
            Properties.Settings.Default.Save();
        }




        private void StopTwitchReadings()
        {
            if (TwitchSubConnected)
            {
                TwitchSub.Disconnect();

                BuTwConnect.Text = $"{Translations.GetString("Connect")}";
                BuTwConnect.Enabled = true;
                BuTwConnect.BackColor = Color.LightPink;
            }
        }

        private void ClearTwitchAuth()
        {
            Properties.Settings.Default.TwAccessToken = null;
            Properties.Settings.Default.TwRefreshToken = null;
            Properties.Settings.Default.Save();
        }

        private async void StartTwitchReading()
        {
            if (string.IsNullOrEmpty(TbTwChannelName.Text))
                return;

            string stage = "0";
            try
            {
                this.Invoke(new Action(() =>
                {
                    BuTwConnect.Text = $"{Translations.GetString("Connection")}";
                    BuTwConnect.Enabled = false;
                    BuTwConnect.BackColor = Color.AliceBlue;
                }));

                TwitchApi.Settings.ClientId = Secrets.TwitchClientId;

                if (!string.IsNullOrEmpty(TwCodeForRenewAuth))
                {
                    var authResp = await TwitchApi.Auth.GetAccessTokenFromCodeAsync(TwCodeForRenewAuth, Secrets.TwitchSecretKey, TwRedirectUrl);
                    TwCodeForRenewAuth = "";

                    if (authResp != null)
                    {
                        Properties.Settings.Default.TwAccessToken = authResp.AccessToken;
                        Properties.Settings.Default.TwRefreshToken = authResp.RefreshToken;
                        Properties.Settings.Default.TwExpiresIn = DateTime.UtcNow.AddSeconds(authResp.ExpiresIn);
                        Properties.Settings.Default.Save();
                    }
                }

                if (string.IsNullOrEmpty(Properties.Settings.Default.TwAccessToken))
                    TwitchApi.Settings.AccessToken = Properties.Settings.Default.TwAccessToken;

                stage = "ValidateAccessTokenAsync";
                var res = await TwitchApi.Auth.ValidateAccessTokenAsync();

                if (res == null)
                {
                    string refrToken = Properties.Settings.Default.TwRefreshToken;
                    if (string.IsNullOrEmpty(refrToken))
                    {
                        var authLink = TwAddress + TwAddressToken;

                        var authParams = new Dictionary<string, string>
                        {
                            { "response_type", "code" },
                            { "client_id", HttpUtility.UrlEncode(Secrets.TwitchClientId) },
                            { "force_verify", "true" },
                            { "state", HttpUtility.UrlEncode("VrScreamerApp|" + new Random().Next().ToString()) },
                            { "scope", HttpUtility.UrlEncode(TwScope) },
                            { "redirect_uri", HttpUtility.UrlEncode(TwRedirectUrl) }
                        };

                        authLink += "?" + string.Join("&", authParams.Select(x => String.Format("{0}={1}", x.Key, x.Value)));


                        OpenBrowser(authLink);

                        this.Invoke(new Action(() =>
                        {
                            BuTwConnect.Text = $"{Translations.GetString("Connect")}";
                            BuTwConnect.Enabled = true;
                            BuTwConnect.BackColor = Color.LightPink;
                        }));

                        return;
                    }
                    else
                    {
                        var refreshRes = await TwitchApi.Auth.RefreshAuthTokenAsync(refrToken, Secrets.TwitchSecretKey);
                        if (refreshRes != null)
                        {
                            Properties.Settings.Default.TwAccessToken = refreshRes.AccessToken;
                            Properties.Settings.Default.TwRefreshToken = refreshRes.RefreshToken;
                            Properties.Settings.Default.TwExpiresIn = DateTime.UtcNow.AddSeconds(refreshRes.ExpiresIn);
                            Properties.Settings.Default.Save();
                            TwitchApi.Settings.AccessToken = refreshRes.AccessToken;
                        }
                    }
                }

                stage = "GetUsersAsync";
                var usersResponse = await TwitchApi.Helix.Users.GetUsersAsync(null, new List<string> { TbTwChannelName.Text });
                string broadcasterId = usersResponse.Users[0].Id;

                if (client != null && client.IsConnected)
                {
                    client.Disconnect();
                    client = null;
                }

                ConnectionCredentials creds = new ConnectionCredentials(Secrets.TwitchBotName, Properties.Settings.Default.TwAccessToken);
                client = new TwitchLib.Client.TwitchClient();
                client.Initialize(creds, TbTwChannelName.Text);

                client.OnMessageReceived += TwClient_OnMessageReceived;

                client.Connect();


                TwitchSub.ListenToWhispers(broadcasterId);
                TwitchSub.ListenToChannelPoints(broadcasterId);
                TwitchSub.Connect();

                TwitchSubConnected = true;

                this.Invoke(new Action(() =>
                {
                    TiTwCheckExpired.Enabled = true;
                    BuTwConnect.Text = $"{Translations.GetString("Connected")}";
                    BuTwConnect.Enabled = true;
                    BuTwConnect.BackColor = Color.LightGreen;
                }));
                Properties.Settings.Default.TwChannel = TbTwChannelName.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    BuTwConnect.Text = $"{Translations.GetString("Connect")}";
                    BuTwConnect.Enabled = true;
                    BuTwConnect.BackColor = Color.LightPink;
                    MessageBox.Show("TW " + stage + ":" + ex.Message + "\r\n" + ex.StackTrace, AppName);
                    Properties.Settings.Default.TwChannel = "";
                    Properties.Settings.Default.Save();
                }));
            }
        }

        private void TwClient_OnMessageReceived(object? sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
        {
            this.Invoke(() =>
            {
                bool needStartHaptics = false;
                var channel_name = (string)TbTwChannelName.Text;

                bool all = CbMsgAll.Checked;
                bool isCmd = false;

                if (e.ChatMessage.IsMe)
                    return;

                if (all && e.ChatMessage.Message[0] != '!')
                    needStartHaptics = true;

                if (e.ChatMessage.Message[0] == '!' && CbMsgCmds.Checked)
                {
                    needStartHaptics = true;
                    isCmd = true;
                }

                if (e.ChatMessage.Message == "!hey" && (all || CbMsgHey.Checked))
                    needStartHaptics = true;

                if (e.ChatMessage.IsBroadcaster)
                    needStartHaptics = true; // for easy test

                if (!isCmd)
                {
                    if (e.ChatMessage.IsFirstMessage && (all || CbMsgFirst.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsHighlighted && (all || CbMsgHighlighted.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsSkippingSubMode && (all || CbMsgSubmode.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsTurbo && (all || CbMsgTurbo.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsVip && (all || CbMsgVip.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsPartner && (all || CbMsgPartner.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsModerator && (all || CbMsgMod.Checked))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsSubscriber && (all || CbMsgSub.Checked))
                        needStartHaptics = true;

                    if ((all || CbMsgWhiteList.Checked) && WhiteList.Contains(e.ChatMessage.Username))
                        needStartHaptics = true;

                    if (e.ChatMessage.IsStaff)
                        needStartHaptics = true; // is stuff by twitch?
                }

                if (IgnoreList.Contains(e.ChatMessage.Username))
                    needStartHaptics = false;

                if (needStartHaptics && CbHapticAnimations.SelectedIndex > -1)
                    StartHaptickFeedback((HapticAnimation)CbHapticAnimations.SelectedItem);
            });
        }




        bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        private void TryToInitVr()
        {
            if (InitVr())
            {
                VrStarted = true;
                BuVrStatus.BackColor = Color.LightGreen;
                CbStartWithSteamVR.Enabled = true;

                Task t = new(() =>
                {
                    CheckingForExitSteamVr();
                });
                t.Start();
            }
            else
            {
                VrStarted = false;
                BuVrStatus.BackColor = Color.LightPink;
                CbStartWithSteamVR.Enabled = false;
                TimerCheckForVR.Enabled = true;
            }
        }

        private void CheckingForExitSteamVr()
        {
            while (VrStarted)
            {
                var vrEvents = new List<VREvent_t>();
                var vrEvent = new VREvent_t();
                uint eventSize = (uint)Marshal.SizeOf(vrEvent);
                try
                {
                    while (OpenVR.System.PollNextEvent(ref vrEvent, eventSize))
                    {
                        vrEvents.Add(vrEvent);
                    }
                }
                catch
                {
                }

                foreach (var e in vrEvents)
                {
                    if ((EVREventType)e.eventType == EVREventType.VREvent_Quit)
                    {
                        OpenVR.System.AcknowledgeQuit_Exiting();
                        VrStarted = false;
                        this.Invoke(new Action(() =>
                        {
                            this.Close();
                        }));
                    }
                }
                Thread.Sleep(100);
            }
        }

        private bool InitVr()
        {
            TimerCheckForVR.Enabled = false;
            if (!IsProcessRunning("vrserver") && !IsProcessRunning("vrcompositor"))
                return false;

            var systemErr = EVRInitError.None;
            VrSystem = OpenVR.Init(ref systemErr, EVRApplicationType.VRApplication_Overlay);

            if (systemErr != EVRInitError.None)
                return false;

            LeftHandId = VrSystem.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.LeftHand);
            RightHandId = VrSystem.GetTrackedDeviceIndexForControllerRole(ETrackedControllerRole.RightHand);

            if (LeftHandId == 0 || LeftHandId > 255 || RightHandId == 0 || RightHandId > 255)
                TimerCheckForControllers.Enabled = true;

            return true;
        }

        private async void StartHaptickFeedback(HapticAnimation selectedAnimation)
        {
            if (HapticPlaying)
                return;

            HapticPlaying = true;
            PlayingHapticAnimation = selectedAnimation;

            Task.Run(() => PlayHaptic());
        }

        private async Task PlayHaptic()
        {
            foreach (var fr in PlayingHapticAnimation.HapticFrames)
            {
                {
                    // Play 
                    Stopwatch sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < fr.Duration)
                    {
                        if ((Properties.Settings.Default.Controller == 0 || Properties.Settings.Default.Controller == 1) && LeftHandId < 256)
                            VrSystem.TriggerHapticPulse(LeftHandId, 0, hapticForce);
                        if ((Properties.Settings.Default.Controller == 0 || Properties.Settings.Default.Controller == 2) && RightHandId < 256)
                            VrSystem.TriggerHapticPulse(RightHandId, 0, hapticForce);

                        long waitForNextIteration = sw.ElapsedMilliseconds + 10;
                        while (sw.ElapsedMilliseconds < waitForNextIteration) { }
                    }
                    sw.Stop();
                }
                {
                    // Wait
                    Stopwatch sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < fr.DelayAfterPlay) { }
                    sw.Stop();
                }
            }
            HapticPlaying = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (CbHideToTray.Checked)
                {
                    Hide();
                    ShowInTaskbar = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NiMain.Visible = false;
            NiMain.Dispose();
            OpenVR.Shutdown();
        }
    }
}