using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galgje
{
    public partial class Form1 : Form
    {
        private Label[] labels;
        private Hangman hangman;
        private WordManager wm;

        public Form1()
        {
            InitializeComponent();

            wm = new WordManager();
            StartNewGame();
        }

        private void StartNewGame()
		{
			hangman = new Hangman(wm.GetWord(), maxTurns: 11);
			SetupLabels(hangman.word.Length);
			CreateLetters(hangman.GetWordForDisplay());
			Refresh();
		}


        private void button1_Click(object sender, EventArgs e)
        {
	        if (inputTextbox.Text != "" && inputTextbox.Text.Length > 0)
	        {
		        char letter = inputTextbox.Text[0];
		        if (!hangman.HasGuessedLetterBefore(letter))
		        {
			        button1.BackColor = Color.Green;
			        if (hangman.Guess(letter))
			        {
				        UpdateLabels(hangman.GetWordForDisplay());
			        }
			        else
				        ++hangman.TurnNumber;
		        }
		        else
		        {
			        button1.BackColor = Color.Red;
		        }

		        inputTextbox.Text = "";
		        inputTextbox.Focus();

		        Refresh();

		        if (hangman.Won())
		        {
			        MessageBox.Show("Je hebt gewonnen!");
			        StartNewGame();
		        }
		        else if (hangman.Lose())
		        {
			        MessageBox.Show("Je hebt verloren!");
			        StartNewGame();
		        }
	        }
        }

        private void UpdateLabels(string word)
        {            
            for (int i = 0; i < word.Length; i++)
            {
                labels[i].Text = word[i].ToString();
            }
        }

	    private void SetupLabels(int length)
	    {
		    if (labels == null)
			    labels = new Label[length];
		    else
		    {
			    foreach (Label label in labels)
			    {
				    Controls.Remove(label);
			    }
			    labels = new Label[length];
		    }

			int xOffset = 56;
			int xStart = 18;

			for (int i = 0; i < length; i++)
			{
				Label label = new Label();
				label.AutoSize = true;
				label.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
				label.Size = new Size(48, 46);

				label.Location = new Point(xOffset * i + xStart, 18);
				label.Name = "label " + i;
				char c = ' ';
				label.Text = c.ToString();
				label.BackColor = Color.LightGray;
				labels[i] = label;

				this.Controls.Add(label);
			}


		}

        private void CreateLetters(string word)
        {

	        for (int i = 0; i < labels.Length; i++)
	        {
		        labels[i].Text = word[i].ToString();
	        }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            hangManImages.Draw(e.Graphics, 100, 150, hangman.TurnNumber);
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
