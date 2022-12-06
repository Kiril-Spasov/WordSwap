using System;
using System.IO;
using System.Windows.Forms;

namespace WordSwap
{
    public partial class FormWordSwap : Form
    {
        public FormWordSwap()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string word1 = "";
            string word2 = "";

            string path = Application.StartupPath + @"\words.txt";
            StreamReader streamReader = new StreamReader(path);

            int linesCount = Convert.ToInt32(streamReader.ReadLine());

            for (int i = 1; i <= linesCount; i++)
            {
                word1 = streamReader.ReadLine();
                word2 = streamReader.ReadLine();

                int coins = CalculateCoins(word1, word2);

                if (coins == 0)
                {
                    TxtResult.Text += $"Swapping letters to make {word1} look like {word2} was FREE" + Environment.NewLine;
                }
                else if (coins > 0)
                {
                    TxtResult.Text += $"Swapping letters to make {word1} look like {word2} earned {coins} coins" + Environment.NewLine;
                }
                else
                {
                    TxtResult.Text += $"Swapping letters to make {word1} look like {word2} cost {coins * -1} coins" + Environment.NewLine;
                }
            }
        }

        private int CalculateCoins(string word1, string word2)
        {
            string alphabet = "0abcdefghijklmnopqrstuvwxyz";
            string letter1, letter2;
            int coins = 0;

            for (int i = 0; i < word1.Length; i++)
            {
                letter1 = word1.Substring(i, 1);
                letter2 = word2.Substring(i, 1);

                coins += alphabet.IndexOf(letter1) - alphabet.IndexOf(letter2);
            }
            return coins;
        }
    }
}
