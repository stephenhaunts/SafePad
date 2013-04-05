using System;
using System.IO;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public class FileProxy : IFileProxy
    {
        public byte[] Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var br = new BinaryReader(fs);
                
                var numBytes = new FileInfo(fileName).Length;
                return br.ReadBytes((int)numBytes);                
            }
        }

        public void Save(string fileName, byte[] dataToSave)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            if (dataToSave == null)
            {
                throw new ArgumentNullException("dataToSave");
            }

            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(dataToSave, 0, dataToSave.Length);             
            }
        }
    }
}
