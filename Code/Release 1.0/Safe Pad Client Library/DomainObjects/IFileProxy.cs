namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public interface IFileProxy
    {
        byte[] Load(string fileName);
        void Save(string fileName, byte[] dataToSave);
    }
}
