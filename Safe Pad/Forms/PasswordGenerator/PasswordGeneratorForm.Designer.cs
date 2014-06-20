namespace HauntedHouseSoftware.SecureNotePad.Forms.PasswordGenerator
{
    partial class PasswordGeneratorForm
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
            this.insertButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.generatedPassword = new System.Windows.Forms.TextBox();
            this.passwordLengthTrackBar = new System.Windows.Forms.TrackBar();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.passwordLengthIndicator = new System.Windows.Forms.TextBox();
            this.singleCase = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.insertButton.Location = new System.Drawing.Point(262, 136);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(343, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // generatedPassword
            // 
            this.generatedPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generatedPassword.Location = new System.Drawing.Point(30, 22);
            this.generatedPassword.Name = "generatedPassword";
            this.generatedPassword.ReadOnly = true;
            this.generatedPassword.Size = new System.Drawing.Size(367, 20);
            this.generatedPassword.TabIndex = 2;
            // 
            // passwordLengthTrackBar
            // 
            this.passwordLengthTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLengthTrackBar.Location = new System.Drawing.Point(30, 79);
            this.passwordLengthTrackBar.Maximum = 64;
            this.passwordLengthTrackBar.Minimum = 8;
            this.passwordLengthTrackBar.Name = "passwordLengthTrackBar";
            this.passwordLengthTrackBar.Size = new System.Drawing.Size(308, 45);
            this.passwordLengthTrackBar.TabIndex = 3;
            this.passwordLengthTrackBar.Value = 8;
            this.passwordLengthTrackBar.ValueChanged += new System.EventHandler(this.passwordLengthTrackBar_ValueChanged);
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(27, 60);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(89, 13);
            this.passwordLengthLabel.TabIndex = 4;
            this.passwordLengthLabel.Text = "Password Length";
            // 
            // passwordLengthIndicator
            // 
            this.passwordLengthIndicator.Location = new System.Drawing.Point(341, 86);
            this.passwordLengthIndicator.Name = "passwordLengthIndicator";
            this.passwordLengthIndicator.ReadOnly = true;
            this.passwordLengthIndicator.Size = new System.Drawing.Size(59, 20);
            this.passwordLengthIndicator.TabIndex = 5;
            // 
            // singleCase
            // 
            this.singleCase.AutoSize = true;
            this.singleCase.Location = new System.Drawing.Point(318, 63);
            this.singleCase.Name = "singleCase";
            this.singleCase.Size = new System.Drawing.Size(82, 17);
            this.singleCase.TabIndex = 6;
            this.singleCase.Text = "Single Case";
            this.singleCase.UseVisualStyleBackColor = true;
            this.singleCase.CheckedChanged += new System.EventHandler(this.singleCase_CheckedChanged);
            // 
            // PasswordGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 171);
            this.Controls.Add(this.singleCase);
            this.Controls.Add(this.passwordLengthIndicator);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.passwordLengthTrackBar);
            this.Controls.Add(this.generatedPassword);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGeneratorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Generator";
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox generatedPassword;
        private System.Windows.Forms.TrackBar passwordLengthTrackBar;
        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.TextBox passwordLengthIndicator;
        private System.Windows.Forms.CheckBox singleCase;
    }
}