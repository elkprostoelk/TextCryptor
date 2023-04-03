using System.Text;

namespace TextCryptor.Cryptors
{
    public class DoublePermutationCryptor : ICryptor
    {
        private readonly string _key1;
        private readonly string _key2;

        public DoublePermutationCryptor(string key)
        {
            _key1 = key.Split("|",
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
                .FirstOrDefault()
                ?? String.Empty;
            _key2 = key.Split("|",
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
                .LastOrDefault()
                ?? String.Empty;
        }

        public string Decrypt(string cryptedText)
        {
            int[] keyArr1 = Array.ConvertAll(_key1.Split(' '), int.Parse);
            int[] keyArr2 = Array.ConvertAll(_key2.Split(' '), int.Parse);

            int numColumns = keyArr2.Length;
            int numRows = cryptedText.Length / numColumns;

            var grid = TextToGrid(cryptedText, numRows, numColumns);

            var swappedRowsGrid = new char[numRows, numColumns];
            for (var i = 0; i < numRows; i++)
            {
                var newRow = keyArr1[i] - 1;
                for (var j = 0; j < numColumns; j++)
                {
                    swappedRowsGrid[i, j] = grid[newRow, j];
                }
            }
            var decryptedGrid = new char[numRows, numColumns];
            for (var i = 0; i < numColumns; i++)
            {
                var newCol = keyArr2[i] - 1;
                for (var j = 0; j < numRows; j++)
                {
                    decryptedGrid[j, i] = swappedRowsGrid[j, newCol];
                }
            }

            return GridToText(decryptedGrid, numRows, numColumns).Replace("*", "");
        }

        public string Encrypt(string plainText)
        {
            int[] keyArr1 = Array.ConvertAll(_key1.Split(' '), int.Parse);
            int[] keyArr2 = Array.ConvertAll(_key2.Split(' '), int.Parse);

            int numColumns = keyArr2.Length;
            int numRows = plainText.Length / numColumns
                + (plainText.Length % numColumns != 0 ? 1 : 0);
            
            var grid = TextToGrid(plainText, numRows, numColumns);
            var swappedColumnsGrid = new char[numRows, numColumns];
            for (var i = 0; i < numColumns; i++)
            {
                var newColumn = keyArr2[i] - 1;
                for (var j = 0; j < numRows; j++)
                {
                    swappedColumnsGrid[j, newColumn] = grid[j, i];
                }
            }
            var encryptedGrid = new char[numRows, numColumns];
            for (var i = 0; i < numRows; i++)
            {
                var newRow = keyArr1[i] - 1;
                for (var j = 0; j < numColumns; j++)
                {
                    encryptedGrid[newRow, j] = swappedColumnsGrid[i, j];
                }
            }
            return GridToText(encryptedGrid, numRows, numColumns);
        }

        private static char[,] TextToGrid(string text, int numRows, int numColumns)
        {
            var grid = new char[numRows, numColumns];

            int index = 0;
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    if (index < text.Length)
                    {
                        grid[i, j] = text[index];
                        index++;
                    }
                    else
                    {
                        grid[i, j] = '*';
                    }
                }
            }

            return grid;
        }

        private static string GridToText(char[,] grid, int numRows, int numColumns)
        {
            var text = new StringBuilder();
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < numColumns; j++)
                {
                    text.Append(grid[i, j]);
                }
            }

            return text.ToString();
        }
    }
}
