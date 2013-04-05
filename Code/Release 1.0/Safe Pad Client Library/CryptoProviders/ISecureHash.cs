namespace HauntedHouseSoftware.SecureNotePad.CryptoProviders
{
    public interface ISecureHash
    {
        byte [] ComputeHash(byte [] toBeHashed);
    }
}
