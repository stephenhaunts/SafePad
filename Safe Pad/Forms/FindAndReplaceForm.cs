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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class FindAndReplaceForm : Form
    {
        private readonly RichTextBox _richTextBox;
        private int findCounter;

        public FindAndReplaceForm()
        {
            InitializeComponent();
        }

        public FindAndReplaceForm(RichTextBox richTextBox)
        {
            if (richTextBox == null)
            {
                throw new ArgumentNullException("richTextBox");
            }            
            
            _richTextBox = richTextBox;
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "parentY+70"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "parentX+150")]
        public void SetPosition(int parentX, int parentY)
        {
            Location = new Point(parentX + 150, parentY + 70);
        }

        public int FindMyText(string text, int start, RichTextBoxFinds options)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            if (_richTextBox.TextLength == 0)
            {
                return 0;
            }

            int returnValue = -1;

            if (text.Length > 0 && start >= 0)
            {               

                if (start > _richTextBox.TextLength)
                {
                    return -1;
                }

                int indexToText = _richTextBox.Find(text, start, options);

                if (indexToText >= 0)
                {
                    returnValue = indexToText;
                    _richTextBox.SelectionStart = returnValue;
                    _richTextBox.SelectionLength = text.Length;
                }
            }

            return returnValue + text.Length;
        }
        
        private void findNextButtton_Click(object sender, EventArgs e)
        {
            Find();         
        }

        private void Find()
        {
            RichTextBoxFinds options = SetFindOptions();
            findCounter = FindMyText(textToFind.Text, findCounter, options);
        }

        private RichTextBoxFinds SetFindOptions()
        {
            RichTextBoxFinds options = RichTextBoxFinds.None;

            if (noneRadioButton.Checked)
            {
                options = RichTextBoxFinds.None;
            }
            else if (wholeWordRadioButton.Checked)
            {
                options = RichTextBoxFinds.WholeWord;
            }
            else if (matchCaseRadioButton.Checked)
            {
                options = RichTextBoxFinds.MatchCase;
            }            

            return options;
        }

        private void replaceText_Click(object sender, EventArgs e)
        {
            Replace();
        }

        private void Replace()
        {
            RichTextBoxFinds options = SetFindOptions();
            findCounter = FindMyText(textToFind.Text, findCounter, options);

            if (findCounter > 0)
            {
                if (_richTextBox.SelectionStart == _richTextBox.TextLength)
                {
                    return;
                }

                _richTextBox.SelectedText = textToReplace.Text;

                if (findCounter - textToFind.Text.Length > -1)
                {
                    _richTextBox.SelectionStart = findCounter - textToFind.Text.Length;
                    _richTextBox.SelectionLength = textToReplace.Text.Length;
                }
            }
        }

        private void textToFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                Find();
            }  
        }

        private void textToReplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                Replace();
            }  
        }
    }
}
