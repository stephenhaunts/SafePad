namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    partial class FindAndReplaceForm
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
            this.textToFind = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.findNextButtton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(358, 86);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // textToFind
            // 
            this.textToFind.Location = new System.Drawing.Point(30, 31);
            this.textToFind.Name = "textToFind";
            this.textToFind.Size = new System.Drawing.Size(239, 20);
            this.textToFind.TabIndex = 1;
            
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(276, 29);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 2;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // findNextButtton
            // 
            this.findNextButtton.Location = new System.Drawing.Point(357, 28);
            this.findNextButtton.Name = "findNextButtton";
            this.findNextButtton.Size = new System.Drawing.Size(75, 23);
            this.findNextButtton.TabIndex = 3;
            this.findNextButtton.Text = "Find Next";
            this.findNextButtton.UseVisualStyleBackColor = true;
            this.findNextButtton.Click += new System.EventHandler(this.findNextButtton_Click);
            // 
            // FindAndReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 121);
            this.ControlBox = false;
            this.Controls.Add(this.findNextButtton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.textToFind);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindAndReplaceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FindAndReplaceForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox textToFind;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button findNextButtton;
    }
}