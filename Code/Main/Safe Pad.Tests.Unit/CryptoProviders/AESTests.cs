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
using System.Text;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.CryptoProviders
{
    [TestClass]
    public class AESTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "dataToEncrypt")]
        public void EncryptThrowsArgumentNullExceptionIfDataToEncryptIsNull()
        {
            IAES aes = new AES();
            aes.Encrypt(null, null, null, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "dataToEncrypt")]
        public void EncryptThrowsInvalidOperationExceptionIfDataToEncryptIsOfSizeZero()
        {
            IAES aes = new AES();
            var data = new byte[0];

            aes.Encrypt(data, null, null, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void EncryptThrowsArgumentNullExceptionIfPasswordIsNullOrEmpty()
        {
            IAES aes = new AES();
            var data = new byte[2];

            aes.Encrypt(data, null, null, 1000);
        }

        [TestMethod]       
        public void EncryptEncryptsDataUsingThePasswordAndTheResultIsDifferentToTheInput()
        {
            IAES aes = new AES();
            var data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            var encryptedData = aes.Encrypt(data, "password", Encoding.ASCII.GetBytes("eryryn78ynr78yn"), 1000);            

            Assert.IsTrue(ByteArrayCompare(data, encryptedData));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "dataToDecrypt")]
        public void DecryptThrowsArgumentNullExceptionIfDataToDecryptIsNull()
        {
            IAES aes = new AES();
            aes.Decrypt(null, null, null, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "dataToDecrypt")]
        public void DecryptThrowsInvalidOperationExceptionIfDataToDecryptIsOfSizeZero()
        {
            IAES aes = new AES();
            var data = new byte[0];

            aes.Decrypt(data, null, null, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void DecryptThrowsArgumentNullExceptionIfPasswordIsNullOrEmpty()
        {
            IAES aes = new AES();
            var data = new byte[2];

            aes.Decrypt(data, null, null, 1000);
        }

        [TestMethod]
        public void DecryptDataThatHasBeenEncrypted()
        {
            IAES aes = new AES();
            var originalData = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var encryptedData = aes.Encrypt(originalData, "password", Encoding.ASCII.GetBytes("eryryn78ynr78yn"), 1000);
            var decryptedData = aes.Decrypt(encryptedData, "password", Encoding.ASCII.GetBytes("eryryn78ynr78yn"), 1000);

            Assert.IsFalse(ByteArrayCompare(originalData, decryptedData));
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return !eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
