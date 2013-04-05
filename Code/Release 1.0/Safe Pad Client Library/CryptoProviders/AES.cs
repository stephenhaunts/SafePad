using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HauntedHouseSoftware.SecureNotePad.CryptoProviders
{
    public class AES : IAES
    {        
        public byte[] Encrypt(byte[] dataToEncrypt, string password)
        {
            if (dataToEncrypt == null)
            {
                throw new ArgumentNullException("dataToEncrypt");
            }

            if (dataToEncrypt.Length == 0)
            {
                throw new InvalidOperationException("dataToEncrypt");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            try
            {                
                using (var rfc2898 = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes("eryryn78ynr78yn"), 1000))
                {                    
                    using (var aes = new AesManaged())
                    {
                        aes.Key = rfc2898.GetBytes(32);
                        aes.IV = rfc2898.GetBytes(16);
                       
                        using (var memoryStream = new MemoryStream())
                        {                                                      
                            var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                            cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                            cryptoStream.FlushFinalBlock();

                            var toReturn = memoryStream.ToArray();

                            return toReturn;                          
                        }
                    }
                }
            }
            catch
            {
                return null;
            }           
        }

        public byte[] Decrypt(byte[] dataToDecrypt, string password)
        {
            if (dataToDecrypt == null)
            {
                throw new ArgumentNullException("dataToDecrypt");
            }

            if (dataToDecrypt.Length == 0)
            {
                throw new InvalidOperationException("dataToDecrypt");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }
        
            try
            {
                using (var rfc2898 = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes("eryryn78ynr78yn"), 1000))
                {
                    using (var aes = new AesManaged())
                    {
                        aes.Key = rfc2898.GetBytes(32);
                        aes.IV = rfc2898.GetBytes(16);

                        using (var memoryStream = new MemoryStream())
                        {
                            var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                            
                            cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                            cryptoStream.FlushFinalBlock();

                            var decryptBytes = memoryStream.ToArray();                          

                            return decryptBytes;                            
                        }
                    }
                }
            }
            catch
            {
                return null;
            }           
        }       
    }
}