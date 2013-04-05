namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public interface ICompression
    {
        byte[] Compress(byte[] input);
        byte[] Decompress(byte[] input);
    }
}
