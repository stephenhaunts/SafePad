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
            this.SuspendLayout();
            // 
            // _passwordOne
            // 
            this._passwordOne.Location = new System.Drawing.Point(81, 70);
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
            this._passwordOneLabel.Location = new System.Drawing.Point(81, 51);
            this._passwordOneLabel.Name = "_passwordOneLabel";
            this._passwordOneLabel.Size = new System.Drawing.Size(76, 13);
            this._passwordOneLabel.TabIndex = 1;
            this._passwordOneLabel.Text = "Password One";
            // 
            // _passwordTwoLabel
            // 
            this._passwordTwoLabel.AutoSize = true;
            this._passwordTwoLabel.Location = new System.Drawing.Point(81, 110);
            this._passwordTwoLabel.Name = "_passwordTwoLabel";
            this._passwordTwoLabel.Size = new System.Drawing.Size(125, 13);
            this._passwordTwoLabel.TabIndex = 3;
            this._passwordTwoLabel.Text = "Password Two (Optional)";
            // 
            // _passwordTwo
            // 
            this._passwordTwo.Location = new System.Drawing.Point(81, 126);
            this._passwordTwo.Name = "_passwordTwo";
            this._passwordTwo.PasswordChar = '*';
            this._passwordTwo.Size = new System.Drawing.Size(326, 20);
            this._passwordTwo.TabIndex = 2;
            this._passwordTwo.TextChanged += new System.EventHandler(this._passwordTwo_TextChanged);
            this._passwordTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._passwordTwo_KeyPress);
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(329, 185);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
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
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(410, 185);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // password1Strength
            // 
            this.password1Strength.AutoSize = true;
            this.password1Strength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1Strength.ForeColor = System.Drawing.Color.Red;
            this.password1Strength.Location = new System.Drawing.Point(342, 51);
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
            this.password2Strength.Location = new System.Drawing.Point(342, 110);
            this.password2Strength.Name = "password2Strength";
            this.password2Strength.Size = new System.Drawing.Size(0, 13);
            this.password2Strength.TabIndex = 8;
            this.password2Strength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _password1Keyboard
            // 
            this._password1Keyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._password1Keyboard.Location = new System.Drawing.Point(413, 66);
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
            this._password2Keyboard.Location = new System.Drawing.Point(413, 122);
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
            this._cachePasswordForSession.Location = new System.Drawing.Point(81, 155);
            this._cachePasswordForSession.Name = "_cachePasswordForSession";
            this._cachePasswordForSession.Size = new System.Drawing.Size(161, 17);
            this._cachePasswordForSession.TabIndex = 11;
            this._cachePasswordForSession.Text = "Cache Password for Session";
            this._cachePasswordForSession.UseVisualStyleBackColor = true;            
            // 
            // PasswordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 219);
            this.Controls.Add(this._cachePasswordForSession);
            this.Controls.Add(this._password2Keyboard);
            this.Controls.Add(this._password1Keyboard);
            this.Controls.Add(this.password2Strength);
            this.Controls.Add(this.password1Strength);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._passwordEntryLabel);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._passwordTwoLabel);
            this.Controls.Add(this._passwordTwo);
            this.Controls.Add(this._passwordOneLabel);
            this.Controls.Add(this._passwordOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PasswordEntry";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PasswordEntry";
            this.Load += new System.EventHandler(this.PasswordEntry_Load);
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
    }
}