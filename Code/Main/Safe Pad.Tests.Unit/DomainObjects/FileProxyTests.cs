using System;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects
{
    [TestClass]
    public class FileProxyTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void LoadThrowsArgumentNullExceptionIfFilenameIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Load(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "fileName")]
        public void SaveThrowsArgumentNullExceptionIfFilenameIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Save(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "dataToSave")]
        public void SaveThrowsArgumentNullExceptionIfDataToSaveIsNull()
        {
            IFileProxy proxy = new FileProxy();
            proxy.Save("file.txt", null);
        }
    }
}
