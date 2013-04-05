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
                throw new ArgumentNullException("input");
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
                throw new ArgumentNullException("input");
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
