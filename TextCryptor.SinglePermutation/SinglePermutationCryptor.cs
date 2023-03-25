using System.Text;

namespace TextCryptor.Cryptors
{
    public class SinglePermutationCryptor : ICryptor
    {
        private readonly string _key;
        private readonly int _keyLength;

        public SinglePermutationCryptor(string key)
        {
            _key = key;
            _keyLength = key.Length;
        }

        public string Decrypt(string cryptedText)
        {
            int numBlocks = cryptedText.Length / _keyLength;
            var grid = new char[numBlocks, _keyLength];

            var keyArray = _key.ToCharArray();
            Array.Sort(keyArray);
            var permutation = new Dictionary<char, int>();
            for (var i = 0; i < _keyLength; i++)
            {
                permutation.Add(keyArray[i], i);
            }

            int index = 0;
            for (int i = 0; i < _keyLength; i++)
            {
                int col = permutation[keyArray[i]];
                for (var j = 0; j < numBlocks; j++)
                {
                    grid[j, col] = cryptedText[index];
                    index++;
                }
            }

            var decryptedtextBuilder = new StringBuilder();
            for (int i = 0; i < numBlocks; i++)
            {
                for (var j = 0; j < _keyLength; j++)
                {
                    decryptedtextBuilder.Append(grid[i, j]);
                }
            }

            string decryptedtext = decryptedtextBuilder.ToString();
            decryptedtext = decryptedtext.Replace("*", String.Empty);

            return decryptedtext;
        }

        public string Encrypt(string plainText)
        {
            if (plainText.Length % _keyLength != 0)
            {
                plainText = PadPlainText(plainText, _keyLength);
            }

            int numBlocks = plainText.Length / _keyLength;
            var grid = new char[numBlocks, _keyLength];

            for (var i = 0; i < numBlocks; i++)
            {
                for (var j = 0; j < _keyLength; j++)
                {
                    grid[i, j] = plainText[i * _keyLength + j];
                }
            }

            var keyArray = _key.ToCharArray();
            Array.Sort(keyArray);
            var permutation = new Dictionary<char, int>();
            for (var i = 0; i < _keyLength; i++)
            {
                permutation.Add(keyArray[i], i);
            }

            var ciphertextBuilder = new StringBuilder();
            for (var i = 0; i < _keyLength; i++)
            {
                int col = permutation[keyArray[i]];
                for (var j = 0; j < numBlocks; j++)
                {
                    ciphertextBuilder.Append(grid[j, col]);
                }
            }

            return ciphertextBuilder.ToString();
        }

        private static string PadPlainText(string plainText, int keyLength)
        {
            int numPadChars = keyLength - (plainText.Length % keyLength);
            for (var i = 0; i < numPadChars; i++)
            {
                plainText += "*";
            }
            return plainText;
        }
    }
}
