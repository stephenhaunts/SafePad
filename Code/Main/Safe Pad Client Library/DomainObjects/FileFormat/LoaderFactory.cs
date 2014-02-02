/**
 * Safe Pad, a double encrypted note pad that uses 2 passwords to protect your documents and help you keep your privacy.
 * 
 * Copyright (C) 2014 Stephen Haunts
 * http://www.stephenhaunts.com
 * 
 * This file is part of MupenSafe Pad64PlusAE.
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
