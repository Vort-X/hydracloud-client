using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class UnshareForm : Form
    {
        private readonly string unshareTarget;

        public UnshareForm(string unshareTarget, string[] usersWithAccess)
        {
            this.unshareTarget = unshareTarget;
            InitializeComponent();
            if (usersWithAccess != null)
                userComboBox.Items.AddRange(usersWithAccess);
        }

        private void UnshareButton_Click(object sender, EventArgs e)
        {
            Program.sessionInfo.Unshare(unshareTarget, userComboBox.Text);
            Program.sessionInfo.ReloadFolder();
            Program.main.RefreshListView();
            Close();
        }
    }
}
