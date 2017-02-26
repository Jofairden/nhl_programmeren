using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galgje
{
    public class Hangman
    {
	    private readonly int maxTurns;
	    private readonly char[] letters;
	    public readonly char emptyChar = ' ';
		public int TurnNumber;
		public readonly string word;

		public Hangman(string word, int maxTurns)
	    {
			this.word = word;
		    this.maxTurns = maxTurns;
		    letters = new char[word.Length];
		    for (int i = 0; i < letters.Length; i++)
		    {
			    letters[i] = emptyChar;
		    }
			TurnNumber = 0;
	    }

	    public bool Guess(char letter)
	    {
			bool any = false;
		    for (int i = 0; i < letters.Length; i++)
		    {
			    if (word[i] == letter)
			    {
				    letters[i] = letter;
					any = true;
				}
			}
		    return any;
	    }

	    public bool HasGuessedLetterBefore(char letter)
	    {
		    return letters.Any(c => c == letter);
	    }

		public string GetWordForDisplay()
	    {
			return new string(letters);
	    }

	    public bool Won()
	    {
			return TurnNumber < maxTurns && new string(letters) == word;
	    }

	    public bool Lose()
	    {
			return TurnNumber >= maxTurns && new string(letters) != word;
	    }

	}
}
