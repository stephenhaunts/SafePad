using System;
using System.Text;
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class Password : IPassword
    {
        private readonly byte[] _password1;
        private readonly byte[] _password2;

        public Password(string password1, string password2)
        {
            if (string.IsNullOrEmpty(password1))
            {
                throw new ArgumentNullException("password1");
            }

            if (string.IsNullOrEmpty(password2))
            {
                throw new ArgumentNullException("password2");
            }

            _password1 = new SecureHash().ComputeHash(Encoding.ASCII.GetBytes(password1));
            _password2 = new SecureHash().ComputeHash(Encoding.ASCII.GetBytes(password2));
        }

        public byte[] Password1
        {
            get { return _password1; }
        }

        public byte[] Password2
        {
            get { return _password2; }
        }
    }
}
