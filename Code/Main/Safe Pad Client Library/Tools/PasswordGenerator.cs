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
using System.Security.Cryptography;
using System.Text;

namespace HauntedHouseSoftware.SecureNotePad.Tools
{
    public static class PasswordGenerator
    {
        public static string Generate(int passwordLength)
        {
            if (passwordLength == 0)
            {
                throw new InvalidOperationException("passwordLength");
            }

            string password;

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {                
                byte[] randomNumber = new byte[64];
                randomNumberGenerator.GetBytes(randomNumber);

                password = Convert.ToBase64String(randomNumber);
            }

            return password;
        }
    }
}
