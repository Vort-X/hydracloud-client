using System;
using System.Windows.Forms;
using HydraClassLibrary.ClientServices;

namespace HydraClient
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!ClientUserServices.LoginValidator(loginTextBox.Text))
            {
                MessageBox.Show(caption: "Failed registration", text: "Invalid login!");
            }
            else if (!ClientUserServices.MailValidator(emailTextBox.Text))
            {
                MessageBox.Show(caption: "Failed registration", text: "Invalid E-mail!");
            }
            else if (!ClientUserServices.PassValidator(passTextBox.Text))
            {
                MessageBox.Show(caption: "Failed registration", text: "Invalid password!");
            }
            else if (!passTextBox.Text.Equals(confpassTextBox.Text))
            {
                MessageBox.Show(caption: "Failed registration", text: "Your password must be the same in both boxes!");
            }
            else
            {
                var user = Program.cloudConnection.Register(loginTextBox.Text, emailTextBox.Text, passTextBox.Text);
                if (user != null)
                {
                    Program.sessionInfo.Authorize(user);
                    Program.main.RefreshListView();
                    Program.main.EnableFolderListView();
                    Close();
                }
                else
                {
                    MessageBox.Show(caption: "Failed authentification", text: "User with such login already exists!");
                }
            }
        }
    }
}
