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
using System.Globalization;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms.PasswordGenerator
{
    public partial class PasswordGeneratorForm : Form
    {        
        public PasswordGeneratorForm()
        {
            InitializeComponent();
            passwordLengthIndicator.Text = passwordLengthTrackBar.Value.ToString(CultureInfo.InvariantCulture);
            singleCase.Checked = false;

            GeneratePassword();
        }

        public string Password
        {
            get
            {
                return generatedPassword.Text;
            }
        }

        private void passwordLengthTrackBar_ValueChanged(object sender, EventArgs e)
        {
            passwordLengthIndicator.Text = passwordLengthTrackBar.Value.ToString(CultureInfo.InvariantCulture);

            GeneratePassword();
        } 

        private void GeneratePassword()
        {
            generatedPassword.Text = Tools.PasswordGenerator.Generate(passwordLengthTrackBar.Value, singleCase.Checked);
        }

        private void singleCase_CheckedChanged(object sender, EventArgs e)
        {
            GeneratePassword();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneratePassword();
        }
    }
}
