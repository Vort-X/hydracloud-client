namespace HydraClient
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.confpassTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.confpassLabel = new System.Windows.Forms.Label();
            this.fillLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(108, 29);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(153, 20);
            this.loginTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(108, 55);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(153, 20);
            this.emailTextBox.TabIndex = 1;
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(108, 81);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(153, 20);
            this.passTextBox.TabIndex = 2;
            // 
            // confpassTextBox
            // 
            this.confpassTextBox.Location = new System.Drawing.Point(108, 107);
            this.confpassTextBox.Name = "confpassTextBox";
            this.confpassTextBox.PasswordChar = '*';
            this.confpassTextBox.Size = new System.Drawing.Size(153, 20);
            this.confpassTextBox.TabIndex = 3;
            // 
            // registerButton
            // 
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.registerButton.Location = new System.Drawing.Point(82, 133);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(110, 36);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(12, 32);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 5;
            this.loginLabel.Text = "Login";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 58);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "E-mail";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 84);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(53, 13);
            this.passLabel.TabIndex = 5;
            this.passLabel.Text = "Password";
            // 
            // confpassLabel
            // 
            this.confpassLabel.AutoSize = true;
            this.confpassLabel.Location = new System.Drawing.Point(12, 110);
            this.confpassLabel.Name = "confpassLabel";
            this.confpassLabel.Size = new System.Drawing.Size(90, 13);
            this.confpassLabel.TabIndex = 5;
            this.confpassLabel.Text = "Confirm password";
            // 
            // fillLabel
            // 
            this.fillLabel.AutoSize = true;
            this.fillLabel.Location = new System.Drawing.Point(12, 9);
            this.fillLabel.Name = "fillLabel";
            this.fillLabel.Size = new System.Drawing.Size(117, 13);
            this.fillLabel.TabIndex = 5;
            this.fillLabel.Text = "Fill the registration form:";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 181);
            this.Controls.Add(this.fillLabel);
            this.Controls.Add(this.confpassLabel);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.confpassTextBox);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox confpassTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label confpassLabel;
        private System.Windows.Forms.Label fillLabel;
    }
}