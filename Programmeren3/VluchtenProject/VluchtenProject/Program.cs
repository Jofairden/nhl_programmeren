using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VluchtenProject
{
	// 'Record' class
	// Hier slaan wel elke 'vlucht record' gegevens mee op
	// Kan eventueel ook in apart bestand, zo was makkelijker
	public class VluchtData
	{
		// Alle variables
		public string VluchtNr { get; set; }
		public string Luchtvaartmaatschappij { get; set; }
		public string Van { get; set; }
		public string Bestemming { get; set; }
		public string Route { get; set; }
		public string Vertrek { get; set; }
		public string Status { get; set; }
		public string Optijd { get; set; }
		public string Model { get; set; }
		public string CallSign { get; set; }
		public string Owner { get; set; }

		// In principe ongebruikt en hoeft niet gebruikt te worden
		public VluchtData(string vluchtNr, string luchtVaartmaatschappij, string van, string bestemming, string route,
			string vertrek, string status, string optijd, string model, string callsign, string owner)
		{
			VluchtNr = vluchtNr;
			Luchtvaartmaatschappij = luchtVaartmaatschappij;
			Van = van;
			Bestemming = bestemming;
			Route = route;
			Vertrek = vertrek;
			Status = status;
			Optijd = optijd;
			Model = model;
			CallSign = callsign;
			Owner = owner;
		}

		// Set properties automatisch met een string array
		public VluchtData(string[] args)
		{
			// we gaan er van uit dat de volgorde van de argumenten
			// hetzelfde is als de volgorde van de properties
			if (args.Length < 11)
				throw new Exception("Niet genoeg vluchtdata");

			Type target = this.GetType();
			int count = 0;
			// klein beetje 'reflection' hier
			target
				.GetProperties()
				.ToList()
				.ForEach(property =>
					property.SetValue(this, args[count++], null));

		}
	}

	// (c) D.Z.
	// 26.2.2017

	// Programma klasse
	// Even voor de duidelijkheid 
	// he...
	// ik haat programmeren in het nederlands
	// doei
	public class Program
	{
		// Run de code outside Main, 'recommended', tegenwoordig mijn gewoonte (vooral als je async programmeert)
		static void Main(string[] args) => 
			new Program().Run(args);

		// Assemly directory 'path', waar onze uitvoerende binary (.exe) zich bevindt
		public static string AssemblyDirectory => 
			Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetEntryAssembly().CodeBase).Path));

		// Lijsten met objecten
		public List<Vliegtuig> vliegtuigen = 
			new List<Vliegtuig>(); // Alle vliegtuigen 'callSign'
		public List<Maatschappij> maatschappijen = 
			new List<Maatschappij>(); // Alle maatschappijen
		public List<Luchthaven> luchthavens = 
			new List<Luchthaven>(); // Alle luchthavens
		public List<Vlucht> vluchten =
			new List<Vlucht>(); // Alle vluchten

		// Voor de data invoer, zie: vluchtgegevens.txt

		// Draai het programma
		private void Run(string[] args)
		{
			// Lees vluchtgegevens.txt uit, skip de eerste 2 regels en pak daarna alle regels die niet alleen uit '=' tekens bestaan
			// We skippen de 'header' en 'separators' als het ware
			IEnumerable<string> fileData =
				File.ReadAllLines(
					Path.Combine(AssemblyDirectory, "vluchtgegevens.txt"))
					.Skip(2)// Skip eerste 2 regels, header en === separator
					.Where(x => x.All(y => !char.Equals(y, '='))); // Skip separators
			// Omdat we later separators skippen, zou je ook eerst .Skip(1) kunnen callen

			// Maak een nieuwe lijst van IEnumerable<String> aan, dus eigenlijk een lijst van vlucht gegevens
			List<IEnumerable<string>> splitData = 
				new List<IEnumerable<string>>();
			// Voor alle vluchten, splitten we de content op de comma, en verwijderen we tabs (\t), dan voegen we de inhoud toe aan de list
			fileData
				.ToList()
				.ForEach(x =>
					splitData
						.Add(x
							.Replace("\t", "")
							.Split(',')));

			List<VluchtData> vluchtData = new List<VluchtData>();
			// Voor elke IEnumerable in splitData, add nieuwe VluchtData in vluchtData list, .Trim() elke string
			splitData.ForEach(x =>
				vluchtData.Add(
					new VluchtData
					(
						x
						.Select(y => y.Trim())
						.ToArray()
					)));

			// Vliegtuigen
			// Van de data, maak een nieuw vliegtuig object per callSign, zodat we dubbele instanties vermijden.
			// Dit is makkelijker dan je zou denken, we grouperen onze data op de callSign waardes,
			// Dan selecteren we van elke callSign de eerste unieke groep, 
			// dat kan want we weten namelijk dat de data die we nodig hebben voor een callSign elke keer hetzelfde is
			// Dan maken we een nieuwe vliegtuig aan met de informatie en voegen we toe aan onze list
			vluchtData
				.GroupBy(data => data.CallSign)
				.Select(group => group.First())
				.ToList()
				.ForEach(data =>
					vliegtuigen
						.Add(new Vliegtuig(
							data.CallSign, 
							data.Model, 
							data.Luchtvaartmaatschappij,
							data.Owner)));

			// Maatschappijen
			// Van de data, maak een nieuw maatschappij object
			// We groeperen de data op Luchtvaartmaatschappij waarde en pakken weer de eerste unieke groep
			// 'distinct'
			// Dan voegen we onze nieuwe object toe aan onze list
			vluchtData
				.GroupBy(data => data.Luchtvaartmaatschappij)
				.Select(group => group.First())
				.Select(data => data.Luchtvaartmaatschappij)
				.ToList()
				.ForEach(data =>
				{
					if (!string.IsNullOrEmpty(data)) // met onze data is deze check eigenlijk nodig, er is altijd inhoud
					{
						string[] splitdata =
							data.Split(' ');// split de content op whitespace

						string afkorting =
							new string(splitdata[0] // pak de afkorting, bv: (DAL) van Delta Air Lines
								.Where(c => // Waar character c =>
									!new[] {'(', ')'} // Nieuwe array van characters: '(' en ')'
										.Contains(c)) // Waar de array niet het huidige character bevat
								.ToArray()); // We filteren als het ware de '(' en ')' van de afkorting weg.
						// Je zou ook met substring kunnen doen
						string naam =
							string.Join(" ", splitdata.Skip(1)); // De naam is de rest van de split, behalve de eerste want dat is de afkorting
						// Voeg object toe!
						maatschappijen.Add(new Maatschappij(naam, afkorting));
					}
				});

			//Luchthavens
			//Van de data, pakken we 'Van' en 'Bestemming' strings m.b.v. 'concatenate', dit is een soort van SQL 'union'
			//We voegen beide LINQ queries als het ware samen tot één IEnumerable<string>
			//Daarna groeperen we op data, en pakken we weer de unieke waardes, 'distinct', elke unieke waarde komt dus maar 1 keer voor
			// Dan voegen we onze nieuwe object toe aan de list
			vluchtData
				.Select(data => data.Van)
				.Concat(vluchtData.Select(data => data.Bestemming))
				.GroupBy(data => data)
				.Select(group => group.First())
				.ToList()
				.ForEach(data =>
				{
					if (!string.IsNullOrEmpty(data))
					{
						// hier weer zelfde principe als bij de vorige
						// je zou het kunnen samenvoegen tot één helper methode
						string[] splitdata =
							data.Split(' ');

						string afkorting =
							new string(splitdata[0]
								.Where(c =>
									!new[] {'(', ')'}
										.Contains(c))
								.ToArray());

						string naam =
							string.Join(" ", splitdata.Skip(1));
						//Voeg object toe!
						luchthavens.Add(new Luchthaven(naam, afkorting));
					}
				});

			// Construeer alle gegevens
			// Omdat we nu alle benodigde objecten hebben in onze lijsten
			// kunnen we de rest van de gegevens maken en objecten voeden
			// We loopen alle VluchtData uit onze list, bevat alle info van een vlucht
			foreach (VluchtData data in vluchtData)
			{
				// Eerst maken we een vlucht object
				// Kijk goed naar de LINQ Lambda expressies, we maken gebruiken van onze gevulde lijsten
				Vlucht vlucht =
					new Vlucht(
						vliegtuigen.First(x => x.CallSign == data.CallSign),
						luchthavens.First(x => x.ToString() == data.Van),
						luchthavens.First(x => x.ToString() == data.Bestemming),
						Convert.ToDateTime(data.Vertrek),
						data.Status,
						data.Optijd);

				// We hebben nu een vlucht, add een nieuwe uitvoerder via de methode die we van de UML diagram moesten maken
				// Weer gebruik maken van onze bestaande list
				vlucht.AddUitvoerder(
					maatschappijen.First(x => x.ToString() == data.Luchtvaartmaatschappij),
					data.VluchtNr);

				// Voeg de nieuwe vlucht toe aan de vluchten van luchthaven A en luchthaven B (van / naar)
				// Weer gebruik maken van de huidige list
				luchthavens
					.Where(x => new[] {data.Van,data.Bestemming}.Contains(x.ToString()))
					.ToList()
					.ForEach(x => x.Vluchten.Add(vlucht));

				// eigenlijk overbodige lijst, maar waarom ook niet
				vluchten.Add(vlucht);
			}

			// Van all luchthavens, pakken we weer alle vluchten die van die luchthaven komen, SelectMany want die 'flattens' het resultaat, oftewel we houden 1 enumerable over met vluchten,
			// ipv een enumerable met een lijst van vluchten (elke lijst afkomstig van een luchthaven)
			IEnumerable<Vlucht> alleVluchten =
				luchthavens.SelectMany(x =>
					x.Vluchten.Where(y => y.Van == x)); // <--- belangrijk, bestudeer goed

			// Nu hebben we alle vluchten die VAN een luchthaven NAAR een andere gaan, in een Enumerable

			// spacing tussen content
			const int spacing = -20;

			// write een header
			Console.WriteLine(
				$"{"Schema",spacing}{"Herkomst",spacing}{"Vluchtnr",spacing}{"Maatschappij",spacing}{"Opmerkingen",spacing}{"Actuele info",spacing}");
			// write een soort separator
			Console.WriteLine(
				$"{"======",spacing}{"========",spacing}{"========",spacing}{"============",spacing}{"===========",spacing}{"============",spacing}");



			// Loop de vluchten, loop daarna alle uitvoerders van de vlucht
			foreach (Vlucht vlucht in alleVluchten)
			foreach (Uitvoerder uitvoerder in vlucht.Uitvoerders)
			{
				// write de gegevens van de uitvoerder
				Console.WriteLine(
					$"{uitvoerder.Vlucht.Vertrek,spacing:HH:mm}{uitvoerder.Vlucht.Van.Naam,spacing}{uitvoerder.VluchtNr,spacing}" +
					$"{uitvoerder.Maatschappij.Naam,spacing}{uitvoerder.Vlucht.Status,spacing}{"Details ->",spacing}");
			}

			// Plaats hier een breakpoint als je alle objecten e.d. goed wilt bestuderen
			Console.ReadLine();
		}
	}
}
