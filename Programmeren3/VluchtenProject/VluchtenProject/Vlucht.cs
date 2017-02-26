using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VluchtenProject
{
	// Vlucht class
	// Missend in UML diagram: propery: Optijd
	public class Vlucht
	{
		public Vliegtuig Vliegtuig { get; set; }
		public Luchthaven Van { get; set; }
		public Luchthaven Naar { get; set; }
		public DateTime Vertrek { get; set; }
		public string Status { get; set; }
		public string Optijd { get; set; }
		public List<Uitvoerder> Uitvoerders { get; set; }

		public Vlucht(Vliegtuig vliegtuig, Luchthaven van, Luchthaven naar, DateTime vertrek, string status, string optijd)
		{
			Vliegtuig = vliegtuig;
			Van = van;
			Naar = naar;
			Vertrek = vertrek;
			Status = status;
			Optijd = optijd;
			Uitvoerders = new List<Uitvoerder>();
		}

		public void AddUitvoerder(Maatschappij maatschappij, string vluchtNr)
		{
			Uitvoerder uitvoerder = new Uitvoerder(vluchtNr, maatschappij, this);
			Uitvoerders.Add(uitvoerder);
			maatschappij.Uitvoerders.Add(uitvoerder);
		}

		public override string ToString()
		{
			return Vliegtuig.Model;
		}
	}
}
