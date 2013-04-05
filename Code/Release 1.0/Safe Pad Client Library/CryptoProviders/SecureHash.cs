using System;
using System.Security.Cryptography;

namespace HauntedHouseSoftware.SecureNotePad.CryptoProviders
{
    public class SecureHash : ISecureHash
    {        
        public byte[] ComputeHash(byte[] toBeHashed)
        {
            if (toBeHashed == null)
            {
                throw new ArgumentNullException("toBeHashed");
            }

            if (toBeHashed.Length == 0)
            {
                throw new InvalidOperationException("toBeHashed");
            }

            using (var mySha256 = SHA256.Create())
            {
                return mySha256.ComputeHash(toBeHashed);
            }
        }       
    }
}