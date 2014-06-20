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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.passwordLengthTrackBar = new System.Windows.Forms.TrackBar();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.passwordLengthIndicator = new System.Windows.Forms.TextBox();
            this.numberOfAlphaTextBox = new System.Windows.Forms.TextBox();
            this.numberOfAlphaCharactersLabel = new System.Windows.Forms.Label();
            this.numberofAlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.numberNonAlphaCharactersTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numberNonAlphaCharactersTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofAlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberNonAlphaCharactersTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.insertButton.Location = new System.Drawing.Point(265, 279);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(346, 279);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(10, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(411, 20);
            this.textBox1.TabIndex = 2;
            // 
            // passwordLengthTrackBar
            // 
            this.passwordLengthTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordLengthTrackBar.Location = new System.Drawing.Point(35, 79);
            this.passwordLengthTrackBar.Maximum = 64;
            this.passwordLengthTrackBar.Minimum = 8;
            this.passwordLengthTrackBar.Name = "passwordLengthTrackBar";
            this.passwordLengthTrackBar.Size = new System.Drawing.Size(311, 45);
            this.passwordLengthTrackBar.TabIndex = 3;
            this.passwordLengthTrackBar.Value = 8;
            this.passwordLengthTrackBar.ValueChanged += new System.EventHandler(this.passwordLengthTrackBar_ValueChanged);
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(32, 60);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(89, 13);
            this.passwordLengthLabel.TabIndex = 4;
            this.passwordLengthLabel.Text = "Password Length";
            // 
            // passwordLengthIndicator
            // 
            this.passwordLengthIndicator.Location = new System.Drawing.Point(346, 86);
            this.passwordLengthIndicator.Name = "passwordLengthIndicator";
            this.passwordLengthIndicator.ReadOnly = true;
            this.passwordLengthIndicator.Size = new System.Drawing.Size(59, 20);
            this.passwordLengthIndicator.TabIndex = 5;
            // 
            // numberOfAlphaTextBox
            // 
            this.numberOfAlphaTextBox.Location = new System.Drawing.Point(346, 162);
            this.numberOfAlphaTextBox.Name = "numberOfAlphaTextBox";
            this.numberOfAlphaTextBox.ReadOnly = true;
            this.numberOfAlphaTextBox.Size = new System.Drawing.Size(59, 20);
            this.numberOfAlphaTextBox.TabIndex = 8;
            // 
            // numberOfAlphaCharactersLabel
            // 
            this.numberOfAlphaCharactersLabel.AutoSize = true;
            this.numberOfAlphaCharactersLabel.Location = new System.Drawing.Point(32, 136);
            this.numberOfAlphaCharactersLabel.Name = "numberOfAlphaCharactersLabel";
            this.numberOfAlphaCharactersLabel.Size = new System.Drawing.Size(140, 13);
            this.numberOfAlphaCharactersLabel.TabIndex = 7;
            this.numberOfAlphaCharactersLabel.Text = "Number of Alpha Characters";
            // 
            // numberofAlphaTrackBar
            // 
            this.numberofAlphaTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberofAlphaTrackBar.Location = new System.Drawing.Point(35, 155);
            this.numberofAlphaTrackBar.Maximum = 32;
            this.numberofAlphaTrackBar.Minimum = 1;
            this.numberofAlphaTrackBar.Name = "numberofAlphaTrackBar";
            this.numberofAlphaTrackBar.Size = new System.Drawing.Size(311, 45);
            this.numberofAlphaTrackBar.TabIndex = 6;
            this.numberofAlphaTrackBar.Value = 8;
            this.numberofAlphaTrackBar.ValueChanged += new System.EventHandler(this.numberofAlphaTrackBar_ValueChanged);
            // 
            // numberNonAlphaCharactersTextBox
            // 
            this.numberNonAlphaCharactersTextBox.Location = new System.Drawing.Point(346, 229);
            this.numberNonAlphaCharactersTextBox.Name = "numberNonAlphaCharactersTextBox";
            this.numberNonAlphaCharactersTextBox.ReadOnly = true;
            this.numberNonAlphaCharactersTextBox.Size = new System.Drawing.Size(59, 20);
            this.numberNonAlphaCharactersTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Number of Non Alpha-Numeric Characters";
            // 
            // numberNonAlphaCharactersTrackBar
            // 
            this.numberNonAlphaCharactersTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberNonAlphaCharactersTrackBar.Location = new System.Drawing.Point(35, 222);
            this.numberNonAlphaCharactersTrackBar.Maximum = 32;
            this.numberNonAlphaCharactersTrackBar.Minimum = 1;
            this.numberNonAlphaCharactersTrackBar.Name = "numberNonAlphaCharactersTrackBar";
            this.numberNonAlphaCharactersTrackBar.Size = new System.Drawing.Size(311, 45);
            this.numberNonAlphaCharactersTrackBar.TabIndex = 9;
            this.numberNonAlphaCharactersTrackBar.Value = 8;
            this.numberNonAlphaCharactersTrackBar.ValueChanged += new System.EventHandler(this.numberNonAlphaCharactersTrackBar_ValueChanged);
            // 
            // PasswordGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 314);
            this.Controls.Add(this.numberNonAlphaCharactersTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberNonAlphaCharactersTrackBar);
            this.Controls.Add(this.numberOfAlphaTextBox);
            this.Controls.Add(this.numberOfAlphaCharactersLabel);
            this.Controls.Add(this.numberofAlphaTrackBar);
            this.Controls.Add(this.passwordLengthIndicator);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.passwordLengthTrackBar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGeneratorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Password Generator";
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofAlphaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberNonAlphaCharactersTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar passwordLengthTrackBar;
        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.TextBox passwordLengthIndicator;
        private System.Windows.Forms.TextBox numberOfAlphaTextBox;
        private System.Windows.Forms.Label numberOfAlphaCharactersLabel;
        private System.Windows.Forms.TrackBar numberofAlphaTrackBar;
        private System.Windows.Forms.TextBox numberNonAlphaCharactersTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar numberNonAlphaCharactersTrackBar;
    }
}