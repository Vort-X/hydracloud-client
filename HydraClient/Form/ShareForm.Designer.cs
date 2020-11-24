namespace HydraClient
{
    partial class ShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareForm));
            this.shareTextBox = new System.Windows.Forms.TextBox();
            this.shareButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shareTextBox
            // 
            this.shareTextBox.Location = new System.Drawing.Point(12, 33);
            this.shareTextBox.Name = "shareTextBox";
            this.shareTextBox.Size = new System.Drawing.Size(351, 20);
            this.shareTextBox.TabIndex = 2;
            // 
            // shareButton
            // 
            this.shareButton.Location = new System.Drawing.Point(150, 59);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(80, 20);
            this.shareButton.TabIndex = 4;
            this.shareButton.Text = "Share";
            this.shareButton.UseVisualStyleBackColor = true;
            this.shareButton.Click += new System.EventHandler(this.ShareButton_Click);
            // 
            // ShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 91);
            this.Controls.Add(this.shareButton);
            this.Controls.Add(this.shareTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShareForm";
            this.Text = "Share to";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shareTextBox;
        private System.Windows.Forms.Button shareButton;
    }
}