namespace TextCryptor.App;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        originalRichTextBox = new RichTextBox();
        resultRichTextBox = new RichTextBox();
        singlePermutRadioButton = new RadioButton();
        doublePermutRadioButton = new RadioButton();
        encryptButton = new Button();
        decryptButton = new Button();
        keyTextBox = new TextBox();
        label1 = new Label();
        SuspendLayout();
        // 
        // originalRichTextBox
        // 
        originalRichTextBox.Location = new Point(12, 56);
        originalRichTextBox.Name = "originalRichTextBox";
        originalRichTextBox.Size = new Size(305, 286);
        originalRichTextBox.TabIndex = 0;
        originalRichTextBox.Text = "";
        // 
        // resultRichTextBox
        // 
        resultRichTextBox.Location = new Point(493, 56);
        resultRichTextBox.Name = "resultRichTextBox";
        resultRichTextBox.ReadOnly = true;
        resultRichTextBox.Size = new Size(305, 286);
        resultRichTextBox.TabIndex = 0;
        resultRichTextBox.Text = "";
        // 
        // singlePermutRadioButton
        // 
        singlePermutRadioButton.AutoSize = true;
        singlePermutRadioButton.Checked = true;
        singlePermutRadioButton.Location = new Point(327, 57);
        singlePermutRadioButton.Name = "singlePermutRadioButton";
        singlePermutRadioButton.Size = new Size(156, 19);
        singlePermutRadioButton.TabIndex = 1;
        singlePermutRadioButton.TabStop = true;
        singlePermutRadioButton.Text = "Одинарні перестановки";
        singlePermutRadioButton.UseVisualStyleBackColor = true;
        // 
        // doublePermutRadioButton
        // 
        doublePermutRadioButton.AutoSize = true;
        doublePermutRadioButton.Location = new Point(327, 82);
        doublePermutRadioButton.Name = "doublePermutRadioButton";
        doublePermutRadioButton.Size = new Size(152, 19);
        doublePermutRadioButton.TabIndex = 2;
        doublePermutRadioButton.TabStop = true;
        doublePermutRadioButton.Text = "Подвійні перестановки";
        doublePermutRadioButton.UseVisualStyleBackColor = true;
        // 
        // encryptButton
        // 
        encryptButton.Location = new Point(350, 229);
        encryptButton.Name = "encryptButton";
        encryptButton.Size = new Size(120, 34);
        encryptButton.TabIndex = 3;
        encryptButton.Text = "Зашифрувати";
        encryptButton.UseVisualStyleBackColor = true;
        encryptButton.Click += encryptButton_Click;
        // 
        // decryptButton
        // 
        decryptButton.Location = new Point(350, 289);
        decryptButton.Name = "decryptButton";
        decryptButton.Size = new Size(120, 34);
        decryptButton.TabIndex = 3;
        decryptButton.Text = "Дешифрувати";
        decryptButton.UseVisualStyleBackColor = true;
        decryptButton.Click += decryptButton_Click;
        // 
        // keyTextBox
        // 
        keyTextBox.Location = new Point(341, 154);
        keyTextBox.Name = "keyTextBox";
        keyTextBox.Size = new Size(138, 23);
        keyTextBox.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(389, 127);
        label1.Name = "label1";
        label1.Size = new Size(38, 15);
        label1.TabIndex = 5;
        label1.Text = "Ключ";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(810, 372);
        Controls.Add(label1);
        Controls.Add(keyTextBox);
        Controls.Add(decryptButton);
        Controls.Add(encryptButton);
        Controls.Add(doublePermutRadioButton);
        Controls.Add(singlePermutRadioButton);
        Controls.Add(resultRichTextBox);
        Controls.Add(originalRichTextBox);
        Name = "MainForm";
        Text = "Шифри";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RichTextBox originalRichTextBox;
    private RichTextBox resultRichTextBox;
    private RadioButton singlePermutRadioButton;
    private RadioButton doublePermutRadioButton;
    private Button encryptButton;
    private Button decryptButton;
    private TextBox keyTextBox;
    private Label label1;
}