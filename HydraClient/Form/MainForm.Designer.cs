namespace HydraClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FolderListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unshareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unshareAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderButton = new System.Windows.Forms.Button();
            this.currentLocationTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.uploadFolderButton = new System.Windows.Forms.Button();
            this.sharingsButton = new System.Windows.Forms.Button();
            this.downloadDialog = new System.Windows.Forms.SaveFileDialog();
            this.UploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UploadFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip.SuspendLayout();
            this.FolderListViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // folderListView
            // 
            this.folderListView.AllowColumnReorder = true;
            this.folderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader});
            this.folderListView.ContextMenuStrip = this.FolderListViewContextMenuStrip;
            this.folderListView.HideSelection = false;
            this.folderListView.Location = new System.Drawing.Point(12, 53);
            this.folderListView.MultiSelect = false;
            this.folderListView.Name = "folderListView";
            this.folderListView.Size = new System.Drawing.Size(600, 340);
            this.folderListView.TabIndex = 1;
            this.folderListView.UseCompatibleStateImageBehavior = false;
            this.folderListView.View = System.Windows.Forms.View.Details;
            this.folderListView.DoubleClick += new System.EventHandler(this.FolderListView_DoubleClick);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 187;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            // 
            // FolderListViewContextMenuStrip
            // 
            this.FolderListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.shareToolStripMenuItem,
            this.unshareToolStripMenuItem,
            this.unshareAllToolStripMenuItem,
            this.createFolderToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.FolderListViewContextMenuStrip.Name = "FolderListViewContextMenuStrip";
            this.FolderListViewContextMenuStrip.Size = new System.Drawing.Size(181, 268);
            this.FolderListViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FolderListViewContextMenuStrip_Opening);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shareToolStripMenuItem.Text = "Share";
            this.shareToolStripMenuItem.Click += new System.EventHandler(this.ShareToolStripMenuItem_Click);
            // 
            // unshareToolStripMenuItem
            // 
            this.unshareToolStripMenuItem.Name = "unshareToolStripMenuItem";
            this.unshareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unshareToolStripMenuItem.Text = "Unshare";
            this.unshareToolStripMenuItem.Click += new System.EventHandler(this.UnshareToolStripMenuItem_Click);
            // 
            // unshareAllToolStripMenuItem
            // 
            this.unshareAllToolStripMenuItem.Name = "unshareAllToolStripMenuItem";
            this.unshareAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unshareAllToolStripMenuItem.Text = "Unshare all";
            this.unshareAllToolStripMenuItem.Click += new System.EventHandler(this.UnshareAllToolStripMenuItem_Click);
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createFolderToolStripMenuItem.Text = "Create folder";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.CreateFolderToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // createFolderButton
            // 
            this.createFolderButton.Location = new System.Drawing.Point(12, 399);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(118, 30);
            this.createFolderButton.TabIndex = 2;
            this.createFolderButton.Text = "Create Folder";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.CreateFolderButton_Click);
            // 
            // currentLocationTextBox
            // 
            this.currentLocationTextBox.Location = new System.Drawing.Point(124, 27);
            this.currentLocationTextBox.Name = "currentLocationTextBox";
            this.currentLocationTextBox.Size = new System.Drawing.Size(440, 20);
            this.currentLocationTextBox.TabIndex = 4;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(12, 27);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.ReadOnly = true;
            this.userTextBox.Size = new System.Drawing.Size(106, 20);
            this.userTextBox.TabIndex = 5;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(570, 27);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(42, 20);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Location = new System.Drawing.Point(136, 399);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(118, 30);
            this.uploadFileButton.TabIndex = 2;
            this.uploadFileButton.Text = "Upload File";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.UploadFileButton_Click);
            // 
            // uploadFolderButton
            // 
            this.uploadFolderButton.Location = new System.Drawing.Point(260, 399);
            this.uploadFolderButton.Name = "uploadFolderButton";
            this.uploadFolderButton.Size = new System.Drawing.Size(118, 30);
            this.uploadFolderButton.TabIndex = 7;
            this.uploadFolderButton.Text = "Upload Folder";
            this.uploadFolderButton.UseVisualStyleBackColor = true;
            this.uploadFolderButton.Click += new System.EventHandler(this.UploadFolderButton_Click);
            // 
            // sharingsButton
            // 
            this.sharingsButton.Location = new System.Drawing.Point(384, 399);
            this.sharingsButton.Name = "sharingsButton";
            this.sharingsButton.Size = new System.Drawing.Size(118, 30);
            this.sharingsButton.TabIndex = 8;
            this.sharingsButton.Text = "Sharings";
            this.sharingsButton.UseVisualStyleBackColor = true;
            this.sharingsButton.Click += new System.EventHandler(this.SharingsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.sharingsButton);
            this.Controls.Add(this.uploadFolderButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.currentLocationTextBox);
            this.Controls.Add(this.uploadFileButton);
            this.Controls.Add(this.createFolderButton);
            this.Controls.Add(this.folderListView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Hydra v1.0";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.FolderListViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView folderListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.Button createFolderButton;
        private System.Windows.Forms.TextBox currentLocationTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ContextMenuStrip FolderListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unshareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Button uploadFolderButton;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unshareAllToolStripMenuItem;
        private System.Windows.Forms.Button sharingsButton;
        private System.Windows.Forms.SaveFileDialog downloadDialog;
        private System.Windows.Forms.OpenFileDialog UploadFileDialog;
        private System.Windows.Forms.FolderBrowserDialog UploadFolderDialog;
    }
}

