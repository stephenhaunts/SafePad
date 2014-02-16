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
using System.Text;
using HauntedHouseSoftware.SecureNotePad.CryptoProviders;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class Password : IPassword
    {
        private readonly byte[] _password1;
        private readonly byte[] _password2;

        private readonly byte[] _bCryptPassword1;
        private readonly byte[] _bCryptPassword2;

        private readonly byte[] _combinedPasswords;

        public Password(string password1, string password2)
        {
            if (string.IsNullOrEmpty(password1))
            {
                throw new ArgumentNullException("password1");
            }

            string optionalPassword2;

            if (password2 == null)
            {
                optionalPassword2 = string.Empty;
            }
            else
            {
                optionalPassword2 = password2;
            }

            _password1 = new SecureHash().ComputeHash(Encoding.ASCII.GetBytes(password1));
            _password2 = new SecureHash().ComputeHash(Encoding.ASCII.GetBytes(optionalPassword2));

            _bCryptPassword1 = new BCryptHash().ComputeHash(Encoding.ASCII.GetBytes(password1));
            _bCryptPassword2 = new BCryptHash().ComputeHash(Encoding.ASCII.GetBytes(optionalPassword2));

            _combinedPasswords = new BCryptHash().ComputeHash(Encoding.ASCII.GetBytes(password1 + optionalPassword2));
        }

        public byte[] Password1
        {
            get
            {
                return _password1;
            }
        }

        public byte[] Password2
        {
            get
            {
                return _password2;
            }
        }

        public byte[] BCryptPassword1
        {
            get
            {
                return _bCryptPassword1;
            }
        }

        public byte[] BCryptPassword2
        {
            get
            {
                return _bCryptPassword2;
            }
        }

        public byte[] CombinedPasswords
        {
            get
            {
                return _combinedPasswords;
            }
        }
    }
}
