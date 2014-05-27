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

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook
{
    public class Document
    {
        private string _fileName;
        private string _documentName;
        private readonly IFileProxy _fileProxy;

        public Document(string fileName, string documentName)
        {           
            SetFileProperties(fileName, documentName);
            _fileProxy = new FileProxy();
        }

        public Document(string fileName, string documentName, IFileProxy fileProxy)
        {
            if (fileProxy == null)
            {
                throw new ArgumentNullException("fileProxy");    
            }

            SetFileProperties(fileName, documentName);
            _fileProxy = new FileProxy();
        }

        private void SetFileProperties(string fileName, string documentName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentNullException("documentName");
            }

            if (!_fileProxy.FileExists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            _fileName = fileName;
            _documentName = documentName;
        }

        public string Filename
        {
            get { return _fileName; }
        }

        public string DocumentName
        {
            get { return _documentName; }
        }

    }
}
