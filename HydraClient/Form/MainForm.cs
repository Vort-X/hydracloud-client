﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XmlTcpSerializables;

namespace HydraClient
{
    public partial class MainForm : Form
    {
        private readonly ToolStripItem[] fileOrFolderStrip;
        private readonly ToolStripItem[] listViewStrip;
        private readonly Dictionary<ListViewItem, string> idDictionary;

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

            idDictionary = new Dictionary<ListViewItem, string>();
        }

        public void RefreshListView() //extend SubItems.Add()
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                folderListView.Items.Clear();
                idDictionary.Clear();
                var currentFolder = Program.sessionInfo.CurrentFolder;
                if (currentFolder.childFolders != null)
                    foreach (var folder in currentFolder.childFolders)
                    {
                        ListViewItem listItem = new ListViewItem(folder.name);
                        listItem.SubItems.Add("Folder");
                        listItem.SubItems.Add(folder.owner);
                        listItem.SubItems.Add(folder.time.ToString());
                        folderListView.Items.Add(listItem);
                        idDictionary.Add(listItem, folder.guid);
                    }
                if (currentFolder.files != null)
                    foreach (var file in currentFolder.files)
                    {
                        ListViewItem listItem = new ListViewItem(file.name);
                        listItem.SubItems.Add("File");
                        listItem.SubItems.Add(file.owner);
                        listItem.SubItems.Add(file.time.ToString());
                        folderListView.Items.Add(listItem);
                        idDictionary.Add(listItem, file.guid);
                    }
                string owner = Program.sessionInfo.CurrentFolder.data.owner;
                currentLocationTextBox.Text = owner + ":" + currentFolder.data.name;
                userTextBox.Text = Program.sessionInfo.Login;
            }
        }

        #region Forms
        private void LoginToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            new LoginForm().Show();
        }
        private void RegisterToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
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
                if (UploadFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                Program.sessionInfo.Upload(UploadFileDialog.FileName, Program.sessionInfo.CurrentFolder.data.guid, false);
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }
        private void UploadFolderButton_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                if (UploadFolderDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                Program.sessionInfo.Upload(UploadFolderDialog.SelectedPath, Program.sessionInfo.CurrentFolder.data.guid, true);
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }
        #endregion

        private void CreateFolderButton_Click(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.sessionInfo.CreateFolder();
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }
        private void FolderListView_DoubleClick(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
            {
                Program.sessionInfo.LoadFolder(idDictionary[folderListView.SelectedItems[0]]);
                RefreshListView();
            }
        }
        private void BackButton_Click(object sender, System.EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                if (Program.sessionInfo.CurrentFolder.data.parentId == Guid.Empty.ToString())
                    Program.sessionInfo.LoadSharings();
                else
                    Program.sessionInfo.LoadFolder(Program.sessionInfo.CurrentFolder.data.parentId);
                RefreshListView();
            }
        }
        private void FolderListViewContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                FolderListViewContextMenuStrip.Items.Clear();
                if (folderListView.SelectedItems.Count == 0)
                    FolderListViewContextMenuStrip.Items.AddRange(listViewStrip);
                else if (folderListView.SelectedItems[0]?.SubItems[1]?.Text == "Folder")
                    FolderListViewContextMenuStrip.Items.AddRange(fileOrFolderStrip);
                else if (folderListView.SelectedItems[0]?.SubItems[1]?.Text == "File")
                    FolderListViewContextMenuStrip.Items.AddRange(fileOrFolderStrip);
                else
                    FolderListViewContextMenuStrip.Items.AddRange(listViewStrip);
            }
        }
        private void SharingsButton_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.sessionInfo.LoadSharings();
                RefreshListView();
            }
        }

        #region ToolStripMenu

        private void DownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
            {
                downloadDialog.FileName = folderListView.SelectedItems[0].Text;
                if (downloadDialog.ShowDialog() == DialogResult.OK)
                {
                    if (downloadDialog.FileName != null && downloadDialog.FileName != "")
                    {
                        Program.sessionInfo.Download(idDictionary[folderListView.SelectedItems[0]], downloadDialog.FileName);
                        Program.sessionInfo.ReloadFolder();
                        RefreshListView();
                    }
                    else
                        MessageBox.Show("Empty path");
                }
            }
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
                Program.sessionInfo.FillBuffer(idDictionary[folderListView.SelectedItems[0]], true);
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
                Program.sessionInfo.FillBuffer(idDictionary[folderListView.SelectedItems[0]], false);
        }
        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
            {
                new RenameForm(idDictionary[folderListView.SelectedItems[0]]).Show();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
            {
                Program.sessionInfo.Delete(idDictionary[folderListView.SelectedItems[0]]);
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }
        private void ShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
                new ShareForm(idDictionary[folderListView.SelectedItems[0]]).Show();
        }
        private void UnshareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
            {
                string target = idDictionary[folderListView.SelectedItems[0]];
                string[] users = null;
                if (folderListView.SelectedItems[0].SubItems[1].Text == "Folder")
                {
                    users = new List<Metadata>(Program.sessionInfo.CurrentFolder.childFolders).Where(f => f.guid == target)
                        .Select(f => f.usersWithAccess).FirstOrDefault().ToArray();
                }
                else if (folderListView.SelectedItems[0].SubItems[1].Text == "File")
                {
                    users = new List<Metadata>(Program.sessionInfo.CurrentFolder.files).Where(f => f.guid == target)
                        .Select(f => f.usersWithAccess).FirstOrDefault().ToArray();
                }
                else
                {
                    return;
                }
                new UnshareForm(target, users).Show();
            }
        }
        private void UnshareAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && folderListView.SelectedItems.Count == 1)
                Program.sessionInfo.UnshareAll(idDictionary[folderListView.SelectedItems[0]]);
        }
        private void CreateFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFolderButton_Click(sender, e);
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null && Program.sessionInfo.BufferId != null)
            {
                if (Program.sessionInfo.IsCopy) 
                    Program.sessionInfo.Copy();
                else 
                    Program.sessionInfo.Move();
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.sessionInfo.CurrentFolder != null)
            {
                Program.sessionInfo.ReloadFolder();
                RefreshListView();
            }
        }

        #endregion

    }
}
