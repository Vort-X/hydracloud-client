using HydraClassLibrary.ClientEntities;
using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class UploadForm : Form
    {
        private readonly string destination;
        private readonly string type;

        public UploadForm(string destination, string type)
        {
            this.destination = destination;
            this.type = type;
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (type == "folder")
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                pathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
            if (type == "file")
            {
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                pathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (type == "file" && openFileDialog.FileName != "" && openFileDialog.FileName != null)
                Program.sessionInfo.Upload(openFileDialog.FileName, destination);
            else if (type == "folder" && folderBrowserDialog.SelectedPath != "" && folderBrowserDialog.SelectedPath != null)
                Program.sessionInfo.Upload(folderBrowserDialog.SelectedPath, destination);
            else
                MessageBox.Show("Empty path");
            Program.main.RefreshListView();
            Close();
        }
    }
}
