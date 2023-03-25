using System.Text;

namespace TextCryptor.Cryptors
{
    public class DoublePermutationCryptor : ICryptor
    {
        private readonly string _key;

        public DoublePermutationCryptor(string key)
        {
            _key = key;
        }

        public string Decrypt(string cryptedText)
        {
            int[] keyArr = Array.ConvertAll(_key.Split(' '), int.Parse);

            int numColumns = keyArr.Length;
            int numRows = cryptedText.Length / numColumns;
            var grid = new char[numRows, numColumns];
            int index = 0;
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    grid[i, j] = cryptedText[index];
                    index++;
                }
            }

            var decryptedGrid = new char[numRows, numColumns];
            for (var i = 0; i < keyArr.Length; i++)
            {
                int oldColumnIndex = keyArr[i] - 1;
                int newColumnIndex = i;
                for (var j = 0; j < numRows; j++)
                {
                    decryptedGrid[j, newColumnIndex] = grid[j, oldColumnIndex];
                }
            }

            for (var i = 0; i < keyArr.Length; i++)
            {
                int columnIndex = i;
                var column = new char[numRows];
                for (var j = 0; j < numRows; j++)
                {
                    column[j] = decryptedGrid[j, columnIndex];
                }
                Array.Sort(column);
                for (var j = 0; j < numRows; j++)
                {
                    decryptedGrid[j, columnIndex] = column[j];
                }
            }

            var decryptedText = new StringBuilder();
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    decryptedText.Append(decryptedGrid[i, j]);
                }
            }
            return decryptedText.ToString();
        }

        public string Encrypt(string plainText)
        {
            int[] keyArr = Array.ConvertAll(_key.Split(' '), int.Parse);

            var numColumns = keyArr.Length;
            var numRows = (int)Math.Ceiling((double)plainText.Length / numColumns);
            var grid = new char[numRows, numColumns];

            int index = 0;
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    if (index < plainText.Length)
                    {
                        grid[i, j] = plainText[index];
                        index++;
                    }
                    else
                    {
                        grid[i, j] = (char)new Random().Next(65, 91);
                    }
                }
            }

            for (int i = 0; i < keyArr.Length; i++)
            {
                int columnIndex = keyArr[i] - 1;
                var column = new char[numRows];
                for (var j = 0; j < numRows; j++)
                {
                    column[j] = grid[j, columnIndex];
                }
                Array.Sort(column);
                for (var j = 0; j < numRows; j++)
                {
                    grid[j, columnIndex] = column[j];
                }
            }

            var encryptedGrid = new char[numRows, numColumns];
            for (int i = 0; i < keyArr.Length; i++)
            {
                int oldColumnIndex = i;
                int newColumnIndex = keyArr[i] - 1;
                for (var j = 0; j < numRows; j++)
                {
                    encryptedGrid[j, newColumnIndex] = grid[j, oldColumnIndex];
                }
            }

            var encryptedText = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    encryptedText.Append(encryptedGrid[i, j]);
                }
            }
            return encryptedText.ToString();
        }
    }
}
