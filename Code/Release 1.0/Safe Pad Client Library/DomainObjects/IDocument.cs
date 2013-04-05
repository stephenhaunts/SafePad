namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public interface IDocument
    {
        byte[] EncodedData { get; set; }
        void Load(string fileName);
        void Save(string fileName);
    }
}