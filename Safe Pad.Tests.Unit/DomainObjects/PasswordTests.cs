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
using System.Collections;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class PasswordTests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.DomainObjects.Password"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PasswordConstructorThrowsArgumentNullExceptionIfPassword1IsNull()
        {
            new Password(null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.DomainObjects.Password"), TestMethod]
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
