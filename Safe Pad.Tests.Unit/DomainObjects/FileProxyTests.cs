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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class FileProxyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void LoadThrowsArgumentNullExceptionIfFilenameIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Load(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void SaveThrowsArgumentNullExceptionIfFilenameIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Save(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "dataToSave")]
        public void SaveThrowsArgumentNullExceptionIfDataToSaveIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Save("file.txt", null);
        }
    }
}
