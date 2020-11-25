using System;
using System.Windows.Forms;

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
            if (!passTextBox.Text.Equals(confpassTextBox.Text))
            {
                MessageBox.Show(caption: "Failed registration", text: "Your password must be the same in both boxes!");
            }
            else
            {
                Program.sessionInfo.Register(loginTextBox.Text, passTextBox.Text, emailTextBox.Text);
                Program.main.RefreshListView();
                Close();
            }
        }
    }
}
