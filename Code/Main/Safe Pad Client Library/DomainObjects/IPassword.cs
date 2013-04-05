namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public interface IPassword
    {
        byte[] Password1 { get; }
        byte[] Password2 { get; }
    }
}