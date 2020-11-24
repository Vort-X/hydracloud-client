using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class DownloadForm : Form
    {
        private readonly ClientUser currentUser;
        private readonly string owner;
        private readonly object fileOrFolder;
        private readonly Type type;

        public DownloadForm(ClientUser currentUser, string owner, object fileOrFolder, Type type)
        {
            this.currentUser = currentUser;
            this.owner = owner;
            this.fileOrFolder = fileOrFolder;
            this.type = type;
            if (type.Equals(typeof(ClientFolder)))
                Text += " " + ((ClientFolder) fileOrFolder)?.Name;
            if (type.Equals(typeof(ClientFile)))
                Text += " " + ((ClientFile) fileOrFolder)?.Name;
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                return;
            pathTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.SelectedPath == "" || folderBrowserDialog.SelectedPath == null)
            {
                MessageBox.Show("Empty path");
            }
            else
            {
                if (type.Equals(typeof(ClientFolder))) 
                    Program.cloudConnection.DownloadFolder(currentUser, owner, (ClientFolder)fileOrFolder, folderBrowserDialog.SelectedPath + "\\");
                if (type.Equals(typeof(ClientFile)))
                    Program.cloudConnection.DownloadFile(currentUser, owner, (ClientFile)fileOrFolder, folderBrowserDialog.SelectedPath + "\\");
            }
            Close();
        }
    }
}
