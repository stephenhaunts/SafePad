
namespace HauntedHouseSoftware.SecureNotePad.DomainObjects.FileFormat
{
    public interface IFileFormatLoader
    {
        byte[] Load(byte[] byteStream);
    }
}
