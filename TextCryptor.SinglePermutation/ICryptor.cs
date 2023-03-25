namespace TextCryptor.SinglePermutation
{
    public interface ICryptor
    {
        string Encrypt(string plainText);
        string Decrypt(string cryptedText);
    }
}
