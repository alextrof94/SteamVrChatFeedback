using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;

namespace SteamVrChatFeedback
{
    public partial class Form1 : Form
    {
        readonly static string AppVersion = "1.0";
        readonly static string AppName = "SteamVrChatFeedback";
        readonly static string TlAddressCheckForUpdates = "https://turnlive.ru/apps/check_updates.php";
        readonly string PathToExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
        bool AppLoaded = false;

        List<string> WhiteList = new List<string>();
        List<string> IgnoreList = new List<string>();
        List<HapticAnimation> HapticAnimations = new List<HapticAnimation>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            if (File.Exists(PathToExe + "WhiteList.json"))
                WhiteList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(PathToExe + "WhiteList.json"));
            if (File.Exists(PathToExe + "IgnoreList.json"))
                IgnoreList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(PathToExe + "IgnoreList.json"));
            if (File.Exists(PathToExe + "HapticAnimations.json"))
                HapticAnimations = JsonConvert.DeserializeObject<List<HapticAnimation>>(File.ReadAllText(PathToExe + "HapticAnimations.json"));

            var flags = Properties.Settings.Default.Flags;
            var checkBoxes = Extensions.FindAllChildrenByType<CheckBox>(this);
            for (int i = 0; i < flags.Length; i++)
            {
                var checkBox = checkBoxes.FirstOrDefault(x => x.Tag.Equals(i.ToString()));
                if (checkBox != null)
                    checkBox.Checked = (flags[i] == '1');
            }
            AppLoaded = true;

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
            OpenBrowser("https://www.donationalerts.com/r/goodvrgames");
        }

        private void BuCheckUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                string versionOnSiteData = DoGetRequest(TlAddressCheckForUpdates + "?appName=" + AppName);
                var versionOnSiteResp = JsonConvert.DeserializeObject<CheckForUpdateResponse>(versionOnSiteData);
                if (versionOnSiteResp.Version != AppVersion)
                {
                    if (MessageBox.Show($"{Translations.GetString("NewVersion")} {versionOnSiteResp.Version}", "VrScreamer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        OpenBrowser(versionOnSiteResp.Link);
                }
                else
                {
                    MessageBox.Show($"{Translations.GetString("AlreadyUpToDate")}", "VrScreamer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, AppName);
            }
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
        }

        private void BuOpenIgnoreList_Click(object sender, EventArgs e)
        {
            FormEditList form = new FormEditList();
            form.Text = AppName + " - Ignore List";
            form.Lines = IgnoreList;
            form.ShowDialog();
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

            string flags = Properties.Settings.Default.Flags;
            while (flags.Length <= 30)
                flags += "0";


            StringBuilder flagsSb = new StringBuilder(flags);
            flagsSb[cbIndex] = (cb.Checked) ? '1' : '0';

            Properties.Settings.Default.Flags = flagsSb.ToString();
            Properties.Settings.Default.Save();

            CbsSetEnable();
        }
    }

    public enum NotifyController
    {
        BOTH, LEFT, RIGHT
    }
}