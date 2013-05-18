using System;
using HauntedHouseSoftware.SecureNotePad.DomainObjects;
using HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HauntedHouseSoftware.SecureNotePad.Tests.Unit.DomainObjects.FileFormat
{
    [TestClass]
    public class LoaderFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "byteStream" )]
        public void GetFileLoaderThrowsArgumentNullExceptionIfByteStreamIsNull()
        {
            var loader = new LoaderFactory();
            loader.GetFileLoader(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "password")]
        public void GetFileLoaderThrowsArgumentNullExceptionIfPasswordIsNull()
        {
            var loader = new LoaderFactory();
            byte[] stream = {1, 0};
            loader.GetFileLoader(stream, null);
        }

        [TestMethod]        
        public void GetFileLoaderReturnsLoaderForVersion10Files()
        {
            var loader = new LoaderFactory();
            byte[] stream = { 1, 0 };
            var password = new Password("password", "password2");
            var fileFormatLoader = loader.GetFileLoader(stream, password);

            Assert.AreEqual(typeof(Version10Loader), fileFormatLoader.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The file is not a supported file format version.")]
        public void GetFileLoaderThrowsInValidOperationExceptionForInvalifFileFormat()
        {
            var loader = new LoaderFactory();
            byte[] stream = { 1, 1 };
            var password = new Password("password", "password2");
            var fileFormatLoader = loader.GetFileLoader(stream, password);            
        }
    }
}
