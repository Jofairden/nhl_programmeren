using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VluchtenProject
{
	// Uitvoerder class, voert een vlucht uit
	public class Uitvoerder
	{
		public string VluchtNr { get; set; }
		public Maatschappij Maatschappij { get; set; }
		public Vlucht Vlucht { get; set; }

		public Uitvoerder(string vluchtNr, Maatschappij maatschappij, Vlucht vlucht)
		{
			VluchtNr = vluchtNr;
			Maatschappij = maatschappij;
			Vlucht = vlucht;
		}

		// Niet echt gebruikt
		public override string ToString()
		{
			return VluchtNr;
		}
	}
}
