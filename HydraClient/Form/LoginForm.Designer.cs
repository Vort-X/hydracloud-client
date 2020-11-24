namespace HydraClient
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.confirmLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 15);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Login";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(71, 12);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(141, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 44);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(53, 13);
            this.passLabel.TabIndex = 2;
            this.passLabel.Text = "Password";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(71, 41);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(141, 20);
            this.passTextBox.TabIndex = 3;
            // 
            // confirmLoginButton
            // 
            this.confirmLoginButton.Location = new System.Drawing.Point(62, 67);
            this.confirmLoginButton.Name = "confirmLoginButton";
            this.confirmLoginButton.Size = new System.Drawing.Size(100, 32);
            this.confirmLoginButton.TabIndex = 4;
            this.confirmLoginButton.Text = "Confirm";
            this.confirmLoginButton.UseVisualStyleBackColor = true;
            this.confirmLoginButton.Click += new System.EventHandler(this.ConfirmLoginButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 111);
            this.Controls.Add(this.confirmLoginButton);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "Authorize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Button confirmLoginButton;
    }
}