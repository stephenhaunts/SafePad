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
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class DocumentTests
    {
        private class TestFileProxy : IFileProxy
        {
            readonly byte[] _savedData = {0x01,0xE5,0x92,0xBC,0xE6,0xA4,0xBE,0xE6,0xA3,0x8D,0xE7,0x9B,0x90,0xED,0xBF,0xB1,
                                          0xED,0x84,0x82,0xEA,0xBD,0x8C,0xEC,0xAA,0xA9,0xE5,0xB7,0x9B,0xE9,0x92,0x9A,0xE8,
                                          0x81,0x83,0xE0,0xAE,0xAC,0xE4,0xAF,0x9C,0xE9,0xB2,0x95,0xE7,0x86,0x99,0xE2,0x9D,
                                          0x82,0xE7,0x83,0x83,0xEE,0x99,0x9F,0xE1,0x8C,0xA5,0xEF,0x92,0x9D,0xE5,0xB5,0xAA,
                                          0xEE,0xB0,0x93,0xE4,0xA0,0x89,0xEC,0x98,0x93,0xEA,0xB1,0x8B,0xE1,0xA5,0x90,0xE9,
                                          0xBB,0x8A,0xE1,0xB8,0xA1,0xED,0xA9,0xA4,0xE5,0xB0,0x9C,0xEF,0x89,0xBA,0xEC,0x8F,
                                          0xB0,0xEF,0x9E,0xAB,0xE7,0x8C,0x93,0xE8,0xAD,0x80,0xE7,0xAE,0xAF,0xEE,0xAB,0xB0,
                                          0xE8,0x87,0x81,0xED,0x9C,0x9E,0xE0,0xB3,0x8B,0xED,0xAB,0xA7,0xED,0x8F,0xBF,0xEF,
                                          0xBA,0x95,0xEA,0xB2,0xA6,0xEB,0x86,0x96,0xE0,0xBA,0xA5,0xEB,0xBA,0xA0,0xE4,0xBD,
                                          0xB0,0xEA,0x81,0x82,0xEA,0x97,0xA8,0xE1,0x9A,0xAB,0xEE,0x93,0x91,0xEF,0x8C,0x9B,
                                          0xEC,0x90,0xA3,0xE6,0xA6,0xB4,0xE2,0xAC,0xA6,0xED,0x85,0xB0,0xED,0xAA,0xAC,0xEE,
                                          0x9D,0x9B,0xEB,0x8F,0x84,0xE6,0x9F,0x8E,0xEC,0xA2,0xB5,0xCA,0xA1,0xE5,0xA3,0xAD,
                                          0xE5,0xB8,0x9D,0xEA,0xAC,0x92,0xE4,0x93,0xAD,0xE3,0xAA,0x8A,0xED,0x97,0xAB,0xE1,
                                          0xBA,0x94,0xE1,0x81,0x81,0xE6,0x92,0xA3,0xEB,0x84,0xA9,0xE9,0x91,0x9F,0xEC,0x91,
                                          0xB9,0xE6,0x99,0x96,0xE7,0x98,0xBE,0xE8,0x8E,0x92,0xD2,0xB4,0xE1,0x9A,0xBC,0xED,
                                          0x8F,0x93,0xEE,0x81,0xB3,0xE8,0x99,0xBB,0xE7,0xAD,0x9C,0xEB,0x92,0x84,0xE2,0xA4,
                                          0x9E,0xE6,0xBF,0x99,0xE2,0xA7,0x94,0xE3,0xAD,0x82,0xEC,0x89,0x9E,0xEF,0xBE,0xB3,
                                          0xE6,0xBB,0x8B,0xE5,0xA7,0xAB,0xE0,0xB5,0x96,0xE8,0xBA,0xB6,0xE6,0x8D,0x81,0xEF,
                                          0xA9,0x9F,0xE5,0xA3,0x90,0xE5,0xAC,0x99,0xE3,0xA0,0x9D,0xEE,0x8B,0x8C,0xE8,0xA5,
                                          0xAE,0xE5,0xB6,0x9B,0xE8,0x88,0xA2};

            public byte[] Load(string fileName)
            {
                return _savedData;
            }

            public void Save(string fileName, byte[] dataToSave)
            {
                
            }

            public bool FileExists(string fileName)
            {
                throw new NotImplementedException();
            }
        }

        private class TestAES : IAes
        {
            public int EncryptCounter;
            public int DecryptCounter;

            private readonly byte[] _savedData = { 0x01, 0xE5, 0x92, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };

            public byte[] Decrypt(byte[] dataToDecrypt, string password, byte[] salt, int bpkdfRounds)
            {
                DecryptCounter++;
                return _savedData;
            }

            public byte[] Encrypt(byte[] dataToEncrypt, string password, byte[] salt, int bpkdfRounds)
            {
                EncryptCounter++;
                return _savedData;
            }
        }

        private class TestCompression : ICompression
        {
            public int CompressCounter;
            public int DecompressCounter;

            private readonly byte[] _savedData = { 0x01, 0xE5, 0x92, 0xBC, 0xE6, 0xA4, 0xBE, 0xE6, 0xA3, 0x8D, 0xE7, 0x9B, 0x90, 0xED, 0xBF, 0xB1 };

            public byte[] Compress(byte[] input)
            {
                CompressCounter++;
                return _savedData; 
            }

            public byte[] Decompress(byte[] input)
            {
                DecompressCounter++;
                return _savedData;                
            }
        }

        private class TestSecureHash : ISecureHash
        {
            public int ComputeHashCounter;

            readonly byte[] _savedData = {0x92,0xBC,0xE6,0xA4,0xBE,0xE6,0xA3,0x8D,0xE7,0x9B,0x90,0xED,0xBF,0xB1,
                                          0xED,0x84,0x82,0xEA,0xBD,0x8C,0xEC,0xAA,0xA9,0xE5,0xB7,0x9B,0xE9,0x92,0x9A,0xE8,
                                          0x81,0x83};

            public byte[] ComputeHash(byte[] toBeHashed)
            {
                ComputeHashCounter++;

                return _savedData;
            }
        }

        private class TestSecureHashInvalidHash : ISecureHash
        {            
            readonly byte[] _savedData = {0x92,0xBC,0xE6,0xA4,0xBE,0xE6,0xA3,0x8D,0xE7,0x9B,0x90,0xED,0xBF,0xB1};

            public byte[] ComputeHash(byte[] toBeHashed)
            {                
                return _savedData;
            }
        }

        private class DocumentOverload : Document
        {
            public DocumentOverload(IPassword password)
                : base(password)
            {
            }

            public DocumentOverload(IAes aes, ISecureHash secureHash, ICompression compression, IPassword password, IFileProxy fileProxy)
                : base(aes, secureHash, compression, password, fileProxy)
            {
            }

            public new IAes AesProvider
            {
                get
                {
                    return base.AesProvider;
                }
            }

            public new ISecureHash SecureHashProvider
            {
                get
                {
                    return base.SecureHashProvider;
                }
            }

            public new ICompression CompressionProvider
            {
                get
                {
                    return base.CompressionProvider;
                }
            }

            public new IPassword Password
            {
                get
                {
                    return base.Password;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfPasswordNullOnStandardConstructor()
        {            
            new DocumentOverload(null);            
        }

        [TestMethod]
        public void DocumentConstructorSetsPassword()
        {
            IPassword password = new Password("password1", "password2");
            var document = new DocumentOverload(password);

            Assert.IsNotNull(document.Password);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "aes")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfAESProviderNullOnOverloadedConstructor()
        {
            new DocumentOverload(null, null, null, null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "securehash")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfSecureHashProviderNullOnOverloadedConstructor()
        {
            IAes aes = new Aes();

            new DocumentOverload(aes, null, null, null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "compression")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfCompressionNullOnOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();

            new DocumentOverload(aes, hash, null, null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfPasswordNullOnOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            ICompression compression = new GZipCompression();

            new DocumentOverload(aes, hash, compression, null, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.DocumentTests+DocumentOverload"), TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void DocumentConstructorThrowsArgumentNullExceptionIfFileProxyNullOnOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            ICompression compression = new GZipCompression();
            IPassword password = new Password("password1", "password2");

            new DocumentOverload(aes, hash, compression, password, null);
        }

        [TestMethod]
        public void DocumentConstructorAssignsAESFromTheOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            Assert.AreEqual(aes, document.AesProvider);
        }

        [TestMethod]
        public void DocumentConstructorAssignsSecureHashFromTheOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            Assert.AreEqual(hash, document.SecureHashProvider);
        }

        [TestMethod]
        public void DocumentConstructorAssignsCompressionFromTheOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            Assert.AreEqual(compression, document.CompressionProvider);
        }

        [TestMethod]
        public void DocumentConstructorAssignsPasswordFromTheOverloadedConstructor()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            Assert.AreEqual(password, document.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void LoadThrowsArgumentNullExceptionIfFileNameIsNull()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Load(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void LoadOverloadThrowsArgumentNullExceptionIfFileNameIsNull()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Load(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "cachedPassword")]
        public void LoadOverloadThrowsArgumentNullExceptionIfPasswordIsNull()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Load("filename.scp", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void SaveThrowsArgumentNullExceptionIfFileNameIsNull()
        {
            IAes aes = new Aes();
            ISecureHash hash = new SecureHash();
            IPassword password = new Password("password1", "password2");
            IFileProxy fileProxy = new FileProxy();
            ICompression compression = new GZipCompression();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Save(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadDecryptsDataAndThrowsInvalidOperationExceptionIfHashDoesNotMatch()
        {
            IAes aes;
            ISecureHash hash;
            IPassword password;
            IFileProxy fileProxy;
            ICompression compression;
            TestStubsForDocument(out aes, out hash, out password, out fileProxy, out compression);
            hash = new TestSecureHashInvalidHash();

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Load("test.scp");            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadOverloadDecryptsDataAndThrowsInvalidOperationExceptionIfHashDoesNotMatch()
        {
            IAes aes;
            ISecureHash hash;
            IPassword password;
            IFileProxy fileProxy;
            ICompression compression;
            TestStubsForDocument(out aes, out hash, out password, out fileProxy, out compression);
            hash = new TestSecureHashInvalidHash();
            
            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Load("test.scp", password);
        }

        [TestMethod]
        public void SaveEncryptsDataCallsEncrypt1Time()
        {
            IAes aes;
            ISecureHash hash;
            IPassword password;
            IFileProxy fileProxy;
            ICompression compression;
            TestStubsForDocument(out aes, out hash, out password, out fileProxy, out compression);

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Save("test.scp");

            Assert.AreEqual(1, ((TestAES)aes).EncryptCounter);
        }

        [TestMethod]
        public void SaveEncryptsDataCallsCompress1Times()
        {
            IAes aes;
            ISecureHash hash;
            IPassword password;
            IFileProxy fileProxy;
            ICompression compression;
            TestStubsForDocument(out aes, out hash, out password, out fileProxy, out compression);

            var document = new DocumentOverload(aes, hash, compression, password, fileProxy);
            document.Save("test.scp");

            Assert.AreEqual(1, ((TestCompression)compression).CompressCounter);
        }

        private static void TestStubsForDocument(out IAes aes, out ISecureHash hash, out IPassword password, out IFileProxy fileProxy, out ICompression compression)
        {
            aes = new TestAES();
            hash = new TestSecureHash();
            password = new Password("password", "password");
            fileProxy = new TestFileProxy();
            compression = new TestCompression();
        }
    }
}
