namespace TextCryptor.Cryptors
{
    public interface ICryptor
    {
        string Encrypt(string plainText);
        string Decrypt(string cryptedText);
    }
}
