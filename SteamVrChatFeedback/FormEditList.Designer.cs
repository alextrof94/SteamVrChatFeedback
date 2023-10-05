namespace SteamVrChatFeedback
{
    partial class FormEditList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditList));
            BuAdd = new Button();
            TbLine = new TextBox();
            label1 = new Label();
            LbLines = new ListBox();
            BuDelete = new Button();
            SuspendLayout();
            // 
            // BuAdd
            // 
            resources.ApplyResources(BuAdd, "BuAdd");
            BuAdd.Name = "BuAdd";
            BuAdd.UseVisualStyleBackColor = true;
            BuAdd.Click += BuAdd_Click;
            // 
            // TbLine
            // 
            resources.ApplyResources(TbLine, "TbLine");
            TbLine.Name = "TbLine";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // LbLines
            // 
            resources.ApplyResources(LbLines, "LbLines");
            LbLines.FormattingEnabled = true;
            LbLines.Name = "LbLines";
            // 
            // BuDelete
            // 
            resources.ApplyResources(BuDelete, "BuDelete");
            BuDelete.Name = "BuDelete";
            BuDelete.UseVisualStyleBackColor = true;
            BuDelete.Click += BuDelete_Click;
            // 
            // FormEditList
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BuDelete);
            Controls.Add(LbLines);
            Controls.Add(label1);
            Controls.Add(TbLine);
            Controls.Add(BuAdd);
            Name = "FormEditList";
            Shown += FormEditList_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BuAdd;
        private TextBox TbLine;
        private Label label1;
        private ListBox LbLines;
        private Button BuDelete;
    }
}