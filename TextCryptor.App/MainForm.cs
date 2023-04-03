using System.Text.RegularExpressions;
using System.Windows.Forms;
using TextCryptor.Cryptors;

namespace TextCryptor.App;

public partial class MainForm : Form
{
    private ICryptorFactory _cryptorFactory = new CryptorFactory();

    public MainForm()
    {
        InitializeComponent();
    }

    private string SelectedMode() =>
        singlePermutRadioButton.Checked ? "singlepermut" : "doublepermut";

    private void encryptButton_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
        {
            return;
        }
        try
        {
            var textToEncrypt = originalRichTextBox.Text;
            var key = keyTextBox.Text;
            var cryptor = _cryptorFactory.CreateCryptor(SelectedMode(), key);
            resultRichTextBox.Text = cryptor?.Encrypt(textToEncrypt);
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }

    }

    private void decryptButton_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
        {
            return;
        }
        try
        {
            var textToEncrypt = originalRichTextBox.Text;
            var key = keyTextBox.Text;
            var cryptor = _cryptorFactory.CreateCryptor(SelectedMode(), key);
            resultRichTextBox.Text = cryptor?.Decrypt(textToEncrypt);
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private bool ValidateInput()
    {
        var isValid = true;
        if (String.IsNullOrWhiteSpace(originalRichTextBox.Text))
        {
            isValid = false;
            ShowError("Не введено жодного символа для опрацювання!");
        }
        if (String.IsNullOrWhiteSpace(keyTextBox.Text))
        {
            isValid = false;
            ShowError("Не введено жодного символа в полі Ключ!");
        }
        else
        {
            keyTextBox.Text = keyTextBox.Text.Trim();
        }
        if (singlePermutRadioButton.Checked)
        {
            if (!keyTextBox.Text.Distinct().SequenceEqual(keyTextBox.Text))
            {
                isValid = false;
                ShowError("Ключ не має містити повторюваних символів!");
            }
        }
        else if (!new Regex(@"^\d+(\s\d+)*\s\|\s\d+(\s\d+)*$").IsMatch(keyTextBox.Text))
        {
            isValid = false;
            ShowError("Невірний формат вводу! Формат: 1 2 | 3 4 (числа через пробіл)");
        }
        else
        {
            var key1 = keyTextBox.Text.Split("|",
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
                .FirstOrDefault()
                ?? String.Empty;
            var key2 = keyTextBox.Text.Split("|",
                StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries)
                .LastOrDefault()
                ?? String.Empty;
            int[] keyArr1 = Array.ConvertAll(key1.Split(' '), int.Parse);
            int[] keyArr2 = Array.ConvertAll(key2.Split(' '), int.Parse);
            int numColumns = keyArr2.Length;
            int numRows = originalRichTextBox.Text.Length / numColumns
                + (originalRichTextBox.Text.Length % numColumns != 0 ? 1 : 0);
            if (keyArr1.Length != numRows)
            {
                isValid = false;
                ShowError($"Кількість рядків невірна, має бути {numRows}, ви ввели {keyArr1.Length}!");
            }
        }
        return isValid;
    }

    private static DialogResult ShowError(string message)
        => MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
}