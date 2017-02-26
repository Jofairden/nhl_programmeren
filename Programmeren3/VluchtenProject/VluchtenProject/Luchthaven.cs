using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VluchtenProject
{
	// Luchthaven class
    public class Luchthaven
    {
	    public string Naam { get; set; }
	    public string Afkorting { get; set; }
		public List<Vlucht> Vluchten { get; set; }

	    public Luchthaven(string naam, string afkorting)
	    {
			Naam = naam;
		    Afkorting = afkorting;
		    Vluchten = new List<Vlucht>();
	    }

		public override string ToString()
		{
			return $"({Afkorting}) {Naam}";
		}
	}
}
