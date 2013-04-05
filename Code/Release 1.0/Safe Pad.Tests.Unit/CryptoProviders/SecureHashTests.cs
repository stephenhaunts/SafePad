using HauntedHouseSoftware.SecureNotePad.CryptoProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.CryptoProviders
{
    [TestClass]
    public class SecureHashTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "toBeHashed")]
        public void ComputeHashThrowsArgumentNullExceptionIfDataToHashedIsNull()
        {
            ISecureHash hash = new SecureHash();
            hash.ComputeHash(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "toBeHashed")]
        public void ComputeHashThrowsArgumentNullExceptionIfDataToHashedIsEmpty()
        {            
            var data = new byte[0];

            ISecureHash hash = new SecureHash();
            hash.ComputeHash(data);            
        }

        [TestMethod]        
        public void ComputeHashCreatesHashOfSomeInputData()
        {
            var data = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};

            ISecureHash hash = new SecureHash();
            byte[] hashedData = hash.ComputeHash(data);

            Assert.IsNotNull(hashedData);
        }

        [TestMethod]
        public void ComputeHashCreatesHashOfSomeInputDataAndItIsDifferentToInputData()
        {
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            ISecureHash hash = new SecureHash();
            var hashedData = hash.ComputeHash(data);

            Assert.IsTrue(ByteArrayCompare(data, hashedData));
        }

        [TestMethod]
        public void ComputeHashCreatesHashOfSomeInputDataAndItIs256BitsInLength()
        {
            var data = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            ISecureHash hash = new SecureHash();
            var hashedData = hash.ComputeHash(data);

            Assert.AreEqual(32, hashedData.Length);
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return !eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
