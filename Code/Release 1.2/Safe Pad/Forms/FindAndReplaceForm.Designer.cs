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
            this.findNextButtton = new System.Windows.Forms.Button();
            this.findOptionsGroup = new System.Windows.Forms.GroupBox();
            this.matchCaseRadioButton = new System.Windows.Forms.RadioButton();
            this.wholeWordRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.replaceText = new System.Windows.Forms.Button();
            this.textToReplace = new System.Windows.Forms.TextBox();
            this.findOptionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(363, 156);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // textToFind
            // 
            this.textToFind.Location = new System.Drawing.Point(12, 18);
            this.textToFind.Name = "textToFind";
            this.textToFind.Size = new System.Drawing.Size(239, 20);
            this.textToFind.TabIndex = 1;
            this.textToFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textToFind_KeyPress);
            // 
            // findNextButtton
            // 
            this.findNextButtton.Location = new System.Drawing.Point(257, 16);
            this.findNextButtton.Name = "findNextButtton";
            this.findNextButtton.Size = new System.Drawing.Size(75, 23);
            this.findNextButtton.TabIndex = 3;
            this.findNextButtton.Text = "Find Next";
            this.findNextButtton.UseVisualStyleBackColor = true;
            this.findNextButtton.Click += new System.EventHandler(this.findNextButtton_Click);
            // 
            // findOptionsGroup
            // 
            this.findOptionsGroup.Controls.Add(this.matchCaseRadioButton);
            this.findOptionsGroup.Controls.Add(this.wholeWordRadioButton);
            this.findOptionsGroup.Controls.Add(this.noneRadioButton);
            this.findOptionsGroup.Location = new System.Drawing.Point(12, 89);
            this.findOptionsGroup.Name = "findOptionsGroup";
            this.findOptionsGroup.Size = new System.Drawing.Size(426, 57);
            this.findOptionsGroup.TabIndex = 4;
            this.findOptionsGroup.TabStop = false;
            this.findOptionsGroup.Text = "Find Options";
            // 
            // matchCaseRadioButton
            // 
            this.matchCaseRadioButton.AutoSize = true;
            this.matchCaseRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.matchCaseRadioButton.Location = new System.Drawing.Point(182, 23);
            this.matchCaseRadioButton.Name = "matchCaseRadioButton";
            this.matchCaseRadioButton.Size = new System.Drawing.Size(81, 17);
            this.matchCaseRadioButton.TabIndex = 7;
            this.matchCaseRadioButton.Text = "Match Case";
            this.matchCaseRadioButton.UseVisualStyleBackColor = true;
            // 
            // wholeWordRadioButton
            // 
            this.wholeWordRadioButton.AutoSize = true;
            this.wholeWordRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wholeWordRadioButton.Location = new System.Drawing.Point(80, 23);
            this.wholeWordRadioButton.Name = "wholeWordRadioButton";
            this.wholeWordRadioButton.Size = new System.Drawing.Size(86, 17);
            this.wholeWordRadioButton.TabIndex = 6;
            this.wholeWordRadioButton.Text = "Whole World";
            this.wholeWordRadioButton.UseVisualStyleBackColor = true;
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.AutoSize = true;
            this.noneRadioButton.Checked = true;
            this.noneRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noneRadioButton.Location = new System.Drawing.Point(12, 23);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(50, 17);
            this.noneRadioButton.TabIndex = 5;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.Text = "None";
            this.noneRadioButton.UseVisualStyleBackColor = true;
            // 
            // replaceText
            // 
            this.replaceText.Location = new System.Drawing.Point(257, 45);
            this.replaceText.Name = "replaceText";
            this.replaceText.Size = new System.Drawing.Size(75, 23);
            this.replaceText.TabIndex = 4;
            this.replaceText.Text = "Replace Text";
            this.replaceText.UseVisualStyleBackColor = true;
            this.replaceText.Click += new System.EventHandler(this.replaceText_Click);
            // 
            // textToReplace
            // 
            this.textToReplace.Location = new System.Drawing.Point(12, 47);
            this.textToReplace.Name = "textToReplace";
            this.textToReplace.Size = new System.Drawing.Size(239, 20);
            this.textToReplace.TabIndex = 2;
            this.textToReplace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textToReplace_KeyPress);
            // 
            // FindAndReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 191);
            this.ControlBox = false;
            this.Controls.Add(this.replaceText);
            this.Controls.Add(this.textToReplace);
            this.Controls.Add(this.findOptionsGroup);
            this.Controls.Add(this.findNextButtton);
            this.Controls.Add(this.textToFind);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindAndReplaceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find and Replace";
            this.TopMost = true;
            this.findOptionsGroup.ResumeLayout(false);
            this.findOptionsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox textToFind;
        private System.Windows.Forms.Button findNextButtton;
        private System.Windows.Forms.GroupBox findOptionsGroup;
        private System.Windows.Forms.RadioButton matchCaseRadioButton;
        private System.Windows.Forms.RadioButton wholeWordRadioButton;
        private System.Windows.Forms.RadioButton noneRadioButton;
        private System.Windows.Forms.Button replaceText;
        private System.Windows.Forms.TextBox textToReplace;
    }
}