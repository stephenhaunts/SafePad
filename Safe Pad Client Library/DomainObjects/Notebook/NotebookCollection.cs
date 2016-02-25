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

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook
{
    public class NotebookCollection
    {
        public NotebookCollection()
        {
            Notebooks = new Dictionary<string, List<Document>>(StringComparer.OrdinalIgnoreCase);  
        }

        public int CountNoteBooks => Notebooks.Count;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public Dictionary<string, List<Document>> Notebooks { get; set; }

        public bool IsExists(string noteBookName)
        {
            return Notebooks.ContainsKey(noteBookName);
        }

        public void CreateNotebook(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (IsExists(noteBookName))
            {
                throw new InvalidOperationException("noteBookName");
            }

            var notebook = new List<Document>();
            Notebooks.Add(noteBookName, notebook);            
        }

        public void RemoveNotebook(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (!IsExists(noteBookName))
            {
                throw new InvalidOperationException("noteBookName");
            }

            Notebooks.Remove(noteBookName);
        }

        public ReadOnlyCollection<string> RetrieveNotebookNames()
        {
            var notebooks = Notebooks.Select(entry => entry.Key).ToList();

            return new ReadOnlyCollection<string>(notebooks);
        }

        public ReadOnlyCollection<Document> RetrieveNoteBook(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (!IsExists(noteBookName))
            {
                throw new InvalidOperationException(noteBookName);
            }

            return new ReadOnlyCollection<Document>(Notebooks[noteBookName]);
        }

        public void AddDocumentToNotebook(string noteBookName, Document document)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            Notebooks[noteBookName].Add(document);
        }

        public bool DocumentExists(string noteBookName, Document document)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return Notebooks[noteBookName].Contains(document);            
        }

        public int DocumentCount(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }
        
            return Notebooks[noteBookName].Count;
        }

        public void RemoveDocument(string noteBookName, Document document)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (!DocumentExists(noteBookName, document))
            {
                throw new InvalidOperationException("document");
            }

            Notebooks[noteBookName].Remove(document);
        }

        public void RemoveAllDocuments(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException(nameof(noteBookName));
            }

            Notebooks[noteBookName].Clear();
        }
    }
}
