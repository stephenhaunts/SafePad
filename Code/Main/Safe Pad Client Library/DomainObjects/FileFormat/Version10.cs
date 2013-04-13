using System;
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat
{
    public class Version10 : IFileFormatLoader
    {
        private readonly IAES _aes;
        private readonly ISecureHash _secureHash;
        private readonly IPassword _password;
        private readonly ICompression _compression;

        public Version10(IPassword password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            _aes = new AES();
            _secureHash = new SecureHash();
            _password = password;            
            _compression = new GZipCompression();
        }

        public byte[] Load(byte[] byteStream)
        {
            if (byteStream == null)
            {
                throw new ArgumentNullException("byteStream");
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
            var decrypted = _aes.Decrypt(encrypted, Convert.ToBase64String(_password.Password1));
            var decrypted2 = _aes.Decrypt(decrypted, Convert.ToBase64String(_password.Password2));
            var decrypted3 = _aes.Decrypt(decrypted2, Convert.ToBase64String(_password.Password1));

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
