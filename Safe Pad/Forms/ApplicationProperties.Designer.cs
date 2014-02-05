namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    partial class ApplicationProperties
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.detectURL = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.General.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(426, 312);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(507, 312);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.General);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(595, 306);
            this.tabControl.TabIndex = 2;
            // 
            // General
            // 
            this.General.Controls.Add(this.detectURL);
            this.General.Location = new System.Drawing.Point(23, 4);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.General.Size = new System.Drawing.Size(568, 298);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.ToolTipText = "General properties";
            this.General.UseVisualStyleBackColor = true;
            // 
            // detectURL
            // 
            this.detectURL.AutoSize = true;
            this.detectURL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.detectURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detectURL.Location = new System.Drawing.Point(16, 14);
            this.detectURL.Name = "detectURL";
            this.detectURL.Size = new System.Drawing.Size(164, 17);
            this.detectURL.TabIndex = 0;
            this.detectURL.Text = "Detect URLs in the document";
            this.detectURL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.detectURL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.detectURL.UseVisualStyleBackColor = true;
            this.detectURL.CheckedChanged += new System.EventHandler(this.detectURL_CheckedChanged);
            // 
            // ApplicationProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(594, 346);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ApplicationProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ApplicationProperties";
            this.tabControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.CheckBox detectURL;
    }
}