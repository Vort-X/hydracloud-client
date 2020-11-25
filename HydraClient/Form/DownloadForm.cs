using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class DownloadForm : Form
    {
        private readonly string source;

        public DownloadForm(string source)
        {
            this.source = source;
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
                Program.sessionInfo.Download(source, folderBrowserDialog.SelectedPath);
            }
            Close();
        }
    }
}
