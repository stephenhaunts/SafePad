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
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class GZipCompression : ICompression
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public byte[] Compress(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            byte[] output;

            using (var ms = new MemoryStream())
            {
                var gs = new GZipStream(ms, CompressionMode.Compress);
                gs.Write(input, 0, input.Length);
                gs.Close();

                output = ms.ToArray();

                ms.Close();
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public byte[] Decompress(byte[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var output = new List<byte>();

            using (var ms = new MemoryStream(input))
            {
                var gs = new GZipStream(ms, CompressionMode.Decompress);
                var readByte = gs.ReadByte();

                while (readByte != -1)
                {
                    output.Add((byte)readByte);
                    readByte = gs.ReadByte();
                }

                gs.Close();
                ms.Close();
            }

            return output.ToArray();
        }
    }
}
