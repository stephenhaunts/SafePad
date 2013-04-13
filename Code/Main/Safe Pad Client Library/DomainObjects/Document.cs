using System;
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;
using HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat;

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

            var encrypted3 = EncryptData();

            var hash = _secureHash.ComputeHash(encrypted3);
            var versionNumber = new[] { Major, Minor };

            SaveFormattedFile(fileName, encrypted3, hash, versionNumber);
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