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
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;
using HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat;
using System.Text;
using System.Security.Cryptography;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class Document : IDocument
    {
        private readonly IAES _aes;
        private readonly ISecureHash _secureHash;
        private readonly IPassword _password;
        private readonly ICompression _compression;
        private readonly IFileProxy _fileProxy;

        private const byte Major = 1;
        private const byte Minor = 1;

        public byte[] EncodedData { get; set; }

        public Document(IPassword password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            _aes = new AES();
            _secureHash = new BCryptHash();
            _password = password;
            _fileProxy = new FileProxy();
            _compression = new GZipCompression();
        }

        public Document(IAES aes, ISecureHash hash, ICompression compression, IPassword password, IFileProxy fileProxy)
        {
            if (aes == null)
            {
                throw new ArgumentNullException("aes");
            }

            if (hash == null)
            {
                throw new ArgumentNullException("hash");
            }

            if (compression == null)
            {
                throw new ArgumentNullException("compression");
            }

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (fileProxy == null)
            {
                throw new ArgumentNullException("fileProxy");
            }

            _aes = aes;
            _secureHash = hash;
            _compression = compression;
            _password = password;
            _fileProxy = fileProxy;
        }

        protected IAES AesProvider
        {
            get
            {
                return _aes;
            }
        }

        protected ISecureHash SecureHashProvider
        {
            get
            {
                return _secureHash;
            }
        }

        protected ICompression CompressionProvider
        {
            get
            {
                return _compression;
            }
        }

        protected IPassword Password
        {
            get
            {
                return _password;
            }
        }

        public void Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var buffer = _fileProxy.Load(fileName);
            var loader = new LoaderFactory();
            var fileLoader = loader.GetFileLoader(buffer, _password);
            EncodedData = fileLoader.Load(buffer);
        }

        public void Save(string fileName)
        {
            
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var salt = GenerateSalt(32);
            var encrypted3 = EncryptData(salt);
            
            var hash = new SecureHash().ComputeHash(encrypted3);
            var versionNumber = new [] { Major, Minor };

            SaveFormattedFile(fileName, encrypted3, hash, salt,  versionNumber);
        }
        private void SaveFormattedFile(string fileName, byte[] encrypted3, byte[] hash, byte[] salt, byte[] versionNumber)
        {
            var tempCombined = ByteHelpers.Combine(versionNumber, salt);
            var temp2Combined = ByteHelpers.Combine(tempCombined, hash);
            var combined = ByteHelpers.Combine(temp2Combined, encrypted3);

            _fileProxy.Save(fileName, combined);
        }

        private byte[] EncryptData(byte[] salt)
        {
            var compressed = _compression.Compress(EncodedData);
            var encrypted = _aes.Encrypt(compressed, Convert.ToBase64String(_password.CombinedPasswords), salt, 40000);
            
            return encrypted;
        }

        public static byte[] GenerateSalt(int length)
        {
            using (RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
