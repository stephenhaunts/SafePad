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
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.Forms.Notebook
{
    public partial class RemoveNotebook : Form
    {        
        public RemoveNotebook(IEnumerable<string> notebooks )
        {
            if (notebooks == null)
            {
                throw new ArgumentNullException("notebooks");    
            }

            InitializeComponent();

            foreach (var name in notebooks)
            {
                notepadListBox.Items.Add(name, CheckState.Unchecked);
            }            
        }

        public ReadOnlyCollection<string> SelectedItems
        {
            get
            {
                var selectedItems = notepadListBox.SelectedItems.Cast<object>().Cast<string>().ToList();

                return new ReadOnlyCollection<string>(selectedItems);
            }
        }

        private void notepadListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            okButton.Enabled = notepadListBox.SelectedItems.Count != 0;   
        }
        
        private void notepadListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {            
            okButton.Enabled = notepadListBox.SelectedItems.Count != 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
