using HauntedHouseSoftware.SecureNotePad.CryptoProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

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
            aes.Encrypt(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "dataToEncrypt")]
        public void EncryptThrowsInvalidOperationExceptionIfDataToEncryptIsOfSizeZero()
        {
            IAES aes = new AES();
            var data = new byte[0];

            aes.Encrypt(data, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void EncryptThrowsArgumentNullExceptionIfPasswordIsNullOrEmpty()
        {
            IAES aes = new AES();
            var data = new byte[2];

            aes.Encrypt(data, null);
        }

        [TestMethod]       
        public void EncryptEncryptsDataUsingThePasswordAndTheResultIsDifferentToTheInput()
        {
            IAES aes = new AES();
            var data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            var encryptedData = aes.Encrypt(data, "password");            

            Assert.IsTrue(ByteArrayCompare(data, encryptedData));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "dataToDecrypt")]
        public void DecryptThrowsArgumentNullExceptionIfDataToDecryptIsNull()
        {
            IAES aes = new AES();
            aes.Decrypt(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "dataToDecrypt")]
        public void DecryptThrowsInvalidOperationExceptionIfDataToDecryptIsOfSizeZero()
        {
            IAES aes = new AES();
            var data = new byte[0];

            aes.Decrypt(data, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void DecryptThrowsArgumentNullExceptionIfPasswordIsNullOrEmpty()
        {
            IAES aes = new AES();
            var data = new byte[2];

            aes.Decrypt(data, null);
        }

        [TestMethod]
        public void DecryptDataThatHasBeenEncrypted()
        {
            IAES aes = new AES();
            var originalData = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var encryptedData = aes.Encrypt(originalData, "password");
            var decryptedData = aes.Decrypt(encryptedData, "password");

            Assert.IsFalse(ByteArrayCompare(originalData, decryptedData));
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return !eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
