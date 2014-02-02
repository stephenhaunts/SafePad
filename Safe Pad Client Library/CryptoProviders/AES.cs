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