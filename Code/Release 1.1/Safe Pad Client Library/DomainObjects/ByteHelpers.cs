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
using System.Collections;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public sealed class ByteHelpers
    {
        private ByteHelpers()
        {
        }

        public static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1 == null)
            {
                throw new ArgumentNullException("a1");
            }

            if (a2 == null)
            {
                throw new ArgumentNullException("a2");
            }

            IStructuralEquatable eqa1 = a1;
            return eqa1.Equals(a2, StructuralComparisons.StructuralEqualityComparer);
        }

        public static byte[] CreateSpecialByteArray(int length)
        {
            if (length == 0)
            {
                throw new InvalidOperationException("length");
            }

            var arr = new byte[length];

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = 0x20;
            }

            return arr;
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            var ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }      
    }
}
