using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class MainForm : Form
    {
        public MainForm(string fileName)
        {
            InitializeComponent();
            Text = String.Format("{0} : {1}", ApplicationName, _documentName);
            Visible = true;
            richTextBox.Visible = true;
            PopulateFontDropDown();         
            LoadDocument(fileName);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            PopulateFontDropDown();
            UpdateFontDropDownWithFontSelection();
            Text = String.Format("{0} : {1}", ApplicationName, _documentName);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            ToolStripManager.SaveSettings(this, "SecureNotePad");            
        }
        
        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void LoadToolStripMenuItemClick(object sender, EventArgs e)
        {
            LoadDocument();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            ToolStripManager.LoadSettings(this, "SecureNotePad");
            richTextBox.ShowSelectionMargin = true;
            
            ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
        }

        private void PrintDocumentBeginPrint(object sender, PrintEventArgs e)
        {
            _charFrom = 0;
        }

        private void PrintToolStripMenuItemClick(object sender, EventArgs e)
        {
           printPreviewDialog.ShowDialog();
        }

        private void PrintToolStripMenuItem1Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void NewDocumentButtonClick(object sender, EventArgs e)
        {
            if (NewDocument(true) == false)
            {
                return;
            }

            richTextBox.Clear();
        }

        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            LoadDocument();
        }

        private void SaveDocumentButtonClick(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void SelectFontToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;
            }
        }

        private void SelectColorToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = colorDialog.Color;
            }
        }

        private void PrintDocumentButtonClick(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void CutToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void CopyToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void PasteToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void CutClick(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void CopyButtonClick(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void PasteButtonClick(object sender, EventArgs e)
        {
            richTextBox.Paste();            
        }

        private void WordWrapToolStripMenuItemClick(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            richTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void RedoToolStripMenuItemClick(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void UndoButtonClick(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void RedoButtonClick(object sender, EventArgs e)
        {
            richTextBox.Redo();                            
        }

        private void BoldButtonClick(object sender, EventArgs e)
        {
            boldButton.Checked = !boldButton.Checked;
            _boldStatus = boldButton.Checked;

            SetSelectionFontType();
        }

        private void ItalicButtonClick(object sender, EventArgs e)
        {
            italicButton.Checked = !italicButton.Checked;
            _italicStatus = italicButton.Checked;

            SetSelectionFontType();
        }

        private void UnderlineButtonClick(object sender, EventArgs e)
        {
            underlineButton.Checked = !underlineButton.Checked;
            _underlineStatus = underlineButton.Checked;

            SetSelectionFontType();
        }

        private void BoldToolStripMenuItemClick(object sender, EventArgs e)
        {
            boldButton.Checked = !boldButton.Checked;
            _boldStatus = boldButton.Checked;

            SetSelectionFontType();
        }

        private void ItalicToolStripMenuItemClick(object sender, EventArgs e)
        {
            italicButton.Checked = !italicButton.Checked;
            _italicStatus = italicButton.Checked;

            SetSelectionFontType();
        }

        private void UnderlineToolStripMenuItemClick(object sender, EventArgs e)
        {
            underlineButton.Checked = !underlineButton.Checked;
            _underlineStatus = underlineButton.Checked;

            SetSelectionFontType();
        } 

        private void SaveToolbarLayoutToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripManager.SaveSettings(this, "SecureNotePad");
        }

        private void LoadToolbarLayoutToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToolStripManager.LoadSettings(this, "SecureNotePad");            
        }

        private void ToolStripButton1Click1(object sender, EventArgs e)
        {
            ToggleBulletSelection();
        }

        private void ToggleBulletSelection()
        {
            bulletButton.Checked = !bulletButton.Checked;
            richTextBox.SelectionBullet = bulletButton.Checked;
            bulletSelectionToolStripMenuItem.Checked = bulletButton.Checked;
            richTextBox.SelectionIndent = 50;
        }

        private void BulletSelectionToolStripMenuItemClick(object sender, EventArgs e)
        {
            ToggleBulletSelection();
        }
        
        private void DecreaseIndentButtonClick(object sender, EventArgs e)
        {
            DecreaseIndent();
        }

        private void IncreaseIndentButtonClick(object sender, EventArgs e)
        {
            IncreaseIndent();
        }      
        
        private void IncreaseIndentToolStripMenuItemClick(object sender, EventArgs e)
        {
            IncreaseIndent();
        }

        private void DecreaseIndentToolStripMenuItemClick(object sender, EventArgs e)
        {
            DecreaseIndent();
        }

        private void LeftJustifyButtonClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Left);
        }

        private void CentreButtonClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Center);
        }

        private void RightJustifyButtonClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Right);
        }

        private void LeftJustifyToolStripMenuItemClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Left);
        }

        private void CentreJustifyToolStripMenuItemClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Center);
        }

        private void RightJustifyToolStripMenuItemClick(object sender, EventArgs e)
        {
            SetAlignment(HorizontalAlignment.Right);
        }

        private void RichTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            Text = String.Format("{0} : *{1}", ApplicationName, _documentName);            
        }

        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            AboutBox();
        }

        private void RichTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void InsertImageToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (insertImageDialog.ShowDialog() != DialogResult.OK) return;

            Clipboard.SetImage(Image.FromFile(insertImageDialog.FileName));
            richTextBox.Paste();
        }

        private void RichTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            UpdateFontStyleButtons();
            UpdateFontDropDownWithFontSelection();
        }

        private void NewDocumentToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (NewDocument(true) == false)
            {
                return;
            }

            richTextBox.Clear();
        }

        private void NewDocumentWindowToolStripMenuItemClick(object sender, EventArgs e)
        {
            NewDocumentWindow();
        }
      
        private void NewDocumentWindowToolStripMenuItem1Click(object sender, EventArgs e)
        {
            NewDocumentWindow();
        }

        private void MainFormActivated(object sender, EventArgs e)
        {
            EnableNotifyIcon(true);
        }

        private void AboutToolStripMenuItem1Click(object sender, EventArgs e)
        {
            AboutBox();
        }

        private void toolStripFontSelector_Click(object sender, EventArgs e)
        {

        } 
    }
}
