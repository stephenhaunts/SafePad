namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    partial class AboutDialogBox
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
            this.aboutBoxOkButton = new System.Windows.Forms.Button();
            this.aboutBoxNameLabel = new System.Windows.Forms.Label();
            this.aboutBoxVersionLabel = new System.Windows.Forms.Label();
            this.aboutBoxLicenseName = new System.Windows.Forms.Label();
            this.aboutBoxLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutBoxOkButton
            // 
            this.aboutBoxOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aboutBoxOkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.aboutBoxOkButton.Location = new System.Drawing.Point(417, 284);
            this.aboutBoxOkButton.Name = "aboutBoxOkButton";
            this.aboutBoxOkButton.Size = new System.Drawing.Size(75, 23);
            this.aboutBoxOkButton.TabIndex = 0;
            this.aboutBoxOkButton.Text = "Ok";
            this.aboutBoxOkButton.UseVisualStyleBackColor = true;
            // 
            // aboutBoxNameLabel
            // 
            this.aboutBoxNameLabel.AutoSize = true;
            this.aboutBoxNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBoxNameLabel.Location = new System.Drawing.Point(152, 19);
            this.aboutBoxNameLabel.Name = "aboutBoxNameLabel";
            this.aboutBoxNameLabel.Size = new System.Drawing.Size(309, 75);
            this.aboutBoxNameLabel.TabIndex = 1;
            this.aboutBoxNameLabel.Text = "Safe Pad";
            // 
            // aboutBoxVersionLabel
            // 
            this.aboutBoxVersionLabel.AutoSize = true;
            this.aboutBoxVersionLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBoxVersionLabel.Location = new System.Drawing.Point(241, 94);
            this.aboutBoxVersionLabel.Name = "aboutBoxVersionLabel";
            this.aboutBoxVersionLabel.Size = new System.Drawing.Size(112, 22);
            this.aboutBoxVersionLabel.TabIndex = 2;
            this.aboutBoxVersionLabel.Text = "Version 1.2";
            // 
            // aboutBoxLicenseName
            // 
            this.aboutBoxLicenseName.AutoSize = true;
            this.aboutBoxLicenseName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBoxLicenseName.Location = new System.Drawing.Point(121, 191);
            this.aboutBoxLicenseName.Name = "aboutBoxLicenseName";
            this.aboutBoxLicenseName.Size = new System.Drawing.Size(361, 23);
            this.aboutBoxLicenseName.TabIndex = 3;
            this.aboutBoxLicenseName.Text = "Released under GNU Public License";
            this.aboutBoxLicenseName.Click += new System.EventHandler(this.aboutBoxLicenseName_Click);
            // 
            // aboutBoxLinkLabel
            // 
            this.aboutBoxLinkLabel.AutoSize = true;
            this.aboutBoxLinkLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBoxLinkLabel.Location = new System.Drawing.Point(143, 153);
            this.aboutBoxLinkLabel.Name = "aboutBoxLinkLabel";
            this.aboutBoxLinkLabel.Size = new System.Drawing.Size(327, 17);
            this.aboutBoxLinkLabel.TabIndex = 4;
            this.aboutBoxLinkLabel.TabStop = true;
            this.aboutBoxLinkLabel.Text = "http://stephenhaunts.com/projects/safe-pad/";
            this.aboutBoxLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutBoxLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HauntedHouseSoftware.SecureNotePad.Properties.Resources.PadlockIcon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 106);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // AboutDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 319);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.aboutBoxLinkLabel);
            this.Controls.Add(this.aboutBoxLicenseName);
            this.Controls.Add(this.aboutBoxVersionLabel);
            this.Controls.Add(this.aboutBoxNameLabel);
            this.Controls.Add(this.aboutBoxOkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Safe Pad";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aboutBoxOkButton;
        private System.Windows.Forms.Label aboutBoxNameLabel;
        private System.Windows.Forms.Label aboutBoxVersionLabel;
        private System.Windows.Forms.Label aboutBoxLicenseName;
        private System.Windows.Forms.LinkLabel aboutBoxLinkLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}