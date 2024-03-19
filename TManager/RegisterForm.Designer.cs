namespace TManager
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
            userNameLabel = new Label();
            passwordLabel = new Label();
            repeatPasswordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new MaskedTextBox();
            repeatPasswordTextBox = new MaskedTextBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(60, 69);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(60, 15);
            userNameLabel.TabIndex = 0;
            userNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(60, 138);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Password";
            // 
            // repeatPasswordLabel
            // 
            repeatPasswordLabel.AutoSize = true;
            repeatPasswordLabel.Location = new Point(60, 204);
            repeatPasswordLabel.Name = "repeatPasswordLabel";
            repeatPasswordLabel.Size = new Size(96, 15);
            repeatPasswordLabel.TabIndex = 2;
            repeatPasswordLabel.Text = "Repeat password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            usernameTextBox.Location = new Point(164, 61);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(305, 23);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordTextBox.Location = new Point(164, 130);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(249, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // repeatPasswordTextBox
            // 
            repeatPasswordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            repeatPasswordTextBox.Location = new Point(164, 196);
            repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            repeatPasswordTextBox.PasswordChar = '*';
            repeatPasswordTextBox.Size = new Size(249, 23);
            repeatPasswordTextBox.TabIndex = 5;
            // 
            // registerButton
            // 
            registerButton.Anchor = AnchorStyles.Top;
            registerButton.Location = new Point(231, 266);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 6;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // RegisterForm
            // 
            AcceptButton = registerButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 320);
            Controls.Add(registerButton);
            Controls.Add(repeatPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(repeatPasswordLabel);
            Controls.Add(passwordLabel);
            Controls.Add(userNameLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register new user";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userNameLabel;
        private Label passwordLabel;
        private Label repeatPasswordLabel;
        private TextBox usernameTextBox;
        private MaskedTextBox passwordTextBox;
        private MaskedTextBox repeatPasswordTextBox;
        private Button registerButton;
    }
}