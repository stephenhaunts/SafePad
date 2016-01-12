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
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class PasswordEntry : Form
    {
        private Password _password;

        public PasswordEntry()
        {
            InitializeComponent();

            _cachePasswordForSession.Visible = true;
          
            passwordTabControl.TabPages.Remove(keyFileTabPage);
            passwordTabControl.SelectTab(passwordTabPage);
        }

        public PasswordEntry(bool cachePassword)
        {
            InitializeComponent();

            _cachePasswordForSession.Visible = cachePassword;
          
            passwordTabControl.TabPages.Remove(keyFileTabPage);
            passwordTabControl.SelectTab(passwordTabPage);
        }

        public bool IsPasswordCached
        {
            get
            {
                return _cachePasswordForSession.Checked;
            }
        }

        public Password Password
        {
            get
            {
                return _password;
            }
        }

        public string LabelText
        {
            get
            {
                return _passwordEntryLabel.Text;
            }
            set
            {
                _passwordEntryLabel.Text = value;
                Text = value;
            }
        }

        private void SetPassword(string password1, string password2)
        {
            if (string.IsNullOrEmpty(password1))
            {
                throw new ArgumentNullException("password1");
            }

            _password = new Password(password1, password2);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {          
            SetPassword(_passwordOne.Text, _passwordTwo.Text);           
        }
        
        private void _passwordOne_KeyPress(object sender, KeyPressEventArgs e)
        {         
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                _passwordTwo.Focus();
            }     
        }

        private void _passwordTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetPasswordOnReturn(e);
        }

        private void SetPasswordOnReturn(KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Return)
            {
                SetPassword(_passwordOne.Text, _passwordTwo.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void PasswordEntry_Load(object sender, EventArgs e)
        {
            _passwordOne.Text = "";
            _passwordTwo.Text = "";
        }

        private void _passwordOne_TextChanged(object sender, EventArgs e)
        {
            ChangePasswordStrengthIndicator(password1Strength, _passwordOne.Text);
        }

        private void _passwordTwo_TextChanged(object sender, EventArgs e)
        {
            ChangePasswordStrengthIndicator(password2Strength, _passwordTwo.Text);
        }

        private static void ChangePasswordStrengthIndicator(Label label, string password)
        {
            PasswordScore score = PasswordStrength.CheckStrength(password);
            Console.WriteLine(score);
            switch (score)
            {
                case PasswordScore.Blank:
                    label.ForeColor = Color.Red;
                    label.Text = "";
                    break;

                case PasswordScore.Weak:
                    label.ForeColor = Color.Red;
                    label.Text = "Weak";
                    break;

                case PasswordScore.VeryWeak:
                    label.ForeColor = Color.Red;
                    label.Text = "Very Weak";
                    break;

                case PasswordScore.Medium:
                    label.ForeColor = Color.Orange;
                    label.Text = "Medium";
                    break;

                case PasswordScore.Strong:
                    label.ForeColor = Color.Orange;
                    label.Text = "Strong";
                    break;

                case PasswordScore.VeryStrong:
                    label.ForeColor = Color.Green;
                    label.Text = "Very Strong";
                    break;
            }
        }

        private void _passwordOne_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void _password1Keyboard_Click(object sender, EventArgs e)
        {
            using (var keyboard = new KeyboardInput(_passwordOne.Text))
            {
                if (keyboard.ShowDialog() == DialogResult.OK)
                {
                    _passwordOne.Text = keyboard.Password;
                }
            }
        }

        private void _password2Keyboard_Click(object sender, EventArgs e)
        {
            using (var keyboard = new KeyboardInput(_passwordTwo.Text))
            {
                if (keyboard.ShowDialog() == DialogResult.OK)
                {
                    _passwordTwo.Text = keyboard.Password;
                }
            }
        }

        private void useKeyFile_CheckedChanged(object sender, EventArgs e)
        {
            if (useKeyFile.Checked)
            {
                passwordTabControl.TabPages.Add(keyFileTabPage);
            }
            else
            {            
                passwordTabControl.TabPages.Remove(keyFileTabPage);                
            }
        }

        private void selectKeyFile_Click(object sender, EventArgs e)
        {
            if (selectKeyFileDialog.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
