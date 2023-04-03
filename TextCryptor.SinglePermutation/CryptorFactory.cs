namespace TextCryptor.Cryptors
{
    public class CryptorFactory : ICryptorFactory
    {
        public ICryptor? CreateCryptor(string type, string key) =>
            type switch
            {
                "singlepermut" => new SinglePermutationCryptor(key),
                "doublepermut" => new DoublePermutationCryptor(key),
                _ => null,
            };
    }
}
