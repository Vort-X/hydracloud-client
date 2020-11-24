using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class UploadForm : Form
    {
        private readonly ClientUser currentUser;
        private readonly string owner;
        private readonly ClientFolder cloudFolder;
        private readonly Type type;

        public UploadForm(ClientUser currentUser, string owner, ClientFolder cloudFolder, Type type)
        {
            this.currentUser = currentUser;
            this.owner = owner;
            this.cloudFolder = cloudFolder;
            this.type = type;
            if(type.Equals(typeof(ClientFolder)))
            {
                Text += " folder";
            }
            if (type.Equals(typeof(ClientFile)))
            {
                Text += " file";
            }

            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (type.Equals(typeof(ClientFolder)))
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                pathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
            if (type.Equals(typeof(ClientFile)))
            {
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                pathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName == "" || openFileDialog.FileName == null)
            {
                MessageBox.Show("Empty path");
            }
            else
            {
                if (type.Equals(typeof(ClientFolder)))
                    Program.cloudConnection.UploadFolder(currentUser, owner, cloudFolder, folderBrowserDialog.SelectedPath);
                if (type.Equals(typeof(ClientFile)))
                    Program.cloudConnection.UploadFile(currentUser, owner, cloudFolder, openFileDialog.FileName);
            }
            Program.main.RefreshListView();
            Close();
        }
    }
}
