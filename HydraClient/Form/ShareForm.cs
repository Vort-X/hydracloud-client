using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class ShareForm : Form
    {
        private readonly string obj;

        public ShareForm(string obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        private void ShareButton_Click(object sender, EventArgs e)
        {
            Program.sessionInfo.Share(obj, shareTextBox.Text, true);
            Program.main.RefreshListView();
            Close();
        }
    }
}
