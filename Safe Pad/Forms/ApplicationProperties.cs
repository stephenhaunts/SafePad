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
using System.Windows.Forms;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;

namespace HauntedHouseSoftware.SecureNotePad.Forms
{
    public partial class ApplicationProperties : Form
    {
        private readonly ApplicationSettings _settings;
        public ApplicationProperties()
        {
            InitializeComponent();
        }

        public ApplicationProperties(ApplicationSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            _settings = settings;

            InitializeComponent();

            detectURL.Checked = _settings.DetectUrl;
        }

        public ApplicationSettings Settings => _settings;

        private void detectURL_CheckedChanged(object sender, EventArgs e)
        {
            _settings.DetectUrl = detectURL.Checked;
        }

        private void clearRecentFileListButton_Click(object sender, EventArgs e)
        {
            _settings.RecentFileList.Clear();
        }

        private void wordWrapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _settings.WordWrap = wordWrapCheckBox.Checked;
        }
    }
}
