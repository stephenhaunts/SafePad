﻿/**
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

namespace HauntedHouseSoftware.SecureNotePad.CryptoProviders
{
    public class BCryptHash : ISecureHash
    {
        private const string _salt = "$2a$10$67C.GOM1jShOBOM.f.BIAe";

        public byte[] ComputeHash(byte[] toBeHashed)
        {
            if (toBeHashed == null)
            {
                throw new ArgumentNullException("toBeHashed");
            }

            return Encoding.ASCII.GetBytes(BCrypt.Net.BCrypt.HashPassword(ASCIIEncoding.ASCII.GetString(toBeHashed), _salt));            
        }       
    }
}