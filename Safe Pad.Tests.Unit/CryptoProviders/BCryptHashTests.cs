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
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.CryptoProviders
{
    [TestClass]
    public class BCrptHashTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "toBeHashed")]
        public void ComputeHashThrowsArgumentNullExceptionIfDataToHashedIsNull()
        {
            ISecureHash hash = new BCryptHash();
            hash.ComputeHash(null);
        }

        [TestMethod]        
        public void ComputeHashCreatesHashOfSomeInputData()
        {
            var data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};

            ISecureHash hash = new BCryptHash();
            byte[] hashedData = hash.ComputeHash(data);

            Assert.IsNotNull(hashedData);
        }

        [TestMethod]
        public void ComputeHashCreatesHashOfSomeInputDataAndItIsDifferentToInputData()
        {
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            ISecureHash hash = new BCryptHash();
            var hashedData = hash.ComputeHash(data);

            Assert.IsTrue(ByteArrayCompare(data, hashedData));
        }

        [TestMethod]
        public void ComputeHashCreatesHashOfSomeInputDataAndItIs256BitsInLength()
        {
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            ISecureHash hash = new BCryptHash();
            var hashedData = hash.ComputeHash(data);

            Assert.AreEqual(60, hashedData.Length);
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return !eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
