
namespace HydraClient
{
    partial class UnshareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnshareForm));
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.UnshareButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(12, 32);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(351, 21);
            this.userComboBox.TabIndex = 0;
            // 
            // UnshareButton
            // 
            this.UnshareButton.Location = new System.Drawing.Point(148, 59);
            this.UnshareButton.Name = "UnshareButton";
            this.UnshareButton.Size = new System.Drawing.Size(80, 20);
            this.UnshareButton.TabIndex = 1;
            this.UnshareButton.Text = "Unshare";
            this.UnshareButton.UseVisualStyleBackColor = true;
            this.UnshareButton.Click += new System.EventHandler(this.UnshareButton_Click);
            // 
            // UnshareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 91);
            this.Controls.Add(this.UnshareButton);
            this.Controls.Add(this.userComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnshareForm";
            this.Text = "Unshare";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Button UnshareButton;
    }
}