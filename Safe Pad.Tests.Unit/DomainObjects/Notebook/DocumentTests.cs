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
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Document = HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook.Document;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.Notebook
{
    [TestClass]
    public class DocumentTests
    {
        private class TestFileProxy : IFileProxy
        {
            public byte[] Load(string fileName)
            {
                return null;
            }

            public void Save(string fileName, byte[] dataToSave)
            {

            }

            public bool FileExists(string fileName)
            {
                if (fileName == @"c:\fileExists.scp")
                {
                    return true;
                }

                return false;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void ConstructorThrowsArgumentNullExceptionIfFileNameIsNull()
        {
            new Document(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "documentName")]
        public void ConstructorThrowsArgumentNullExceptionIfDocumentNameIsNull()
        {
            new Document(@"c:\fileExists.scp", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileProxy")]
        public void ConstructorThrowsArgumentNullExceptionIfFileProxyIsNull()
        {
            new Document(@"c:\filename.scp", "Filename", null);
        }

        [TestMethod]
        public void FilenamePropertyReturnsFileNameSetInTheConstructor()
        {
            const string fileName = @"c:\fileExists.scp";
            const string documentName = @"Filename";

            var document = new Document(fileName, documentName, new TestFileProxy());
            Assert.AreEqual(fileName, document.Filename);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "c:\fileNostExists.scp")]
        public void COnstructorThrowsFileNotFoundExceptionIfFileNotFound()
        {
            const string fileName = @"c:\fileNostExists.scp";
            const string documentName = @"Filename";

            var document = new Document(fileName, documentName, new TestFileProxy());            
        }

        [TestMethod]
        public void DocumentNamePropertyReturnsDocumentNameSetInTheConstructor()
        {
            const string fileName = @"c:\fileExists.scp";
            const string documentName = @"Filename";

            var document = new Document(fileName, documentName, new TestFileProxy());
            Assert.AreEqual(documentName, document.DocumentName);
        }

        [TestMethod]
        public void FileExistsReturnsTrueIfTheFileExists()
        {
            const string fileName = @"c:\fileExists.scp";
            const string documentName = @"Filename";

            var document = new Document(fileName, documentName, new TestFileProxy());
            Assert.IsTrue(document.FileExists());
        }      
    }
}
