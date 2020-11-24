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
            var user = Program.cloudConnection.Authorize(loginTextBox.Text, passTextBox.Text);
            if (user != null)
            {
                Program.sessionInfo.Authorize(user);
                Program.main.RefreshListView();
                Program.main.EnableFolderListView();
                Close();
            }
            else
            {
                MessageBox.Show(caption: "Failed authentification", text: "Wrong login or password!");
            }
        }
    }
}
