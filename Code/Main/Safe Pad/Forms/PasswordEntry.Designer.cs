namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    partial class PasswordEntry
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
            this._passwordOne = new System.Windows.Forms.TextBox();
            this._passwordOneLabel = new System.Windows.Forms.Label();
            this._passwordTwoLabel = new System.Windows.Forms.Label();
            this._passwordTwo = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._passwordEntryLabel = new System.Windows.Forms.Label();
            this._cancelButton = new System.Windows.Forms.Button();
            this.password1Strength = new System.Windows.Forms.Label();
            this.password2Strength = new System.Windows.Forms.Label();
            this._password1Keyboard = new System.Windows.Forms.Button();
            this._password2Keyboard = new System.Windows.Forms.Button();
            this._cachePasswordForSession = new System.Windows.Forms.CheckBox();
            this.passwordTabControl = new System.Windows.Forms.TabControl();
            this.passwordTabPage = new System.Windows.Forms.TabPage();
            this.keyFileTabPage = new System.Windows.Forms.TabPage();
            this.useKeyFile = new System.Windows.Forms.CheckBox();
            this.keyfileName = new System.Windows.Forms.TextBox();
            this.keyFileLabel = new System.Windows.Forms.Label();
            this.selectKeyFile = new System.Windows.Forms.Button();
            this.selectKeyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.passwordTabControl.SuspendLayout();
            this.passwordTabPage.SuspendLayout();
            this.keyFileTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _passwordOne
            // 
            this._passwordOne.Location = new System.Drawing.Point(6, 26);
            this._passwordOne.Name = "_passwordOne";
            this._passwordOne.PasswordChar = '*';
            this._passwordOne.Size = new System.Drawing.Size(326, 20);
            this._passwordOne.TabIndex = 0;
            this._passwordOne.TextChanged += new System.EventHandler(this._passwordOne_TextChanged);
            this._passwordOne.KeyDown += new System.Windows.Forms.KeyEventHandler(this._passwordOne_KeyDown);
            this._passwordOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._passwordOne_KeyPress);
            // 
            // _passwordOneLabel
            // 
            this._passwordOneLabel.AutoSize = true;
            this._passwordOneLabel.Location = new System.Drawing.Point(6, 7);
            this._passwordOneLabel.Name = "_passwordOneLabel";
            this._passwordOneLabel.Size = new System.Drawing.Size(76, 13);
            this._passwordOneLabel.TabIndex = 4;
            this._passwordOneLabel.Text = "Password One";
            // 
            // _passwordTwoLabel
            // 
            this._passwordTwoLabel.AutoSize = true;
            this._passwordTwoLabel.Location = new System.Drawing.Point(6, 66);
            this._passwordTwoLabel.Name = "_passwordTwoLabel";
            this._passwordTwoLabel.Size = new System.Drawing.Size(125, 13);
            this._passwordTwoLabel.TabIndex = 3;
            this._passwordTwoLabel.Text = "Password Two (Optional)";
            // 
            // _passwordTwo
            // 
            this._passwordTwo.Location = new System.Drawing.Point(6, 82);
            this._passwordTwo.Name = "_passwordTwo";
            this._passwordTwo.PasswordChar = '*';
            this._passwordTwo.Size = new System.Drawing.Size(326, 20);
            this._passwordTwo.TabIndex = 1;
            this._passwordTwo.TextChanged += new System.EventHandler(this._passwordTwo_TextChanged);
            this._passwordTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._passwordTwo_KeyPress);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(288, 241);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 3;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // _passwordEntryLabel
            // 
            this._passwordEntryLabel.AutoSize = true;
            this._passwordEntryLabel.Location = new System.Drawing.Point(19, 21);
            this._passwordEntryLabel.Name = "_passwordEntryLabel";
            this._passwordEntryLabel.Size = new System.Drawing.Size(195, 13);
            this._passwordEntryLabel.TabIndex = 5;
            this._passwordEntryLabel.Text = "Please enter your document passwords.";
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(369, 241);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // password1Strength
            // 
            this.password1Strength.AutoSize = true;
            this.password1Strength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1Strength.ForeColor = System.Drawing.Color.Red;
            this.password1Strength.Location = new System.Drawing.Point(267, 7);
            this.password1Strength.Name = "password1Strength";
            this.password1Strength.Size = new System.Drawing.Size(0, 13);
            this.password1Strength.TabIndex = 7;
            this.password1Strength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // password2Strength
            // 
            this.password2Strength.AutoSize = true;
            this.password2Strength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2Strength.ForeColor = System.Drawing.Color.Red;
            this.password2Strength.Location = new System.Drawing.Point(267, 66);
            this.password2Strength.Name = "password2Strength";
            this.password2Strength.Size = new System.Drawing.Size(0, 13);
            this.password2Strength.TabIndex = 8;
            this.password2Strength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _password1Keyboard
            // 
            this._password1Keyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._password1Keyboard.Location = new System.Drawing.Point(338, 22);
            this._password1Keyboard.Name = "_password1Keyboard";
            this._password1Keyboard.Size = new System.Drawing.Size(32, 24);
            this._password1Keyboard.TabIndex = 9;
            this._password1Keyboard.Text = "...";
            this._password1Keyboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._password1Keyboard.UseVisualStyleBackColor = true;
            this._password1Keyboard.Click += new System.EventHandler(this._password1Keyboard_Click);
            // 
            // _password2Keyboard
            // 
            this._password2Keyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._password2Keyboard.Location = new System.Drawing.Point(338, 78);
            this._password2Keyboard.Name = "_password2Keyboard";
            this._password2Keyboard.Size = new System.Drawing.Size(32, 24);
            this._password2Keyboard.TabIndex = 10;
            this._password2Keyboard.Text = "...";
            this._password2Keyboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this._password2Keyboard.UseVisualStyleBackColor = true;
            this._password2Keyboard.Click += new System.EventHandler(this._password2Keyboard_Click);
            // 
            // _cachePasswordForSession
            // 
            this._cachePasswordForSession.AutoSize = true;
            this._cachePasswordForSession.Location = new System.Drawing.Point(6, 111);
            this._cachePasswordForSession.Name = "_cachePasswordForSession";
            this._cachePasswordForSession.Size = new System.Drawing.Size(161, 17);
            this._cachePasswordForSession.TabIndex = 2;
            this._cachePasswordForSession.Text = "Cache Password for Session";
            this._cachePasswordForSession.UseVisualStyleBackColor = true;
            // 
            // passwordTabControl
            // 
            this.passwordTabControl.Controls.Add(this.passwordTabPage);
            this.passwordTabControl.Controls.Add(this.keyFileTabPage);
            this.passwordTabControl.Location = new System.Drawing.Point(22, 47);
            this.passwordTabControl.Name = "passwordTabControl";
            this.passwordTabControl.SelectedIndex = 0;
            this.passwordTabControl.Size = new System.Drawing.Size(425, 181);
            this.passwordTabControl.TabIndex = 11;
            // 
            // passwordTabPage
            // 
            this.passwordTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTabPage.Controls.Add(this.useKeyFile);
            this.passwordTabPage.Controls.Add(this._passwordOne);
            this.passwordTabPage.Controls.Add(this._cachePasswordForSession);
            this.passwordTabPage.Controls.Add(this._passwordOneLabel);
            this.passwordTabPage.Controls.Add(this._password2Keyboard);
            this.passwordTabPage.Controls.Add(this._passwordTwo);
            this.passwordTabPage.Controls.Add(this._password1Keyboard);
            this.passwordTabPage.Controls.Add(this._passwordTwoLabel);
            this.passwordTabPage.Controls.Add(this.password2Strength);
            this.passwordTabPage.Controls.Add(this.password1Strength);
            this.passwordTabPage.Location = new System.Drawing.Point(4, 22);
            this.passwordTabPage.Name = "passwordTabPage";
            this.passwordTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.passwordTabPage.Size = new System.Drawing.Size(417, 155);
            this.passwordTabPage.TabIndex = 0;
            this.passwordTabPage.Text = "Password";
            // 
            // keyFileTabPage
            // 
            this.keyFileTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.keyFileTabPage.Controls.Add(this.keyfileName);
            this.keyFileTabPage.Controls.Add(this.keyFileLabel);
            this.keyFileTabPage.Controls.Add(this.selectKeyFile);
            this.keyFileTabPage.Location = new System.Drawing.Point(4, 22);
            this.keyFileTabPage.Name = "keyFileTabPage";
            this.keyFileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.keyFileTabPage.Size = new System.Drawing.Size(417, 155);
            this.keyFileTabPage.TabIndex = 1;
            this.keyFileTabPage.Text = "KeyFile";
            // 
            // useKeyFile
            // 
            this.useKeyFile.AutoSize = true;
            this.useKeyFile.Location = new System.Drawing.Point(6, 132);
            this.useKeyFile.Name = "useKeyFile";
            this.useKeyFile.Size = new System.Drawing.Size(85, 17);
            this.useKeyFile.TabIndex = 11;
            this.useKeyFile.Text = "Use Key File";
            this.useKeyFile.UseVisualStyleBackColor = true;
            this.useKeyFile.CheckedChanged += new System.EventHandler(this.useKeyFile_CheckedChanged);
            // 
            // keyfileName
            // 
            this.keyfileName.Location = new System.Drawing.Point(16, 31);
            this.keyfileName.Name = "keyfileName";
            this.keyfileName.PasswordChar = '*';
            this.keyfileName.ReadOnly = true;
            this.keyfileName.Size = new System.Drawing.Size(326, 20);
            this.keyfileName.TabIndex = 10;
            // 
            // keyFileLabel
            // 
            this.keyFileLabel.AutoSize = true;
            this.keyFileLabel.Location = new System.Drawing.Point(16, 12);
            this.keyFileLabel.Name = "keyFileLabel";
            this.keyFileLabel.Size = new System.Drawing.Size(44, 13);
            this.keyFileLabel.TabIndex = 11;
            this.keyFileLabel.Text = "Key File";
            // 
            // selectKeyFile
            // 
            this.selectKeyFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectKeyFile.Location = new System.Drawing.Point(348, 27);
            this.selectKeyFile.Name = "selectKeyFile";
            this.selectKeyFile.Size = new System.Drawing.Size(32, 24);
            this.selectKeyFile.TabIndex = 12;
            this.selectKeyFile.Text = "...";
            this.selectKeyFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.selectKeyFile.UseVisualStyleBackColor = true;
            this.selectKeyFile.Click += new System.EventHandler(this.selectKeyFile_Click);
            // 
            // selectKeyFileDialog
            // 
            this.selectKeyFileDialog.Filter = "All Files|*.*";
            this.selectKeyFileDialog.Title = "Select Key File";
            // 
            // PasswordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 276);
            this.Controls.Add(this.passwordTabControl);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._passwordEntryLabel);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PasswordEntry";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Entry";
            this.Load += new System.EventHandler(this.PasswordEntry_Load);
            this.passwordTabControl.ResumeLayout(false);
            this.passwordTabPage.ResumeLayout(false);
            this.passwordTabPage.PerformLayout();
            this.keyFileTabPage.ResumeLayout(false);
            this.keyFileTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _passwordOne;
        private System.Windows.Forms.Label _passwordOneLabel;
        private System.Windows.Forms.Label _passwordTwoLabel;
        private System.Windows.Forms.TextBox _passwordTwo;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label _passwordEntryLabel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label password1Strength;
        private System.Windows.Forms.Label password2Strength;
        private System.Windows.Forms.Button _password1Keyboard;
        private System.Windows.Forms.Button _password2Keyboard;
        private System.Windows.Forms.CheckBox _cachePasswordForSession;
        private System.Windows.Forms.TabControl passwordTabControl;
        private System.Windows.Forms.TabPage passwordTabPage;
        private System.Windows.Forms.TabPage keyFileTabPage;
        private System.Windows.Forms.CheckBox useKeyFile;
        private System.Windows.Forms.TextBox keyfileName;
        private System.Windows.Forms.Label keyFileLabel;
        private System.Windows.Forms.Button selectKeyFile;
        private System.Windows.Forms.OpenFileDialog selectKeyFileDialog;
    }
}