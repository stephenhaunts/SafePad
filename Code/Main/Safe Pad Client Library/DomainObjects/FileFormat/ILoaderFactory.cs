namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat
{
    public interface ILoaderFactory
    {
        IFileFormatLoader GetFileLoader(byte[] byteStream, IPassword password);
    }
}
