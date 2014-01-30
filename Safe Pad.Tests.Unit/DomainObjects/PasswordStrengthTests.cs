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
            Assert.AreEqual(PasswordScore.Weak, PasswordStrength.CheckStrength("Hello2"));
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
    }
}
