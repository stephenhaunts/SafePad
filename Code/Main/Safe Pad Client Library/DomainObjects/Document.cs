using System;
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;

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
        private const byte Minor = 0;

        public byte[] EncodedData { get; set; }        

        public Document(IPassword password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            _aes = new AES();
            _secureHash = new SecureHash();
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

            var versionNumber = ByteHelpers.CreateSpecialByteArray(2);
            var hash = ByteHelpers.CreateSpecialByteArray(32);
            var encrypted = ByteHelpers.CreateSpecialByteArray((buffer.Length - 34));

            SplitFileIntoChunks(buffer, versionNumber, hash, encrypted);
            EncodedData = DecryptData(encrypted);            

            CheckFileIntegrity(hash, encrypted);
        }

        public void Save(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var encrypted3 = EncryptData();

            var hash = _secureHash.ComputeHash(encrypted3);
            var versionNumber = new[] { Major, Minor };

            SaveFormattedFile(fileName, encrypted3, hash, versionNumber);
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

        private void SaveFormattedFile(string fileName, byte[] encrypted3, byte[] hash, byte[] versionNumber)
        {
            var tempCombined = ByteHelpers.Combine(versionNumber, hash);
            var combined = ByteHelpers.Combine(tempCombined, encrypted3);

            _fileProxy.Save(fileName, combined);
        }

        private byte[] EncryptData()
        {
            var compressed = _compression.Compress(EncodedData);
            var encrypted = _aes.Encrypt(compressed, Convert.ToBase64String(_password.Password1));
            var encrypted2 = _aes.Encrypt(encrypted, Convert.ToBase64String(_password.Password2));
            var encrypted3 = _aes.Encrypt(encrypted2, Convert.ToBase64String(_password.Password1));

            return encrypted3;
        }   
    }
}