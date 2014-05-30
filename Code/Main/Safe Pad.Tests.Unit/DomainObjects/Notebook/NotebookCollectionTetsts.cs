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
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Document = HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook.Document;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.Notebook
{
    [TestClass]
    public class NotebookCollectionTests
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
        [ExpectedException(typeof(ArgumentNullException), "noteBookName")]
        public void CreateNoteBookThrowsArgumentNullExceptionIfNotebookNameIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook(null);
        }

        [TestMethod]        
        public void CreateNoteBookInsertsNoteBookIntoCollection()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("myNoteBook");

            Assert.AreEqual(1, noteBookCollection.CountNoteBooks);
        }

        [TestMethod]
        public void CreateNoteBookInsertsTwoNoteBookIntoCollection()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("myNoteBook");
            noteBookCollection.CreateNotebook("myNoteBook2");

            Assert.AreEqual(2, noteBookCollection.CountNoteBooks);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "noteBookName")]
        public void CreateNoteBookThrowsInvalidOperationExceptionIfYouTryToInserTwoNotebooksOfTheSameName()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("myNoteBook");
            noteBookCollection.CreateNotebook("myNoteBook");

            Assert.AreEqual(2, noteBookCollection.CountNoteBooks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "noteBookName")]
        public void RemoveNoteBookThrowsArgumentNullExceptionIfNotebookNameIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.RemoveNotebook(null);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "noteBookName")]
        public void RemoveNoteBookThrowsInvalidOperationExceptionIfNoteBookDoesNotExist()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.RemoveNotebook("Not Exists");
        }

        [TestMethod]        
        public void RemoveNoteBookSuccessfullyRemovesNotebook()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("Exists");
            noteBookCollection.RemoveNotebook("Exists");

            Assert.AreEqual(0, noteBookCollection.CountNoteBooks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "noteBookName")]
        public void AddDocumentToNotebookThrowsArgumentNullExceptionIfNotebookNameIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");
            noteBookCollection.AddDocumentToNotebook(null, null);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "noteBookName")]
        public void AddDocumentToNotebookThrowsArgumentNullExceptionIfDocumentIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");
            noteBookCollection.AddDocumentToNotebook("notebook", null);
        }

        [TestMethod]
        public void AddDocumentToNotebookAddsDocumentToNoteBook()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");

            var document = new Document(@"c:\fileExists.scp", "myDocument1", new TestFileProxy());
            noteBookCollection.AddDocumentToNotebook("notebook", document );

            Assert.IsTrue(noteBookCollection.DocumentExists("notebook", document));
        }

        [TestMethod]
        public void AddDocumentsToNotebookAdds2DocumentsToNoteBook()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");

            var document = new Document(@"c:\fileExists.scp", "myDocument1", new TestFileProxy());
            var document2 = new Document(@"c:\fileExists.scp", "myDocument2", new TestFileProxy());

            noteBookCollection.AddDocumentToNotebook("notebook", document);
            noteBookCollection.AddDocumentToNotebook("notebook", document2);

            Assert.IsTrue(noteBookCollection.DocumentExists("notebook", document));
            Assert.IsTrue(noteBookCollection.DocumentExists("notebook", document2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "noteBookName")]
        public void DocumentExistsThrowsArgumentNullExceptionIfNotebookNameIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");
            noteBookCollection.DocumentExists(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "document")]
        public void DocumentExistsThrowsArgumentNullExceptionIfDocumentIsNull()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");
            noteBookCollection.DocumentExists("notebook", null);
        }

        [TestMethod]
        public void DocumentExistsToNotebookAddsDocumentToNoteBook()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");

            var document = new Document(@"c:\fileExists.scp", "myDocument1", new TestFileProxy());
            noteBookCollection.AddDocumentToNotebook("notebook", document);

            Assert.IsTrue(noteBookCollection.DocumentExists("notebook", document));
        }

        [TestMethod]
        public void DocumentCountToNotebookAddsDocumentToNoteBook()
        {
            var noteBookCollection = new NotebookCollection();
            noteBookCollection.CreateNotebook("notebook");

            var document = new Document(@"c:\fileExists.scp", "myDocument1", new TestFileProxy());
            noteBookCollection.AddDocumentToNotebook("notebook", document);

            Assert.AreEqual(1, noteBookCollection.DocumentCount("notebook"));
        }
    }
}
