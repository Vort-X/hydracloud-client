using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ConfirmLoginButton_Click(object sender, EventArgs e)
        {
            Program.sessionInfo.Authorize(loginTextBox.Text, passTextBox.Text);
            Program.main.RefreshListView();
            Close();
        }
    }
}
