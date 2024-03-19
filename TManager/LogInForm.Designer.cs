namespace TManager
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            registerLink = new LinkLabel();
            loginButton = new Button();
            passwordTextBox = new MaskedTextBox();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            userNameLabel = new Label();
            SuspendLayout();
            // 
            // registerLink
            // 
            registerLink.AutoSize = true;
            registerLink.Location = new Point(75, 249);
            registerLink.Name = "registerLink";
            registerLink.Size = new Size(108, 21);
            registerLink.TabIndex = 15;
            registerLink.TabStop = true;
            registerLink.Text = "New user? Register";
            registerLink.UseCompatibleTextRendering = true;
            registerLink.LinkClicked += registerLink_LinkClicked;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top;
            loginButton.Location = new Point(232, 200);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 14;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextBox.Location = new Point(179, 126);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(226, 23);
            passwordTextBox.TabIndex = 12;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            usernameTextBox.Location = new Point(179, 57);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(226, 23);
            usernameTextBox.TabIndex = 11;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(75, 134);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 9;
            passwordLabel.Text = "Password";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(75, 65);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(60, 15);
            userNameLabel.TabIndex = 8;
            userNameLabel.Text = "Username";
            // 
            // LogInForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 320);
            Controls.Add(registerLink);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(userNameLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LogInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel registerLink;
        private Button loginButton;
        private MaskedTextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private Label userNameLabel;
    }
}