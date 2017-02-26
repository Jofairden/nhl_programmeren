using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VluchtenProject
{
	// Vliegtuig klasse
	// Missend in UML diagram: property: Owner
	// En wie is de fabrikant? Who knows...
	public class Vliegtuig
	{
		public string CallSign { get; set; }
		public string Model { get; set; }
		public string Fabrikant { get; set; }
		public string Owner { get; set; }

		public Vliegtuig(string callSign, string model, string fabrikant, string owner)
		{
			CallSign = callSign;
			Model = model;
			Fabrikant = fabrikant;
			Owner = owner;
		}

		public override string ToString()
		{
			return Model;
		}
	}
}
