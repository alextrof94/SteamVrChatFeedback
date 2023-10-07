namespace SteamVrChatFeedback
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BuDonate = new Button();
            BuVrStatus = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            TbTwChannelName = new TextBox();
            BuTwConnect = new Button();
            groupBox2 = new GroupBox();
            label4 = new Label();
            TbHapticForce = new TrackBar();
            BuTestHaptic = new Button();
            BuOpenJson = new Button();
            CbHapticAnimations = new ComboBox();
            label3 = new Label();
            CbController = new ComboBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            BuOpenWhiteList = new Button();
            BuOpenIgnoreList = new Button();
            CbMsgWhiteList = new CheckBox();
            CbMsgSubmode = new CheckBox();
            CbMsgFirst = new CheckBox();
            CbMsgTurbo = new CheckBox();
            CbMsgPartner = new CheckBox();
            CbMsgHighlighted = new CheckBox();
            CbMsgVip = new CheckBox();
            CbMsgSub = new CheckBox();
            CbMsgHey = new CheckBox();
            CbMsgMod = new CheckBox();
            CbMsgCmds = new CheckBox();
            CbMsgAll = new CheckBox();
            BuCheckUpdates = new Button();
            CbHideOnStart = new CheckBox();
            CbHideToTray = new CheckBox();
            CbStartWithSteamVR = new CheckBox();
            groupBox4 = new GroupBox();
            BuVrL = new Button();
            BuVrR = new Button();
            LlOpenGithub = new LinkLabel();
            TiTwCheckExpired = new System.Windows.Forms.Timer(components);
            TtHint = new ToolTip(components);
            TimerCheckForVR = new System.Windows.Forms.Timer(components);
            TimerCheckForControllers = new System.Windows.Forms.Timer(components);
            NiMain = new NotifyIcon(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TbHapticForce).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // BuDonate
            // 
            resources.ApplyResources(BuDonate, "BuDonate");
            BuDonate.BackColor = Color.LawnGreen;
            BuDonate.Name = "BuDonate";
            TtHint.SetToolTip(BuDonate, resources.GetString("BuDonate.ToolTip"));
            BuDonate.UseVisualStyleBackColor = false;
            BuDonate.Click += BuDonate_Click;
            // 
            // BuVrStatus
            // 
            resources.ApplyResources(BuVrStatus, "BuVrStatus");
            BuVrStatus.BackColor = Color.LightPink;
            BuVrStatus.Name = "BuVrStatus";
            BuVrStatus.TabStop = false;
            TtHint.SetToolTip(BuVrStatus, resources.GetString("BuVrStatus.ToolTip"));
            BuVrStatus.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TbTwChannelName);
            groupBox1.Controls.Add(BuTwConnect);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            TtHint.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            TtHint.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // TbTwChannelName
            // 
            resources.ApplyResources(TbTwChannelName, "TbTwChannelName");
            TbTwChannelName.Name = "TbTwChannelName";
            TtHint.SetToolTip(TbTwChannelName, resources.GetString("TbTwChannelName.ToolTip"));
            // 
            // BuTwConnect
            // 
            resources.ApplyResources(BuTwConnect, "BuTwConnect");
            BuTwConnect.BackColor = Color.LightPink;
            BuTwConnect.Name = "BuTwConnect";
            TtHint.SetToolTip(BuTwConnect, resources.GetString("BuTwConnect.ToolTip"));
            BuTwConnect.UseVisualStyleBackColor = false;
            BuTwConnect.Click += BuTwConnect_Click;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(TbHapticForce);
            groupBox2.Controls.Add(BuTestHaptic);
            groupBox2.Controls.Add(BuOpenJson);
            groupBox2.Controls.Add(CbHapticAnimations);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(CbController);
            groupBox2.Controls.Add(label2);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            TtHint.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            TtHint.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // TbHapticForce
            // 
            resources.ApplyResources(TbHapticForce, "TbHapticForce");
            TbHapticForce.Maximum = 255;
            TbHapticForce.Name = "TbHapticForce";
            TbHapticForce.TickFrequency = 20;
            TtHint.SetToolTip(TbHapticForce, resources.GetString("TbHapticForce.ToolTip"));
            TbHapticForce.Value = 1;
            TbHapticForce.Scroll += TbHapticForce_Scroll;
            // 
            // BuTestHaptic
            // 
            resources.ApplyResources(BuTestHaptic, "BuTestHaptic");
            BuTestHaptic.Name = "BuTestHaptic";
            TtHint.SetToolTip(BuTestHaptic, resources.GetString("BuTestHaptic.ToolTip"));
            BuTestHaptic.UseVisualStyleBackColor = true;
            BuTestHaptic.Click += BuTestHaptic_Click;
            // 
            // BuOpenJson
            // 
            resources.ApplyResources(BuOpenJson, "BuOpenJson");
            BuOpenJson.Name = "BuOpenJson";
            TtHint.SetToolTip(BuOpenJson, resources.GetString("BuOpenJson.ToolTip"));
            BuOpenJson.UseVisualStyleBackColor = true;
            // 
            // CbHapticAnimations
            // 
            resources.ApplyResources(CbHapticAnimations, "CbHapticAnimations");
            CbHapticAnimations.DropDownStyle = ComboBoxStyle.DropDownList;
            CbHapticAnimations.FormattingEnabled = true;
            CbHapticAnimations.Name = "CbHapticAnimations";
            TtHint.SetToolTip(CbHapticAnimations, resources.GetString("CbHapticAnimations.ToolTip"));
            CbHapticAnimations.SelectedIndexChanged += CbHapticAnimationNames_SelectedIndexChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            TtHint.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // CbController
            // 
            resources.ApplyResources(CbController, "CbController");
            CbController.DropDownStyle = ComboBoxStyle.DropDownList;
            CbController.FormattingEnabled = true;
            CbController.Name = "CbController";
            TtHint.SetToolTip(CbController, resources.GetString("CbController.ToolTip"));
            CbController.SelectedIndexChanged += CbController_SelectedIndexChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            TtHint.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(BuOpenWhiteList);
            groupBox3.Controls.Add(BuOpenIgnoreList);
            groupBox3.Controls.Add(CbMsgWhiteList);
            groupBox3.Controls.Add(CbMsgSubmode);
            groupBox3.Controls.Add(CbMsgFirst);
            groupBox3.Controls.Add(CbMsgTurbo);
            groupBox3.Controls.Add(CbMsgPartner);
            groupBox3.Controls.Add(CbMsgHighlighted);
            groupBox3.Controls.Add(CbMsgVip);
            groupBox3.Controls.Add(CbMsgSub);
            groupBox3.Controls.Add(CbMsgHey);
            groupBox3.Controls.Add(CbMsgMod);
            groupBox3.Controls.Add(CbMsgCmds);
            groupBox3.Controls.Add(CbMsgAll);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            TtHint.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // BuOpenWhiteList
            // 
            resources.ApplyResources(BuOpenWhiteList, "BuOpenWhiteList");
            BuOpenWhiteList.Name = "BuOpenWhiteList";
            TtHint.SetToolTip(BuOpenWhiteList, resources.GetString("BuOpenWhiteList.ToolTip"));
            BuOpenWhiteList.UseVisualStyleBackColor = true;
            BuOpenWhiteList.Click += BuOpenWhiteList_Click;
            // 
            // BuOpenIgnoreList
            // 
            resources.ApplyResources(BuOpenIgnoreList, "BuOpenIgnoreList");
            BuOpenIgnoreList.Name = "BuOpenIgnoreList";
            TtHint.SetToolTip(BuOpenIgnoreList, resources.GetString("BuOpenIgnoreList.ToolTip"));
            BuOpenIgnoreList.UseVisualStyleBackColor = true;
            BuOpenIgnoreList.Click += BuOpenIgnoreList_Click;
            // 
            // CbMsgWhiteList
            // 
            resources.ApplyResources(CbMsgWhiteList, "CbMsgWhiteList");
            CbMsgWhiteList.Name = "CbMsgWhiteList";
            CbMsgWhiteList.Tag = "19";
            TtHint.SetToolTip(CbMsgWhiteList, resources.GetString("CbMsgWhiteList.ToolTip"));
            CbMsgWhiteList.UseVisualStyleBackColor = true;
            CbMsgWhiteList.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgSubmode
            // 
            resources.ApplyResources(CbMsgSubmode, "CbMsgSubmode");
            CbMsgSubmode.Name = "CbMsgSubmode";
            CbMsgSubmode.Tag = "4";
            TtHint.SetToolTip(CbMsgSubmode, resources.GetString("CbMsgSubmode.ToolTip"));
            CbMsgSubmode.UseVisualStyleBackColor = true;
            CbMsgSubmode.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgFirst
            // 
            resources.ApplyResources(CbMsgFirst, "CbMsgFirst");
            CbMsgFirst.Name = "CbMsgFirst";
            CbMsgFirst.Tag = "8";
            TtHint.SetToolTip(CbMsgFirst, resources.GetString("CbMsgFirst.ToolTip"));
            CbMsgFirst.UseVisualStyleBackColor = true;
            CbMsgFirst.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgTurbo
            // 
            resources.ApplyResources(CbMsgTurbo, "CbMsgTurbo");
            CbMsgTurbo.Name = "CbMsgTurbo";
            CbMsgTurbo.Tag = "7";
            TtHint.SetToolTip(CbMsgTurbo, resources.GetString("CbMsgTurbo.ToolTip"));
            CbMsgTurbo.UseVisualStyleBackColor = true;
            CbMsgTurbo.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgPartner
            // 
            resources.ApplyResources(CbMsgPartner, "CbMsgPartner");
            CbMsgPartner.Name = "CbMsgPartner";
            CbMsgPartner.Tag = "6";
            TtHint.SetToolTip(CbMsgPartner, resources.GetString("CbMsgPartner.ToolTip"));
            CbMsgPartner.UseVisualStyleBackColor = true;
            CbMsgPartner.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgHighlighted
            // 
            resources.ApplyResources(CbMsgHighlighted, "CbMsgHighlighted");
            CbMsgHighlighted.Name = "CbMsgHighlighted";
            CbMsgHighlighted.Tag = "5";
            TtHint.SetToolTip(CbMsgHighlighted, resources.GetString("CbMsgHighlighted.ToolTip"));
            CbMsgHighlighted.UseVisualStyleBackColor = true;
            CbMsgHighlighted.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgVip
            // 
            resources.ApplyResources(CbMsgVip, "CbMsgVip");
            CbMsgVip.Name = "CbMsgVip";
            CbMsgVip.Tag = "3";
            TtHint.SetToolTip(CbMsgVip, resources.GetString("CbMsgVip.ToolTip"));
            CbMsgVip.UseVisualStyleBackColor = true;
            CbMsgVip.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgSub
            // 
            resources.ApplyResources(CbMsgSub, "CbMsgSub");
            CbMsgSub.Name = "CbMsgSub";
            CbMsgSub.Tag = "2";
            TtHint.SetToolTip(CbMsgSub, resources.GetString("CbMsgSub.ToolTip"));
            CbMsgSub.UseVisualStyleBackColor = true;
            CbMsgSub.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgHey
            // 
            resources.ApplyResources(CbMsgHey, "CbMsgHey");
            CbMsgHey.Name = "CbMsgHey";
            CbMsgHey.Tag = "10";
            TtHint.SetToolTip(CbMsgHey, resources.GetString("CbMsgHey.ToolTip"));
            CbMsgHey.UseVisualStyleBackColor = true;
            CbMsgHey.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgMod
            // 
            resources.ApplyResources(CbMsgMod, "CbMsgMod");
            CbMsgMod.Name = "CbMsgMod";
            CbMsgMod.Tag = "1";
            TtHint.SetToolTip(CbMsgMod, resources.GetString("CbMsgMod.ToolTip"));
            CbMsgMod.UseVisualStyleBackColor = true;
            CbMsgMod.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgCmds
            // 
            resources.ApplyResources(CbMsgCmds, "CbMsgCmds");
            CbMsgCmds.Name = "CbMsgCmds";
            CbMsgCmds.Tag = "9";
            TtHint.SetToolTip(CbMsgCmds, resources.GetString("CbMsgCmds.ToolTip"));
            CbMsgCmds.UseVisualStyleBackColor = true;
            CbMsgCmds.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgAll
            // 
            resources.ApplyResources(CbMsgAll, "CbMsgAll");
            CbMsgAll.Name = "CbMsgAll";
            CbMsgAll.Tag = "0";
            TtHint.SetToolTip(CbMsgAll, resources.GetString("CbMsgAll.ToolTip"));
            CbMsgAll.UseVisualStyleBackColor = true;
            CbMsgAll.CheckedChanged += Cb_CheckedChanged;
            // 
            // BuCheckUpdates
            // 
            resources.ApplyResources(BuCheckUpdates, "BuCheckUpdates");
            BuCheckUpdates.Name = "BuCheckUpdates";
            TtHint.SetToolTip(BuCheckUpdates, resources.GetString("BuCheckUpdates.ToolTip"));
            BuCheckUpdates.UseVisualStyleBackColor = true;
            BuCheckUpdates.Click += BuCheckUpdates_Click;
            // 
            // CbHideOnStart
            // 
            resources.ApplyResources(CbHideOnStart, "CbHideOnStart");
            CbHideOnStart.Name = "CbHideOnStart";
            CbHideOnStart.Tag = "20";
            TtHint.SetToolTip(CbHideOnStart, resources.GetString("CbHideOnStart.ToolTip"));
            CbHideOnStart.UseVisualStyleBackColor = true;
            CbHideOnStart.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbHideToTray
            // 
            resources.ApplyResources(CbHideToTray, "CbHideToTray");
            CbHideToTray.Name = "CbHideToTray";
            CbHideToTray.Tag = "21";
            TtHint.SetToolTip(CbHideToTray, resources.GetString("CbHideToTray.ToolTip"));
            CbHideToTray.UseVisualStyleBackColor = true;
            CbHideToTray.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbStartWithSteamVR
            // 
            resources.ApplyResources(CbStartWithSteamVR, "CbStartWithSteamVR");
            CbStartWithSteamVR.Name = "CbStartWithSteamVR";
            CbStartWithSteamVR.Tag = "22";
            TtHint.SetToolTip(CbStartWithSteamVR, resources.GetString("CbStartWithSteamVR.ToolTip"));
            CbStartWithSteamVR.UseVisualStyleBackColor = true;
            CbStartWithSteamVR.CheckedChanged += Cb_CheckedChanged;
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(BuVrL);
            groupBox4.Controls.Add(BuVrR);
            groupBox4.Controls.Add(LlOpenGithub);
            groupBox4.Controls.Add(BuCheckUpdates);
            groupBox4.Controls.Add(CbStartWithSteamVR);
            groupBox4.Controls.Add(CbHideOnStart);
            groupBox4.Controls.Add(BuDonate);
            groupBox4.Controls.Add(BuVrStatus);
            groupBox4.Controls.Add(CbHideToTray);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            TtHint.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // BuVrL
            // 
            resources.ApplyResources(BuVrL, "BuVrL");
            BuVrL.BackColor = Color.LightPink;
            BuVrL.Name = "BuVrL";
            BuVrL.TabStop = false;
            TtHint.SetToolTip(BuVrL, resources.GetString("BuVrL.ToolTip"));
            BuVrL.UseVisualStyleBackColor = false;
            // 
            // BuVrR
            // 
            resources.ApplyResources(BuVrR, "BuVrR");
            BuVrR.BackColor = Color.LightPink;
            BuVrR.Name = "BuVrR";
            BuVrR.TabStop = false;
            TtHint.SetToolTip(BuVrR, resources.GetString("BuVrR.ToolTip"));
            BuVrR.UseVisualStyleBackColor = false;
            // 
            // LlOpenGithub
            // 
            resources.ApplyResources(LlOpenGithub, "LlOpenGithub");
            LlOpenGithub.Name = "LlOpenGithub";
            LlOpenGithub.TabStop = true;
            TtHint.SetToolTip(LlOpenGithub, resources.GetString("LlOpenGithub.ToolTip"));
            LlOpenGithub.LinkClicked += LlOpenGithub_LinkClicked;
            // 
            // TiTwCheckExpired
            // 
            TiTwCheckExpired.Interval = 1000;
            TiTwCheckExpired.Tick += TiTwCheckExpired_Tick;
            // 
            // TimerCheckForVR
            // 
            TimerCheckForVR.Interval = 5000;
            TimerCheckForVR.Tick += TimerCheckForVR_Tick;
            // 
            // TimerCheckForControllers
            // 
            TimerCheckForControllers.Interval = 1000;
            TimerCheckForControllers.Tick += TimerCheckForControllers_Tick;
            // 
            // NiMain
            // 
            resources.ApplyResources(NiMain, "NiMain");
            NiMain.Click += NiMain_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            TtHint.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Shown += Form1_Shown;
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TbHapticForce).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BuDonate;
        private Button BuVrStatus;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox TbTwChannelName;
        private Button BuTwConnect;
        private GroupBox groupBox2;
        private ComboBox CbController;
        private Label label2;
        private Button BuTestHaptic;
        private Button BuOpenJson;
        private ComboBox CbHapticAnimations;
        private Label label3;
        private GroupBox groupBox3;
        private CheckBox CbMsgSubmode;
        private CheckBox CbMsgFirst;
        private CheckBox CbMsgTurbo;
        private CheckBox CbMsgPartner;
        private CheckBox CbMsgHighlighted;
        private CheckBox CbMsg;
        private CheckBox CbMsgSub;
        private CheckBox CbMsgHey;
        private CheckBox CbMsgMod;
        private CheckBox CbMsgCmds;
        private CheckBox CbMsgAll;
        private Button BuOpenWhiteList;
        private Button BuOpenIgnoreList;
        private CheckBox CbMsgWhiteList;
        private CheckBox CbMsgVip;
        private Button BuCheckUpdates;
        private CheckBox CbHideOnStart;
        private CheckBox CbHideToTray;
        private CheckBox CbStartWithSteamVR;
        private GroupBox groupBox4;
        private LinkLabel LlOpenGithub;
        private System.Windows.Forms.Timer TiTwCheckExpired;
        private Label label4;
        private TrackBar TbHapticForce;
        private ToolTip TtHint;
        private System.Windows.Forms.Timer TimerCheckForVR;
        private System.Windows.Forms.Timer TimerCheckForControllers;
        private Button BuVrR;
        private Button BuVrL;
        private NotifyIcon NiMain;
    }
}