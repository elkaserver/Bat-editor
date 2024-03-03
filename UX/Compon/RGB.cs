using System;
using System.Drawing;
using System.Windows.Forms;

namespace UX
{
    public partial class Form1 : Form
    {
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = { "echo", "exit", "pause" };
            Color color = Color.Red;

            int selectionStart = richTextBox1.SelectionStart;
            int selectionLenght = richTextBox1.SelectionLength;

            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionColor = richTextBox1.ForeColor;


            foreach (var word in words)
            {
                int startIndex = 0;
                while (startIndex < richTextBox1.TextLength)
                {
                    int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex != -1)
                    {
                        richTextBox1.SelectionStart = wordStartIndex;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionColor = color;

                        startIndex = wordStartIndex + word.Length;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            richTextBox1.SelectionStart = selectionStart;
            richTextBox1.SelectionLength = selectionLenght;
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }
    }
}
