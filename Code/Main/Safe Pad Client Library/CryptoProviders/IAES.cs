namespace HauntedHouseSoftware.SecureNotePad.CryptoProviders
{
    public interface IAES
    {
        byte[] Decrypt(byte[] dataToDecrypt, string password);
        byte[] Encrypt(byte[] dataToEncrypt, string password);
    }
}
