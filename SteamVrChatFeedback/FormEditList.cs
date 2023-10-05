using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamVrChatFeedback
{
    public partial class FormEditList : Form
    {
        public List<string> Lines = new List<string>();

        public FormEditList()
        {
            InitializeComponent();
        }

        private void BuAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TbLine.Text) && !Lines.Contains(TbLine.Text))
            {
                Lines.Add(TbLine.Text);
                LbLines.Items.Clear();
                LbLines.Items.AddRange(Lines.ToArray());
                TbLine.Text = "";
            }
        }

        private void BuDelete_Click(object sender, EventArgs e)
        {
            if (LbLines.SelectedIndex > -1)
            {
                Lines.RemoveAt(LbLines.SelectedIndex);
                LbLines.Items.Clear();
                LbLines.Items.AddRange(Lines.ToArray());
            }
        }

        private void FormEditList_Shown(object sender, EventArgs e)
        {
            LbLines.Items.Clear();
            LbLines.Items.AddRange(Lines.ToArray());
        }
    }
}
