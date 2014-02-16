/**
 * Safe Pad, a double encrypted note pad that uses 2 passwords to protect your documents and help you keep your privacy.
 * 
 * Copyright (C) 2014 Stephen Haunts
 * http://www.stephenhaunts.com
 * 
 * This file is part of Safe Pad.
 * 
 * Safe Pad is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 2 of the
 * License, or (at your option) any later version.
 * 
 * Safe Pad is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * 
 * See the GNU General Public License for more details <http://www.gnu.org/licenses/>.
 * 
 * Authors: Stephen Haunts
 */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HauntedHouseSoftware.SecureNotePad.Properties;
using System.Drawing.Printing;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class MainForm
    {
        private IDocument _currentDocument;
        private int _charFrom;
        private bool _passwordSet;
        private int _indent;
        private bool _boldStatus;
        private bool _italicStatus;
        private bool _underlineStatus;
        private bool _documentChanged;
        
        private const string ApplicationName = "Safe Pad";
        private string _documentName = "";

        private ApplicationSettings _settings = new ApplicationSettings();

        private void SaveDocument()
        {
            MemoryStream userInput = null;

            try
            {
                if (_documentChanged == true || string.IsNullOrEmpty(_documentName))
                {
                    if (_passwordSet == false)
                    {
                        if (NewDocument(true) == false)
                        {
                            return;
                        }
                    }

                    if (string.IsNullOrEmpty(_documentName))
                    {
                        if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                        _documentName = saveFileDialog.FileName;
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to save over " + _documentName, "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                else 
                { 
                    return;
                }

                userInput = new MemoryStream();
                richTextBox.SaveFile(userInput, RichTextBoxStreamType.RichText);
                byte[] list = userInput.GetBuffer();
                _currentDocument.EncodedData = list;
                _currentDocument.Save(_documentName);

                AddFileToRecentFileList(_documentName);

                ChangeDisplayHeader();
                toolStripStatusLabel.Text = _documentName + " Saved...";
                _documentChanged = false;
            }
            finally
            {
                if (userInput != null)
                {
                    userInput.Dispose();
                }
            }                       
        }

        private void SaveDocumentAs()
        {
            MemoryStream userInput = null;

            try
            {               
                if (NewDocument(true) == false)
                {
                    return;
                }
                  
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                _documentName = saveFileDialog.FileName;                                  

                userInput = new MemoryStream();
                richTextBox.SaveFile(userInput, RichTextBoxStreamType.RichText);
                byte[] list = userInput.GetBuffer();
                _currentDocument.EncodedData = list;
                _currentDocument.Save(_documentName);


                _documentName = saveFileDialog.FileName;
                ChangeDisplayHeader();
                toolStripStatusLabel.Text = _documentName + " Saved...";
                _documentChanged = false;
            }
            finally
            {
                if (userInput != null)
                {
                    userInput.Dispose();
                }
            }
        }

        private void ChangeDisplayHeader()
        {
            if (!string.IsNullOrEmpty(_documentName))
            {
                Text = String.Format("{0} : {1}", ApplicationName, _documentName);
            }
            else
            {
                Text = String.Format("{0} : {1}", ApplicationName, "Untitled");
            }
        }

        private void LoadDocument(string fileName)
        {
            MemoryStream toLoad = null;

            try
            {
                if (NewDocument(false) == false)
                {
                    return;
                }

                richTextBox.Clear();
                _currentDocument.Load(fileName);

                if (_currentDocument.EncodedData == null)
                {
                    MessageBox.Show(Resources.MainForm_LoadDocument_Could_not_load_the_document__Did_you_enter_the_password_incorrectly_, Resources.MainForm_LoadDocument_Could_not_load_document, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                toLoad = new MemoryStream();
                var bytesToLoad = _currentDocument.EncodedData;
                toLoad.Write(bytesToLoad, 0, bytesToLoad.Length);
                toLoad.Position = 0;

                richTextBox.LoadFile(toLoad, RichTextBoxStreamType.RichText);

                FileExistsInRecentFileList(fileName);

                AddFileToRecentFileList(fileName);

                _documentName = fileName;
                ChangeDisplayHeader();
                _documentChanged = false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(Resources.Decryption_Error, Resources.Decryption_Error_Heading, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidDataException)
            {
                MessageBox.Show(Resources.Decryption_Error, Resources.Decryption_Error_Heading, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Resources.MainForm_LoadDocument_Error_Loading_Document, Resources.MainForm_LoadDocument_Error_Loading_Document, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (toLoad != null)
                {
                    toLoad.Dispose();                   
                }
            }
        }

        private void AddFileToRecentFileList(string fileName)
        {
            if (!FileExistsInRecentFileList(fileName))
            {
                AddFileToRecentFileListMenu(fileName);
                _settings.RecentFileList.Add(fileName);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void AddFileToRecentFileListMenu(string fileName)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            
            menuItem.Text = fileName;
            menuItem.Tag = fileName;
            menuItem.Name = fileName;
            menuItem.Click += RecentItemsMenuItemClickHandler;

            recentFilesToolStripMenuItem.DropDownItems.Add(menuItem);            
        }

        private void RecentItemsMenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (!File.Exists(clickedItem.Text))
            {
                MessageBox.Show("Could not load the file : " + clickedItem.Text, "Could not load file.", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                _settings.RecentFileList.Remove(clickedItem.Text);
                recentFilesToolStripMenuItem.DropDownItems.Remove(clickedItem);

                return;
            }

            LoadDocument(clickedItem.Text);
        }

        private bool FileExistsInRecentFileList(string fileName)
        {
            foreach (string file in _settings.RecentFileList)
            {
                if (String.Compare(file, fileName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadDocument()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {                
                return;
            }

            _documentName = openFileDialog.FileName;
            LoadDocument(_documentName);
            toolStripStatusLabel.Text = _documentName + " Loaded...";
        }

        private bool NewDocument(bool confirmPassword)
        {
            _passwordSet = false;

            while (!_passwordSet)
            {
                try
                {
                    using (var passwordEntry = new PasswordEntry())
                    {
                        passwordEntry.LabelText = "Stage 1 : Please enter your document passwords.";

                        if (passwordEntry.ShowDialog() != DialogResult.OK)
                        {
                            return false;
                        }
                        
                        if (confirmPassword)
                        {
                            if (ConfirmationPassword(passwordEntry) == false)
                            {
                                return false;
                            }
                        }

                        _currentDocument = new Document(passwordEntry.Password);
                        _documentChanged = false;
                        _passwordSet = true;
                    }
                }
                catch (ArgumentNullException) 
                {
                    Debug.WriteLine("Argument Null Exception Caught.");
                }
            }

            toolStripStatusLabel.Text = "New Document Created...";
            return true;
        }

        private static bool ConfirmationPassword(PasswordEntry passwordEntry)
        {
            using (var passwordEntry2 = new PasswordEntry())
            {
                passwordEntry2.LabelText = "Stage 2 : Please confirm your document passwords.";

                if (passwordEntry2.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                
                bool password1Match = ByteHelpers.ByteArrayCompare(passwordEntry.Password.Password1, passwordEntry2.Password.Password1);
                bool password2Match = ByteHelpers.ByteArrayCompare(passwordEntry.Password.Password2, passwordEntry2.Password.Password2);

                if ((password1Match == false) || (password2Match == false))
                {
                    MessageBox.Show(Resources.MainForm_ConfirmationPassword_The_passwords_do_not_match_, Resources.MainForm_ConfirmationPassword_Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }

                return true;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void PrintDocumentPrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.HasMorePages = RichTextBoxPrinter.Print(richTextBox, ref _charFrom, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.MainForm_PrintDocumentPrintPage_Print_error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void SetSelectionFontType()
        {
            var style = FontStyle.Regular;

            if ((_boldStatus == false) && (_italicStatus == false) && (_underlineStatus == false))
            {
                style = FontStyle.Regular;
            }

            if (_boldStatus && (_italicStatus == false) && (_underlineStatus == false))
            {
                style = FontStyle.Bold;
            }

            if ((_boldStatus == false) && _italicStatus && (_underlineStatus == false))
            {
                style = FontStyle.Italic;
            }

            if ((_boldStatus == false) && (_italicStatus == false) && _underlineStatus)
            {
                style = FontStyle.Underline;
            }

            if (_boldStatus && _italicStatus && (_underlineStatus == false))
            {
                style = FontStyle.Bold | FontStyle.Italic;
            }

            if ((_boldStatus == false) && _italicStatus && _underlineStatus)
            {
                style = FontStyle.Italic | FontStyle.Underline;
            }

            if (_boldStatus && (_italicStatus == false) && _underlineStatus)
            {
                style = FontStyle.Bold | FontStyle.Underline;
            }

            if (_boldStatus && _italicStatus && _underlineStatus)
            {
                style = FontStyle.Bold | FontStyle.Underline | FontStyle.Italic;
            }

            richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, style);
        }

        private void UpdateFontStyleButtons()
        {
            if (richTextBox.SelectionFont != null)
            {
                var style = richTextBox.SelectionFont.Style;

                boldButton.Checked = style.HasFlag(FontStyle.Bold);
                italicButton.Checked = style.HasFlag(FontStyle.Italic);
                underlineButton.Checked = style.HasFlag(FontStyle.Underline);

                boldToolStripMenuItem.Checked = boldButton.Checked;
                italicToolStripMenuItem.Checked = italicButton.Checked;
                underlineToolStripMenuItem.Checked = underlineButton.Checked;

                boldContextMenuItem1.Checked = boldButton.Checked;
                italicContextMenuItem1.Checked = italicButton.Checked;
                underlineContextMenuItem1.Checked = underlineButton.Checked;

                _boldStatus = boldButton.Checked;
                _italicStatus = italicButton.Checked;
                _underlineStatus = underlineButton.Checked;
            }
        }

        private void DecreaseIndent()
        {
            _indent = _indent - 10;

            if (_indent < 0)
            {
                _indent = 0;
            }

            richTextBox.SelectionIndent = _indent;
        }

        private void IncreaseIndent()
        {
            _indent = _indent + 10;

            if (_indent > 300)
            {
                _indent = 300;
            }

            richTextBox.SelectionIndent = _indent;
        }

        private void SetAlignment(HorizontalAlignment alignment)
        {
            richTextBox.SelectionAlignment = alignment;
        }

        private void NewDocumentWindow()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            Process.Start(path);

            EnableNotifyIcon(false);
        }

        private void EnableNotifyIcon(bool enabled)
        {
            if (IsProcessOpen("SafePad"))
            {
                notifyIcon.Visible = enabled;
            }
        }

        private static bool IsProcessOpen(string name)
        {
            return Process.GetProcesses().Any(clsProcess => clsProcess.ProcessName.Contains(name));
        }

        private static void AboutBox()
        {
            using (AboutDialogBox about = new AboutDialogBox())
            {
                about.ShowDialog();
            }
        }

        private void UpdateFontDropDownWithFontSelection()
        {
            if (richTextBox.SelectionFont != null)
            {
                string selectedFontName = richTextBox.SelectionFont.Name;
                toolStripFontSizeSelector.Text = richTextBox.SelectionFont.Size.ToString();

                int count = 0;

                foreach (string font in toolStripFontSelector.Items)
                {
                    if (String.Compare(font, selectedFontName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        toolStripFontSelector.SelectedIndex = count;
                    }
                    count++;
                }
            }
        }

        private void PopulateFontDropDown()
        {
            if (richTextBox.SelectionFont != null)
            {
                toolStripFontSelector.Items.Clear();

                int count = 0;

                Array.ForEach(FontFamily.Families, font =>
                {
                    toolStripFontSelector.Items.Add(font.Name);

                    if (String.Compare(richTextBox.SelectionFont.Name, font.Name, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        toolStripFontSelector.SelectedIndex = count;
                    }
                    count++;
                });

                toolStripFontSelector.Invalidate();
            }
        }

        private void UpdateFontInRichTextBox()
        {
            var selectedFontName = (string)toolStripFontSelector.Items[toolStripFontSelector.SelectedIndex];

            if (string.IsNullOrEmpty(selectedFontName))
            {
                return;
            }

            var fontFamily = GetFontFamilyNameFromDropDownList(selectedFontName);
            var fontSize = ApplyFontSizeToSelection();
            ApplyFontToSelection(fontFamily, fontSize);
        }

        private void ApplyFontToSelection(FontFamily fontFamily, float fontSize)
        {
            richTextBox.SelectionFont = richTextBox.SelectionFont == null ? new Font(fontFamily, fontSize) : new Font(fontFamily, fontSize, richTextBox.SelectionFont.Style);
        }

        private static FontFamily GetFontFamilyNameFromDropDownList(string selectedFontName)
        {
            FontFamily fontFamily = null;

            Array.ForEach(FontFamily.Families, font =>
            {
                if (String.Compare(selectedFontName, font.Name, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    fontFamily = font;
                }

            });
            return fontFamily;
        }

        private float ApplyFontSizeToSelection()
        {
            float fontSize = 12.0f;

            try
            {
                if (toolStripFontSizeSelector.SelectedIndex > 0)
                {
                    fontSize = float.Parse((string)toolStripFontSizeSelector.Items[toolStripFontSizeSelector.SelectedIndex]);
                }
                else
                {
                    fontSize = float.Parse(toolStripFontSizeSelector.Text);
                }
            }
            catch (FormatException) 
            {
                Debug.WriteLine("Format Exception Caught.");
            }

            return fontSize;
        }

        private void LoadSettings()
        {
            _settings = SettingsWriter.ReadSettingsFile();

            if (_settings != null)
            {
                Location = new Point(_settings.WindowPositionX, _settings.WindowPositionY);
                Size = new Size(_settings.WindowWidth, _settings.WindowHeight);
                WindowState = _settings.FormWindowState;

                richTextBox.BackColor = Color.FromArgb(_settings.BackgroundColorRed, _settings.BackgroundColorGreen, _settings.BackgroundColorBlue);
                richTextBox.ForeColor = Color.FromArgb(_settings.ForegroundColorRed, _settings.ForegroundColorGreen, _settings.ForegroundColorBlue);
                richTextBox.DetectUrls = _settings.DetectURL;
                richTextBox.WordWrap = _settings.WordWrap;
                wordWrapToolStripMenuItem.Checked = _settings.WordWrap;

                foreach(string fileName in _settings.RecentFileList)
                {
                    AddFileToRecentFileListMenu(fileName);
                }
            }
            else
            {
                SaveSettings(); 
            }
        }

        private void ExitApplication()
        {
            if (_documentChanged)
            {
                if (MessageBox.Show("You have un saved changes. Would you like to save your document?",
                    "Save Your Changes?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveDocument();
                }
            }

            ToolStripManager.SaveSettings(this, "SecureNotePad");

            SaveSettings();

            if (_findForm != null)
            {
                _findForm.Dispose();
                _findForm = null;
            }

            Application.Exit();
        }

        private void SaveSettings()
        {
            if (_settings == null)
            {
                _settings = new ApplicationSettings();
            }

            _settings.WindowPositionX = Location.X;
            _settings.WindowPositionY = Location.Y;
            _settings.WindowHeight = Size.Height;
            _settings.WindowWidth = Size.Width;
            _settings.FormWindowState = WindowState;
            _settings.DetectURL = richTextBox.DetectUrls;
            _settings.WordWrap = richTextBox.WordWrap;

            _settings.BackgroundColorRed = richTextBox.BackColor.R;
            _settings.BackgroundColorGreen = richTextBox.BackColor.G;
            _settings.BackgroundColorBlue = richTextBox.BackColor.B;

            _settings.ForegroundColorRed = richTextBox.ForeColor.R;
            _settings.ForegroundColorGreen = richTextBox.ForeColor.G;
            _settings.ForegroundColorBlue = richTextBox.ForeColor.B;

            SettingsWriter.WriteSettingsFile(_settings);
        }

        private void SetItalic()
        {
            italicButton.Checked = !italicButton.Checked;
            italicContextMenuItem1.Checked = italicButton.Checked;
            _italicStatus = italicButton.Checked;

            SetSelectionFontType();
        }

        private void SetUnderline()
        {
            underlineButton.Checked = !underlineButton.Checked;
            underlineContextMenuItem1.Checked = underlineButton.Checked;
            _underlineStatus = underlineButton.Checked;

            SetSelectionFontType();
        }

        private void SetBold()
        {
            boldButton.Checked = !boldButton.Checked;
            boldContextMenuItem1.Checked = boldButton.Checked;

            _boldStatus = boldButton.Checked;

            SetSelectionFontType();
        }

        private void ToggleBulletSelection()
        {
            bulletButton.Checked = !bulletButton.Checked;
            richTextBox.SelectionBullet = bulletButton.Checked;
            bulletSelectionToolStripMenuItem.Checked = bulletButton.Checked;
            richTextBox.SelectionIndent = 50;
        }

        private void OpenPropertiesDialog()
        {
            using (var appSettings = new ApplicationProperties(_settings))
            {
                if (appSettings.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox.DetectUrls = appSettings.Settings.DetectURL;
                    _settings.RecentFileList = appSettings.Settings.RecentFileList;

                    recentFilesToolStripMenuItem.DropDownItems.Clear();
                    foreach (string fileName in _settings.RecentFileList)
                    {
                        AddFileToRecentFileListMenu(fileName);
                    }
                }
            }
        }
    }
}
