namespace TextCryptor.Cryptors
{
    public interface ICryptorFactory
    {
        ICryptor? CreateCryptor(string type, string key);
    }
}
