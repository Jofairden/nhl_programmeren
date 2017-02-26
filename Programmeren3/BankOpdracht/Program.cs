using System;

namespace BankOpdracht
{
	//
	// Alle toegevoegde code is voornamelijk engels!!! Iedereen zou in het engels moeten programmeren
	// (c) Daniël Zondervan // Abduallah Lemdjad
	// basis door Joris Lops
	// Periode 3 NHL Leeuwarden (Informatica I)
	// 2.6.2017
	//
	public class Program
    {
		public static Bank ingBank;

        static void Main(string[] args)
        {
			// Maak nieuwe bank aan
		    ingBank = new Bank("ING");

			Rekening jorisRekening = ingBank.OpenRekening("Joris", "", "Lops", "6a", "8944AM");
			// Dick DE Bruin van gemaakt om Middlename te laten zien
			Rekening dickRekening = ingBank.OpenRekening("Dick", "de", "Bruin", "20", "2334WW", balance: 1000, earnings: 500);

			// Probeer 200 te storten, dit zou moeten lukken
			if (!jorisRekening.GeldStorten(200))
			{
				Console.WriteLine("storten ongeldig");
			}
			// Probeer 50 op te nemen, moet lukken, we hebben nu 200
			if (!jorisRekening.GeldOpnemen(50))
			{
				Console.WriteLine("geld opnemen ongeldig");
			}
			// Probeer 30 te storten, moet lukken
			if (!jorisRekening.GeldStorten(30))
			{
				Console.WriteLine("geld opnemen ongeldig");
			}
			// Probeer 200 te storten, moet ook lukken, nu zouden we 200-50+30+200=380 moeten hebben
			if (!jorisRekening.GeldStorten(200))
			{
				Console.WriteLine("storten ongeldig");
			}
			Console.WriteLine($"Joris current balance: {jorisRekening.balance}"); // als het goed is 380
			// Probeer 5000 op te nemen, dit kan niet.. zoveel geld hebben we niet!
			//
			//
			// Dit zou de enige moeten zijn die niet lukt!
			//
			//
			if (!jorisRekening.GeldOpnemen(5000))
			{
				Console.WriteLine("geld opnemen ongeldig");
			}
			//
			//
			//
			// Probeer 100 over te maken naar dick (die begon met 1000), zou moeten lukken!
			if (!jorisRekening.GeldOvermaken(dickRekening, 100))
			{
				Console.WriteLine("geld overmaken ongeldig");
			}

			//afdrukken van rekening ing (joris, dick)
			Console.WriteLine(ingBank.ToString());

			// Verwijder de rekening van dick
			Rekening verwijderdeRekening = ingBank.VerwijderRekening(dickRekening.ID);
			//rekening gevens van dick afdrukken
			Console.WriteLine(verwijderdeRekening.ToString());

			//afdrukken van rekeningen ing (joris)
			// de rekening van dick is er niet meer, dus als het goed is krijgen we alleen de rekening van dick te zien!
			Console.WriteLine(ingBank.ToString());


			// Zodat de app niet gelijk afsluit
			Console.ReadLine();
		}
	}
}
