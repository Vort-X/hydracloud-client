using HydraClassLibrary;
using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class ShareForm : Form
    {
        private readonly ClientUser currentUser;
        private readonly string owner;
        private readonly object fileOrFolder;
        private readonly Type type;

        public ShareForm(ClientUser currentUser, string owner, object fileOrFolder, Type type)
        {
            this.currentUser = currentUser;
            this.owner = owner;
            this.fileOrFolder = fileOrFolder;
            this.type = type;
            InitializeComponent();
        }

        private void ShareButton_Click(object sender, EventArgs e)
        {
            if (type.Equals(typeof(ClientFolder)))
                Program.cloudConnection.ShareFolder(currentUser, owner, (ClientFolder)fileOrFolder, shareTextBox.Text, Permission.FullAccess);
            if (type.Equals(typeof(ClientFile)))
                Program.cloudConnection.ShareFile(currentUser, owner, (ClientFile)fileOrFolder, shareTextBox.Text, Permission.FullAccess);
            Program.main.RefreshListView();
            Close();
        }
    }
}
