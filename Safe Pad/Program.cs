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
using HauntedHouseSoftware.SecureNotePad.Forms;
using System.IO;

namespace HauntedHouseSoftware.SecureNotePad
{
    [CLSCompliant(true)]
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            MainForm form;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (args.Length >= 1)
            {
                form = IsValidFile(args[0]) ? new MainForm(args[0]) : new MainForm();
            }
            else
            {
                form = new MainForm();
            }

            Application.Run(form);
        }

        private static bool IsValidFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                if (fileName.ToLower().Contains(".scp"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}