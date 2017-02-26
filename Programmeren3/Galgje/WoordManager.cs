using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Galgje
{
    public class WordManager
    {
	    private readonly Random _rand;
		private readonly string[] lines;

	    public WordManager()
	    {
			lines = File.ReadAllLines("..\\..\\woorden\\NederlandseWoorden.txt");
			_rand = new Random();
		}

	    public string GetWord()
	    {
			return lines[_rand.Next(0, lines.Length - 1)];
		}
    }
}
