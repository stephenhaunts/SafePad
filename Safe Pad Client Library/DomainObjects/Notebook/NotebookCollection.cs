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

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.Notebook
{
    public class NotebookCollection
    {
        private Dictionary<string, List<Document>> _notebooks;

        public NotebookCollection()
        {
            _notebooks = new Dictionary<string, List<Document>>(StringComparer.OrdinalIgnoreCase);  
        }

        public int CountNoteBooks
        {
            get
            {
                return _notebooks.Count;
                
            }
        }

        private bool IsExists(string noteBookName)
        {
            return _notebooks.ContainsKey(noteBookName);
        }

        public void CreateNotebook(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException("noteBookName");
            }

            if (IsExists(noteBookName))
            {
                throw new InvalidOperationException("noteBookName");
            }

            _notebooks.Add(noteBookName, new List<Document>());            
        }

        public void RemoveNotebook(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException("noteBookName");
            }

            if (!IsExists(noteBookName))
            {
                throw new InvalidOperationException("noteBookName");
            }

            _notebooks.Remove(noteBookName);
        }

        public void AddDocumentToNotebook(string noteBookName, Document document)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException("noteBookName");
            }

            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            _notebooks[noteBookName].Add(document);
        }

        public bool DocumentExists(string noteBookName, Document document)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException("noteBookName");
            }

            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            return _notebooks[noteBookName].Contains(document);            
        }

        public int DocumentCount(string noteBookName)
        {
            if (string.IsNullOrEmpty(noteBookName))
            {
                throw new ArgumentNullException("noteBookName");
            }
        
            return _notebooks[noteBookName].Count;
        }
    }
}
