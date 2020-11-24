using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class RenameForm : Form
    {
        private readonly ClientUser currentUser;
        private readonly string owner;
        private readonly object fileOrFolder;
        private readonly Type type;

        public RenameForm(ClientUser currentUser, string owner, object fileOrFolder, Type type)
        {
            this.currentUser = currentUser;
            this.owner = owner;
            this.fileOrFolder = fileOrFolder;
            this.type = type; 
            InitializeComponent();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (type.Equals(typeof(ClientFolder)))
                Program.cloudConnection.RenameFolder(currentUser, owner, (ClientFolder)fileOrFolder, renameTextBox.Text);
            if (type.Equals(typeof(ClientFile)))
                Program.cloudConnection.RenameFile(currentUser, owner, (ClientFile)fileOrFolder, renameTextBox.Text);
            Program.main.RefreshListView();
            Close();
        }
    }
}
