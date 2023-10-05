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
            BuDonate = new Button();
            BuVrConnected = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            TbTwChannelName = new TextBox();
            BuTwConnect = new Button();
            groupBox2 = new GroupBox();
            BuTestVibro = new Button();
            BuOpenJson = new Button();
            CbVibroName = new ComboBox();
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
            LlOpenGithub = new LinkLabel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // BuDonate
            // 
            BuDonate.BackColor = Color.LawnGreen;
            BuDonate.Location = new Point(62, 72);
            BuDonate.Name = "BuDonate";
            BuDonate.Size = new Size(75, 23);
            BuDonate.TabIndex = 0;
            BuDonate.Text = "DONATE";
            BuDonate.UseVisualStyleBackColor = false;
            BuDonate.Click += BuDonate_Click;
            // 
            // BuVrConnected
            // 
            BuVrConnected.BackColor = Color.LightPink;
            BuVrConnected.Enabled = false;
            BuVrConnected.Location = new Point(210, 44);
            BuVrConnected.Name = "BuVrConnected";
            BuVrConnected.Size = new Size(87, 23);
            BuVrConnected.TabIndex = 1;
            BuVrConnected.Text = "Статус VR";
            BuVrConnected.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(TbTwChannelName);
            groupBox1.Controls.Add(BuTwConnect);
            groupBox1.Location = new Point(12, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(303, 84);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Twitch";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Канал:";
            // 
            // TbTwChannelName
            // 
            TbTwChannelName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TbTwChannelName.Location = new Point(55, 22);
            TbTwChannelName.Name = "TbTwChannelName";
            TbTwChannelName.Size = new Size(242, 23);
            TbTwChannelName.TabIndex = 1;
            // 
            // BuTwConnect
            // 
            BuTwConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BuTwConnect.Location = new Point(6, 51);
            BuTwConnect.Name = "BuTwConnect";
            BuTwConnect.Size = new Size(291, 23);
            BuTwConnect.TabIndex = 0;
            BuTwConnect.Text = "Подключить";
            BuTwConnect.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BuTestVibro);
            groupBox2.Controls.Add(BuOpenJson);
            groupBox2.Controls.Add(CbVibroName);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(CbController);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 208);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(303, 108);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Вибрация";
            // 
            // BuTestVibro
            // 
            BuTestVibro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BuTestVibro.Location = new Point(6, 79);
            BuTestVibro.Name = "BuTestVibro";
            BuTestVibro.Size = new Size(291, 23);
            BuTestVibro.TabIndex = 5;
            BuTestVibro.Text = "Тест";
            BuTestVibro.UseVisualStyleBackColor = true;
            // 
            // BuOpenJson
            // 
            BuOpenJson.Location = new Point(234, 45);
            BuOpenJson.Name = "BuOpenJson";
            BuOpenJson.Size = new Size(63, 23);
            BuOpenJson.TabIndex = 4;
            BuOpenJson.Text = "JSON";
            BuOpenJson.UseVisualStyleBackColor = true;
            // 
            // CbVibroName
            // 
            CbVibroName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CbVibroName.FormattingEnabled = true;
            CbVibroName.Location = new Point(99, 45);
            CbVibroName.Name = "CbVibroName";
            CbVibroName.Size = new Size(129, 23);
            CbVibroName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 48);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 2;
            label3.Text = "Тип вибрации:";
            // 
            // CbController
            // 
            CbController.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CbController.FormattingEnabled = true;
            CbController.Items.AddRange(new object[] { "Оба", "Левый", "Правый" });
            CbController.Location = new Point(99, 16);
            CbController.Name = "CbController";
            CbController.Size = new Size(198, 23);
            CbController.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 0;
            label2.Text = "Контроллер:";
            // 
            // groupBox3
            // 
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
            groupBox3.Location = new Point(321, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(301, 244);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Настройка оповещений";
            // 
            // BuOpenWhiteList
            // 
            BuOpenWhiteList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BuOpenWhiteList.Location = new Point(174, 186);
            BuOpenWhiteList.Name = "BuOpenWhiteList";
            BuOpenWhiteList.Size = new Size(121, 23);
            BuOpenWhiteList.TabIndex = 13;
            BuOpenWhiteList.Text = "Белый список";
            BuOpenWhiteList.UseVisualStyleBackColor = true;
            BuOpenWhiteList.Click += BuOpenWhiteList_Click;
            // 
            // BuOpenIgnoreList
            // 
            BuOpenIgnoreList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BuOpenIgnoreList.Location = new Point(174, 215);
            BuOpenIgnoreList.Name = "BuOpenIgnoreList";
            BuOpenIgnoreList.Size = new Size(121, 23);
            BuOpenIgnoreList.TabIndex = 12;
            BuOpenIgnoreList.Text = "Игнор лист";
            BuOpenIgnoreList.UseVisualStyleBackColor = true;
            BuOpenIgnoreList.Click += BuOpenIgnoreList_Click;
            // 
            // CbMsgWhiteList
            // 
            CbMsgWhiteList.AutoSize = true;
            CbMsgWhiteList.Location = new Point(174, 72);
            CbMsgWhiteList.Name = "CbMsgWhiteList";
            CbMsgWhiteList.Size = new Size(104, 19);
            CbMsgWhiteList.TabIndex = 11;
            CbMsgWhiteList.Tag = "19";
            CbMsgWhiteList.Text = "Белый список";
            CbMsgWhiteList.UseVisualStyleBackColor = true;
            CbMsgWhiteList.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgSubmode
            // 
            CbMsgSubmode.AutoSize = true;
            CbMsgSubmode.Location = new Point(6, 122);
            CbMsgSubmode.Name = "CbMsgSubmode";
            CbMsgSubmode.Size = new Size(204, 19);
            CbMsgSubmode.TabIndex = 10;
            CbMsgSubmode.Tag = "4";
            CbMsgSubmode.Text = "Сообщения в сабмоде за баллы";
            CbMsgSubmode.UseVisualStyleBackColor = true;
            CbMsgSubmode.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgFirst
            // 
            CbMsgFirst.AutoSize = true;
            CbMsgFirst.Location = new Point(6, 222);
            CbMsgFirst.Name = "CbMsgFirst";
            CbMsgFirst.Size = new Size(136, 19);
            CbMsgFirst.TabIndex = 9;
            CbMsgFirst.Tag = "8";
            CbMsgFirst.Text = "Первые сообщения";
            CbMsgFirst.UseVisualStyleBackColor = true;
            CbMsgFirst.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgTurbo
            // 
            CbMsgTurbo.AutoSize = true;
            CbMsgTurbo.Location = new Point(6, 197);
            CbMsgTurbo.Name = "CbMsgTurbo";
            CbMsgTurbo.Size = new Size(76, 19);
            CbMsgTurbo.TabIndex = 8;
            CbMsgTurbo.Tag = "7";
            CbMsgTurbo.Text = "От Турбо";
            CbMsgTurbo.UseVisualStyleBackColor = true;
            CbMsgTurbo.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgPartner
            // 
            CbMsgPartner.AutoSize = true;
            CbMsgPartner.Location = new Point(6, 172);
            CbMsgPartner.Name = "CbMsgPartner";
            CbMsgPartner.Size = new Size(101, 19);
            CbMsgPartner.TabIndex = 7;
            CbMsgPartner.Tag = "6";
            CbMsgPartner.Text = "От партнёров";
            CbMsgPartner.UseVisualStyleBackColor = true;
            CbMsgPartner.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgHighlighted
            // 
            CbMsgHighlighted.AutoSize = true;
            CbMsgHighlighted.Location = new Point(6, 147);
            CbMsgHighlighted.Name = "CbMsgHighlighted";
            CbMsgHighlighted.Size = new Size(163, 19);
            CbMsgHighlighted.TabIndex = 6;
            CbMsgHighlighted.Tag = "5";
            CbMsgHighlighted.Text = "Выделенные сообщения";
            CbMsgHighlighted.UseVisualStyleBackColor = true;
            CbMsgHighlighted.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgVip
            // 
            CbMsgVip.AutoSize = true;
            CbMsgVip.Location = new Point(6, 97);
            CbMsgVip.Name = "CbMsgVip";
            CbMsgVip.Size = new Size(68, 19);
            CbMsgVip.TabIndex = 5;
            CbMsgVip.Tag = "3";
            CbMsgVip.Text = "От ВИП";
            CbMsgVip.UseVisualStyleBackColor = true;
            CbMsgVip.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgSub
            // 
            CbMsgSub.AutoSize = true;
            CbMsgSub.Location = new Point(6, 72);
            CbMsgSub.Name = "CbMsgSub";
            CbMsgSub.Size = new Size(116, 19);
            CbMsgSub.TabIndex = 4;
            CbMsgSub.Tag = "2";
            CbMsgSub.Text = "От подписчиков";
            CbMsgSub.UseVisualStyleBackColor = true;
            CbMsgSub.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgHey
            // 
            CbMsgHey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CbMsgHey.AutoSize = true;
            CbMsgHey.Location = new Point(174, 47);
            CbMsgHey.Name = "CbMsgHey";
            CbMsgHey.Size = new Size(48, 19);
            CbMsgHey.TabIndex = 3;
            CbMsgHey.Tag = "10";
            CbMsgHey.Text = "!hey";
            CbMsgHey.UseVisualStyleBackColor = true;
            CbMsgHey.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgMod
            // 
            CbMsgMod.AutoSize = true;
            CbMsgMod.Location = new Point(6, 47);
            CbMsgMod.Name = "CbMsgMod";
            CbMsgMod.Size = new Size(116, 19);
            CbMsgMod.TabIndex = 2;
            CbMsgMod.Tag = "1";
            CbMsgMod.Text = "От модераторов";
            CbMsgMod.UseVisualStyleBackColor = true;
            CbMsgMod.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgCmds
            // 
            CbMsgCmds.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CbMsgCmds.AutoSize = true;
            CbMsgCmds.Location = new Point(174, 22);
            CbMsgCmds.Name = "CbMsgCmds";
            CbMsgCmds.Size = new Size(80, 19);
            CbMsgCmds.TabIndex = 1;
            CbMsgCmds.Tag = "9";
            CbMsgCmds.Text = "!Команды";
            CbMsgCmds.UseVisualStyleBackColor = true;
            CbMsgCmds.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbMsgAll
            // 
            CbMsgAll.AutoSize = true;
            CbMsgAll.Location = new Point(6, 22);
            CbMsgAll.Name = "CbMsgAll";
            CbMsgAll.Size = new Size(112, 19);
            CbMsgAll.TabIndex = 0;
            CbMsgAll.Tag = "0";
            CbMsgAll.Text = "Все сообщения";
            CbMsgAll.UseVisualStyleBackColor = true;
            CbMsgAll.CheckedChanged += Cb_CheckedChanged;
            // 
            // BuCheckUpdates
            // 
            BuCheckUpdates.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BuCheckUpdates.Location = new Point(143, 71);
            BuCheckUpdates.Name = "BuCheckUpdates";
            BuCheckUpdates.Size = new Size(154, 23);
            BuCheckUpdates.TabIndex = 5;
            BuCheckUpdates.Text = "Проверить обновления";
            BuCheckUpdates.UseVisualStyleBackColor = true;
            BuCheckUpdates.Click += BuCheckUpdates_Click;
            // 
            // CbHideOnStart
            // 
            CbHideOnStart.AutoSize = true;
            CbHideOnStart.Location = new Point(6, 22);
            CbHideOnStart.Name = "CbHideOnStart";
            CbHideOnStart.Size = new Size(148, 19);
            CbHideOnStart.TabIndex = 6;
            CbHideOnStart.Tag = "20";
            CbHideOnStart.Text = "Скрывать при запуске";
            CbHideOnStart.UseVisualStyleBackColor = true;
            CbHideOnStart.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbHideToTray
            // 
            CbHideToTray.AutoSize = true;
            CbHideToTray.Location = new Point(160, 22);
            CbHideToTray.Name = "CbHideToTray";
            CbHideToTray.Size = new Size(60, 19);
            CbHideToTray.TabIndex = 7;
            CbHideToTray.Tag = "21";
            CbHideToTray.Text = "в трей";
            CbHideToTray.UseVisualStyleBackColor = true;
            CbHideToTray.CheckedChanged += Cb_CheckedChanged;
            // 
            // CbStartWithSteamVR
            // 
            CbStartWithSteamVR.AutoSize = true;
            CbStartWithSteamVR.Location = new Point(6, 47);
            CbStartWithSteamVR.Name = "CbStartWithSteamVR";
            CbStartWithSteamVR.Size = new Size(188, 19);
            CbStartWithSteamVR.TabIndex = 8;
            CbStartWithSteamVR.Tag = "22";
            CbStartWithSteamVR.Text = "Запускать вместе со SteamVR";
            CbStartWithSteamVR.UseVisualStyleBackColor = true;
            CbStartWithSteamVR.CheckedChanged += Cb_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(LlOpenGithub);
            groupBox4.Controls.Add(BuCheckUpdates);
            groupBox4.Controls.Add(CbStartWithSteamVR);
            groupBox4.Controls.Add(CbHideOnStart);
            groupBox4.Controls.Add(BuDonate);
            groupBox4.Controls.Add(BuVrConnected);
            groupBox4.Controls.Add(CbHideToTray);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(303, 100);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Настройки программы";
            // 
            // LlOpenGithub
            // 
            LlOpenGithub.AutoSize = true;
            LlOpenGithub.Location = new Point(6, 75);
            LlOpenGithub.Name = "LlOpenGithub";
            LlOpenGithub.Size = new Size(43, 15);
            LlOpenGithub.TabIndex = 9;
            LlOpenGithub.TabStop = true;
            LlOpenGithub.Text = "Github";
            LlOpenGithub.LinkClicked += LlOpenGithub_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 320);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "SteamVrTwitchChatFeedback by GoodVrGames aka alextrof94";
            Shown += Form1_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BuDonate;
        private Button BuVrConnected;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox TbTwChannelName;
        private Button BuTwConnect;
        private GroupBox groupBox2;
        private ComboBox CbController;
        private Label label2;
        private Button BuTestVibro;
        private Button BuOpenJson;
        private ComboBox CbVibroName;
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
    }
}