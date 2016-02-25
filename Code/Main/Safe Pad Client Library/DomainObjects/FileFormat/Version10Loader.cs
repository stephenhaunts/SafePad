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
using System.Text;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat
{
    public class Version10Loader : IFileFormatLoader
    {
        private readonly IAes _aes;
        private readonly ISecureHash _secureHash;
        private readonly IPassword _password;
        private readonly ICompression _compression;
        private const string Salt = "eryryn78ynr78yn";

        public Version10Loader(IPassword password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            _aes = new Aes();
            _secureHash = new SecureHash();
            _password = password;
            _compression = new GZipCompression();
        }

        public byte[] Load(byte[] byteStream)
        {
            if (byteStream == null)
            {
                throw new ArgumentNullException(nameof(byteStream));
            }

            var versionNumber = ByteHelpers.CreateSpecialByteArray(2);
            var hash = ByteHelpers.CreateSpecialByteArray(32);
            var encrypted = ByteHelpers.CreateSpecialByteArray((byteStream.Length - 34));

            SplitFileIntoChunks(byteStream, versionNumber, hash, encrypted);
            CheckFileIntegrity(hash, encrypted);

            return DecryptData(encrypted);
        }

        private void CheckFileIntegrity(byte[] hash, byte[] encrypted)
        {
            var computedhash = _secureHash.ComputeHash(encrypted);

            if (!ByteHelpers.ByteArrayCompare(computedhash, hash))
            {
                throw new InvalidOperationException("The signature of the file does not match.");
            }
        }

        private byte[] DecryptData(byte[] encrypted)
        {
            var decrypted = _aes.Decrypt(encrypted, Convert.ToBase64String(_password.Password1), Encoding.ASCII.GetBytes(Salt), 1000);
            var decrypted2 = _aes.Decrypt(decrypted, Convert.ToBase64String(_password.Password2), Encoding.ASCII.GetBytes(Salt), 1000);
            var decrypted3 = _aes.Decrypt(decrypted2, Convert.ToBase64String(_password.Password1), Encoding.ASCII.GetBytes(Salt), 1000);

            var decompressed = _compression.Decompress(decrypted3);

            return decompressed;
        }

        private static void SplitFileIntoChunks(byte[] buffer, byte[] versionNumber, byte[] hash, byte[] encrypted)
        {
            Buffer.BlockCopy(buffer, 0, versionNumber, 0, 2);
            Buffer.BlockCopy(buffer, 2, hash, 0, 32);
            Buffer.BlockCopy(buffer, 34, encrypted, 0, encrypted.Length);
        }
    }
}
