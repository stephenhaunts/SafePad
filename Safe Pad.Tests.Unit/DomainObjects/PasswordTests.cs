using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using System.Collections;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class PasswordTests
    { 
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PasswordConstructorThrowsArgumentNullExceptionIfPassword1IsNull()
        {
            new Password(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PasswordConstructorThrowsArgumentNullExceptionIfPassword2IsNull()
        {
            new Password("password", null);
        }

        [TestMethod]
        public void Password1ReturnsByteArray()
        {
            IPassword password = new Password("password1", "password2");
            Assert.IsNotNull(password.Password1);
        }

        [TestMethod]
        public void Password2ReturnsByteArray()
        {
            IPassword password = new Password("password1", "password2");
            Assert.IsNotNull(password.Password2);
        }

        [TestMethod]
        public void Password1AndPassword2DoNotReturnTheSameByteArray()
        {
            IPassword password = new Password("password1", "password2");
            Assert.IsTrue(ByteArrayCompare(password.Password1, password.Password2));
        }

        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            IStructuralEquatable eqa1 = a1;
            return !eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
