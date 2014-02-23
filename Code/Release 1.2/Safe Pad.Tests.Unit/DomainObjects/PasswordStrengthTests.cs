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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class PasswordStrengthTests
    {
        [TestMethod]
        public void CheckStrengthReturnsEmptyForBlankPassword()
        {
            Assert.AreEqual(PasswordScore.Blank, PasswordStrength.CheckStrength(""));
        }

        [TestMethod]
        public void CheckStrengthReturnsVeryWeakForPasswordOfHello()
        {
            Assert.AreEqual(PasswordScore.VeryWeak, PasswordStrength.CheckStrength("Hello"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfHello2()
        {
            Assert.AreEqual(PasswordScore.VeryWeak, PasswordStrength.CheckStrength("Hello2"));
        }

        [TestMethod]
        public void CheckStrengthReturnsMediumForPasswordOfHelloWorld()
        {
            Assert.AreEqual(PasswordScore.Medium, PasswordStrength.CheckStrength("HelloWorld"));
        }

        [TestMethod]
        public void CheckStrengthReturnsStrongForPasswordOfHelloWorld69()
        {
            Assert.AreEqual(PasswordScore.Strong, PasswordStrength.CheckStrength("HelloWorld69"));
        }

        [TestMethod]
        public void CheckStrengthReturnsVeryStrongForPasswordOfHelloWorld69WithExclaimationMark()
        {
            Assert.AreEqual(PasswordScore.VeryStrong, PasswordStrength.CheckStrength("HelloWorld69!"));
        }

        [TestMethod]
        public void CheckStrengthReturnsStrongForPasswordOf1234HelloWorld69()
        {
            Assert.AreEqual(PasswordScore.Strong, PasswordStrength.CheckStrength("1234HelloWorld69"));
        }

        [TestMethod]
        public void CheckStrengthReturnsVeryStrongForPasswordOf1234HelloWorld69WithExclaimationMark()
        {
            Assert.AreEqual(PasswordScore.VeryStrong, PasswordStrength.CheckStrength("!1234HelloWorld69"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfPasswordOnTheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("password"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfTrustNoOne1OnTheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("trustno1"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfTRUSTNO1OnTheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("TRUSTNO1"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfP455w9rdOnTheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("p455w0rd"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfTrustN01TheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("trustn01"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfW3lc0m3TheWeakPasswordList()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("w3lc0m3"));
        }

        [TestMethod]
        public void CheckStrengthReturnsWeakForPasswordOfPasswordOnTheWeakPasswordListIncludingNonCharacters()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("p@$$w0rd"));
        }
    }
}
