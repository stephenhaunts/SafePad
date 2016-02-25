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

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class FileProxy : IFileProxy
    {
        public byte[] Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var br = new BinaryReader(fs);
                var numBytes = new FileInfo(fileName).Length;
                return br.ReadBytes((int)numBytes);
            }
        }

        public void Save(string fileName, byte[] dataToSave)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (dataToSave == null)
            {
                throw new ArgumentNullException(nameof(dataToSave));
            }

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(dataToSave, 0, dataToSave.Length);
            }
        }

        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            return File.Exists(fileName);            
        }
    }
}
