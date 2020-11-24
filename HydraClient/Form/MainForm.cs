using HydraClassLibrary;
using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class MainForm : Form
    {
        private readonly ToolStripItem[] fileOrFolderStrip;
        private readonly ToolStripItem[] listViewStrip;

        public MainForm()
        {
            InitializeComponent();

            fileOrFolderStrip = new ToolStripItem[] {
                downloadToolStripMenuItem,
                copyToolStripMenuItem,
                cutToolStripMenuItem,
                renameToolStripMenuItem,
                deleteToolStripMenuItem,
                shareToolStripMenuItem,
                unshareToolStripMenuItem,
                unshareAllToolStripMenuItem};
            listViewStrip = new ToolStripItem[] {
                createFolderToolStripMenuItem,
                pasteToolStripMenuItem,
                refreshToolStripMenuItem};
        }

        public void RefreshListView()
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.sessionInfo.ReloadFolder();
                folderListView.Items.Clear();
                ClientFolder currentFolder = Program.sessionInfo.CurrentFolder;
                if (currentFolder.ChildFolders != null)
                foreach (var folder in currentFolder.ChildFolders)
                {
                    ListViewItem listItem = new ListViewItem(folder);
                    listItem.SubItems.Add("Folder");
                    folderListView.Items.Add(listItem);
                    }
                if (currentFolder.Files != null)
                    foreach (var file in currentFolder.Files)
                {
                    ListViewItem listItem = new ListViewItem(file);
                    listItem.SubItems.Add("File");
                    folderListView.Items.Add(listItem);
                }
                string owner = Program.sessionInfo.CurrentFolder.Owner;
                currentLocationTextBox.Text = owner + ":" + currentFolder.FullPath;
                userTextBox.Text = Program.sessionInfo.CurrentUser.Login;
            }
        }
        public void EnableFolderListView()
        {
            folderListView.Enabled = true;
        }

        #region Forms

        private void LoginToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            folderListView.Enabled = false;
            new LoginForm().Show();
        }
        private void RegisterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            folderListView.Enabled = false;
            new RegisterForm().Show();
            
        }
        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new AboutForm().Show();
        }
        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void UploadFileButton_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var up = Program.sessionInfo.CurrentFolder;
                var user = Program.sessionInfo.CurrentUser;
                var owner = Program.sessionInfo.CurrentFolder.Owner;
                Type type = typeof(ClientFile);
                var uf = new UploadForm(user, owner, up, type);
                uf.Show();
            }
        }
        private void UploadFolderButton_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var up = Program.sessionInfo.CurrentFolder;
                var user = Program.sessionInfo.CurrentUser;
                var owner = Program.sessionInfo.CurrentFolder.Owner;
                Type type = typeof(ClientFolder);
                var uf = new UploadForm(user, owner, up, type);
                uf.Show();
            }
        }

        #endregion

        private void CreateFolderButton_Click(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.cloudConnection.CreateFolder(
                    Program.sessionInfo.CurrentUser,
                    Program.sessionInfo.CurrentFolder.Owner,
                    Program.sessionInfo.CurrentFolder);
                RefreshListView();
            }
        }
        private void FolderListView_DoubleClick(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                string selected = "";
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                    {
                        selected = folderListView.SelectedItems[0].Text;
                        int pos = selected.IndexOf(':');
                        Program.sessionInfo.LoadFolder(selected.Substring(0, pos), selected.Substring(pos + 1));
                    }
                    return;
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    selected = folderListView.SelectedItems[0].Text + "\\";
                }
                Program.sessionInfo.LoadFolder(Program.sessionInfo?.CurrentFolder?.Owner, Program.sessionInfo?.CurrentFolder?.FullPath + selected);
                RefreshListView();
            }
        }
        private void BackButton_Click(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
            {
                Program.sessionInfo.LoadFolder(Program.sessionInfo?.CurrentUser.Login, "root\\");
                RefreshListView();
                return;
            }
            Program.sessionInfo.LoadFolder(Program.sessionInfo?.CurrentFolder?.Owner, Program.sessionInfo?.CurrentFolder?.ParentPath);
            RefreshListView();
        }
        private void FolderListViewContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                FolderListViewContextMenuStrip.Items.Clear();
                if (folderListView.SelectedItems.Count == 0)
                {
                    FolderListViewContextMenuStrip.Items.AddRange(listViewStrip);
                }
                else if (folderListView.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    FolderListViewContextMenuStrip.Items.AddRange(fileOrFolderStrip);
                }
                else if (folderListView.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    FolderListViewContextMenuStrip.Items.AddRange(fileOrFolderStrip);
                }
                else
                {
                    FolderListViewContextMenuStrip.Items.AddRange(listViewStrip);
                }
            }
        }
        private void SharingsButton_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.sessionInfo.LoadShares();
                RefreshListView();
            }
        }

        #region ToolStripMenu

        private void DownloadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                string path;
                string owner;
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    var str = folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    int pos = str.IndexOf(':');
                    path = str.Substring(pos + 1);
                    owner = str.Substring(0, pos);
                }
                else
                {
                    path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    owner = Program.sessionInfo.CurrentFolder.Owner;
                }
                object down = null;
                Type type = null;
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    down = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    type = typeof(ClientFolder);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    down = Program.cloudConnection.GetFile(user, owner, path);
                    type = typeof(ClientFile);
                }
                var df = new DownloadForm(user, owner, down, type);
                df.Show();
            }
        }//fix
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                string path;
                string owner;
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    var str = folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    int pos = str.IndexOf(':');
                    path = str.Substring(pos + 1);
                    owner = str.Substring(0, pos);
                }
                else
                {
                    path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    owner = Program.sessionInfo.CurrentFolder.Owner;
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    var copy = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    Program.sessionInfo.FillBuffer(copy, true);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    var copy = Program.cloudConnection.GetFile(user, owner, path);
                    Program.sessionInfo.FillBuffer(copy, true);
                }
            }
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                string path;
                string owner;
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    var str = folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    int pos = str.IndexOf(':');
                    path = str.Substring(pos + 1);
                    owner = str.Substring(0, pos);
                }
                else
                {
                    path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    owner = Program.sessionInfo.CurrentFolder.Owner;
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    var copy = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    Program.sessionInfo.FillBuffer(copy, false);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    var copy = Program.cloudConnection.GetFile(user, owner, path);
                    Program.sessionInfo.FillBuffer(copy, false);
                }
            }
        }
        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                string path;
                string owner;
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    var str = folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    int pos = str.IndexOf(':');
                    path = str.Substring(pos + 1);
                    owner = str.Substring(0, pos);
                }
                else
                {
                    path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    owner = Program.sessionInfo.CurrentFolder.Owner;
                }
                object rna = null;
                Type type = null;
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    rna = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    type = typeof(ClientFolder);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    rna = Program.cloudConnection.GetFile(user, owner, path);
                    type = typeof(ClientFile);
                }
                var rf = new RenameForm(user, owner, rna, type);
                rf.Show();
            }

        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                string path;
                string owner;
                if (Program.sessionInfo.CurrentFolder.Owner == null && Program.sessionInfo.CurrentFolder.Name == "Sharings")
                {
                    var str = folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    int pos = str.IndexOf(':');
                    path = str.Substring(pos + 1);
                    owner = str.Substring(0, pos);
                }
                else
                {
                    path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                    owner = Program.sessionInfo.CurrentFolder.Owner;
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    var del = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    Program.cloudConnection.DeleteFolder(user, owner, del);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    var del = Program.cloudConnection.GetFile(user, owner, path);
                    Program.cloudConnection.DeleteFile(user, owner, del);
                }
                RefreshListView();
            }
        }
        private void ShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                var user = Program.sessionInfo.CurrentUser;
                var owner = Program.sessionInfo.CurrentFolder.Owner;
                object sha = null;
                Type type = null;
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    sha = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    type = typeof(ClientFolder);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    sha = Program.cloudConnection.GetFile(user, owner, path);
                    type = typeof(ClientFile);
                }
                var ss = new ShareForm(user, owner, sha, type);
                ss.Show();
            }
        }
        private void UnshareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (Program.sessionInfo.CurrentFolder != null)
            //{
            //    var path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
            //    var user = Program.sessionInfo.CurrentUser;
            //    var owner = Program.sessionInfo.CurrentFolder.Owner;
            //    if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
            //    {
            //        var uns = Program.cloudConnection.GetFolder(user, owner, path + "\\");
            //        Program.cloudConnection.UnshareFolder(user, owner, uns, "");
            //    }
            //    if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
            //    {
            //        var uns = Program.cloudConnection.GetFile(user, owner, path);
            //        Program.cloudConnection.UnshareFile(user, owner, uns, "");
            //    }
            //    RefreshListView();
            //}
        }
        private void UnshareAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                var path = Program.sessionInfo.CurrentFolder.FullPath + folderListView?.SelectedItems[0]?.SubItems[0]?.Text;
                var user = Program.sessionInfo.CurrentUser;
                var owner = Program.sessionInfo.CurrentFolder.Owner;
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                {
                    var uns = Program.cloudConnection.GetFolder(user, owner, path + "\\");
                    Program.cloudConnection.UnshareAllFolder(user, owner, uns);
                }
                if (folderListView?.SelectedItems[0]?.SubItems[1]?.Text == "File")
                {
                    var uns = Program.cloudConnection.GetFile(user, owner, path);
                    Program.cloudConnection.UnshareAllFile(user, owner, uns);
                }
                RefreshListView();
            }
        }
        private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFolderButton_Click(sender, e);
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && Program.sessionInfo.Buffer != null)
            {
                var user = Program.sessionInfo.CurrentUser;
                var owner = Program.sessionInfo.CurrentFolder.Owner;
                if (Program.sessionInfo.BufferType.Equals(typeof(ClientFolder)))
                {
                    if (Program.sessionInfo.IsCopy)
                        Program.cloudConnection.CopyFolder(user, owner, (ClientFolder)Program.sessionInfo.Buffer, Program.sessionInfo.CurrentFolder);
                    else
                    {
                        Program.cloudConnection.MoveFolder(user, owner, (ClientFolder)Program.sessionInfo.Buffer, Program.sessionInfo.CurrentFolder);
                        Program.sessionInfo.CleanBuffer();
                    }

                }
                if (Program.sessionInfo.BufferType.Equals(typeof(ClientFile)))
                {
                    if (Program.sessionInfo.IsCopy)
                        Program.cloudConnection.CopyFile(user, owner, (ClientFile)Program.sessionInfo.Buffer, Program.sessionInfo.CurrentFolder);
                    else
                    {
                        Program.cloudConnection.MoveFile(user, owner, (ClientFile)Program.sessionInfo.Buffer, Program.sessionInfo.CurrentFolder);
                        Program.sessionInfo.CleanBuffer();
                    }

                }
                RefreshListView();
            }
        }
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                RefreshListView();
            }
        }
        #endregion

    }
}
