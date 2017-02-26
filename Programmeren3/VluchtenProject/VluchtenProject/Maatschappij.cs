using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VluchtenProject
{
	// Maatschappij klasse
	// Missend in UML diagram: property: Uitvoerders , toch wel handig
	public class Maatschappij
	{
		public string Naam { get; set; }
		public string Afkorting { get; set; }
		public List<Uitvoerder> Uitvoerders { get; set; }

		public Maatschappij(string naam, string afkorting)
		{
			Naam = naam;
			Afkorting = afkorting;
			Uitvoerders = new List<Uitvoerder>();
		}

		public override string ToString()
		{
			return $"({Afkorting}) {Naam}";
		}
	}
}
