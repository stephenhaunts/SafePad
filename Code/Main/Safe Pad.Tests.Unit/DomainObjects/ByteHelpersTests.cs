/**
 * Safe Pad, a double encrypted note pad that uses 2 passwords to protect your documents and help you keep your privacy.
 * 
 * Copyright (C) 2014 Stephen Haunts
 * http://www.stephenhaunts.com
 * 
 * This file is part of MupenSafe Pad64PlusAE.
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class ByteHelpersTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "a1")]
        public void ByteArrayCompareThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            ByteHelpers.ByteArrayCompare(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "a2")]
        public void ByteArrayCompareThrowsArgumentNullExceptionIfSecondParameterIsNull()
        {
            var test = new byte[5];
            ByteHelpers.ByteArrayCompare(test, null);
        }

        [TestMethod]        
        public void ByteArrayCompareReturnsTrueIfArraysAreTheSame()
        {
            byte[] test1 = { 0x01, 0xE5, 0x92, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };
            byte[] test2 = { 0x01, 0xE5, 0x92, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };
            
            Assert.IsTrue(ByteHelpers.ByteArrayCompare(test1, test2));
        }

        [TestMethod]
        public void ByteArrayCompareReturnsFalseIfArraysAreNotTheSame()
        {
            byte[] test1 = { 0x01, 0xE5, 0x92, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };
            byte[] test2 = { 0x05, 0xE6, 0x72, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };

            Assert.IsFalse(ByteHelpers.ByteArrayCompare(test1, test2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "length")]
        public void CreateSpecialByteArrayThrowsInvalidOperationExceptionIfLengthIsZero()
        {
            ByteHelpers.CreateSpecialByteArray(0);
        }

        [TestMethod]        
        public void CreateSpecialByteArrayCreateArayOfSize10()
        {
            byte[] array = ByteHelpers.CreateSpecialByteArray(10);
            Assert.AreEqual(10, array.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "first")]
        public void CombineThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            ByteHelpers.Combine(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "second")]
        public void CombineThrowsArgumentNullExceptionIfSecondParameterIsNull()
        {
            var test = new byte[5];
            ByteHelpers.Combine(test, null);
        }

        [TestMethod]        
        public void CombineMergesToArraysTogether()
        {
            byte[] test = { 1, 2 };
            byte[] test2 = { 3, 4 };
            
            byte[] combined = ByteHelpers.Combine(test, test2);

            Assert.AreEqual(4, combined.Length);
            Assert.AreEqual(1, combined[0]);
            Assert.AreEqual(2, combined[1]);
            Assert.AreEqual(3, combined[2]);
            Assert.AreEqual(4, combined[3]);
        }
    }
}
