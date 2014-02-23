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
using HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.FileFormat
{
    [TestClass]
    public class LoaderFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "byteStream" )]
        public void GetFileLoaderThrowsArgumentNullExceptionIfByteStreamIsNull()
        {
            var loader = new LoaderFactory();
            loader.GetFileLoader(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void GetFileLoaderThrowsArgumentNullExceptionIfPasswordIsNull()
        {
            var loader = new LoaderFactory();
            byte[] stream = {1, 0};
            loader.GetFileLoader(stream, null);
        }

        [TestMethod]        
        public void GetFileLoaderReturnsLoaderForVersion10Files()
        {
            var loader = new LoaderFactory();
            byte[] stream = { 1, 0 };
            var password = new Password("password", "password2");
            var fileFormatLoader = loader.GetFileLoader(stream, password);

            Assert.AreEqual(typeof(Version10Loader), fileFormatLoader.GetType());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "fileFormatLoader"), TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The file is not a supported file format version.")]
        public void GetFileLoaderThrowsInValidOperationExceptionForInvalifFileFormat()
        {
            var loader = new LoaderFactory();
            byte[] stream = { 1, 2 };
            var password = new Password("password", "password2");
            var fileFormatLoader = loader.GetFileLoader(stream, password);            
        }
    }
}
