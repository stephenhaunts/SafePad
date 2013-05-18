using System;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat
{
   public class LoaderFactory : ILoaderFactory
    {
       public IFileFormatLoader GetFileLoader(byte[] byteStream, IPassword password)
       {
           if (byteStream == null)
           {
               throw new ArgumentNullException("byteStream");
           }

           if (password == null)
           {
               throw new ArgumentNullException("password");
           }

           switch(GetVersionNumber(byteStream))
           {
               case "1.0":
                   return new Version10Loader(password);
               default:
                   break;                   
           }

           throw new InvalidOperationException("The file is not a supported file format version.");
       }

       private static string GetVersionNumber(byte[] byteStream)
       {
           var versionNumber = ByteHelpers.CreateSpecialByteArray(2);
           Buffer.BlockCopy(byteStream, 0, versionNumber, 0, 2);

           var version = String.Format("{0}.{1}", versionNumber[0], versionNumber[1]);
           
           return version;
       }
    }
}
