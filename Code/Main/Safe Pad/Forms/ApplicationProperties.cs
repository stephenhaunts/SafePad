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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                throw new ArgumentNullException("settings");
            }

            _settings = settings;

            InitializeComponent();

            detectURL.Checked = _settings.DetectURL;
        }

        public ApplicationSettings Settings
        {
            get
            {
                return _settings;
            }
        }

        private void detectURL_CheckedChanged(object sender, EventArgs e)
        {
            _settings.DetectURL = detectURL.Checked;
        }
    }
}
