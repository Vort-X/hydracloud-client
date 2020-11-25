using System;
using System.Windows.Forms;

namespace HydraClient
{
    public partial class RenameForm : Form
    {
        private readonly string renameTarget;

        public RenameForm(string renameTarget)
        {
            this.renameTarget = renameTarget;
            InitializeComponent();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            Program.sessionInfo.Rename(renameTarget, renameTextBox.Text);
            Program.main.RefreshListView();
            Close();
        }
    }
}
