using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOpdracht
{
	public class TestBank
	{
		[Test]
		public void TestConstructorAndProperty()
		{
			string bankNaam = "TestBank";
			Bank bank = new Bank(bankNaam);
			Assert.AreEqual(bankNaam, bank.identity);
		}

		[Test]
		public void OpenRekeningen()
		{
			string bankNaam = "TestBank";
			Bank bank = new Bank(bankNaam);
			Rekening rekeningNr0 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW");
			Assert.AreEqual(1, rekeningNr0.ID);
			Rekening rekeningNr1 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW", 500);
			Assert.AreEqual(2, rekeningNr1.ID);
			Rekening rekeningNr2 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW", 500, 1000);
			Assert.AreEqual(3, rekeningNr2.ID);

			Rekening rekeningNr3 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW", -500);
			Assert.AreEqual(-500, rekeningNr3.balance);
			Rekening rekeningNr4 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW", -1000);
			Assert.AreEqual(-1000, rekeningNr4.balance);
		}

		[Test]
		public void ZoekRekening()
		{
			string bankNaam = "TestBank";
			Bank bank = new Bank(bankNaam);
			Rekening rekeningNr0 = bank.OpenRekening("voornaam1", "", "achternaam1", "6a", "8944WW");
			Rekening rekeningNr1 = bank.OpenRekening("voornaam2", "", "achternaam2", "6a", "8944WW");

			Assert.AreEqual(1, bank.ZoekRekening(rekeningNr0.ID).ID);
			Assert.AreEqual(2, bank.ZoekRekening(rekeningNr1.ID).ID);
		}

		[Test]
		public void GeldStorten()
		{
			string bankNaam = "TestBank";
			Bank bank = new Bank(bankNaam);
			Rekening rekeningNr0 = bank.OpenRekening("voornaam", "", "achternaam", "6a", "8944WW");

			Rekening r = bank.ZoekRekening(rekeningNr0.ID);
			Assert.AreEqual(true, r.GeldStorten(100));
			Assert.AreEqual(false, r.GeldStorten(-100));
			Assert.AreEqual(false, r.GeldStorten(0));
		}

		[Test]
		public void GeldOpnemen()
		{
			string bankNaam = "TestBank";
			Bank bank = new Bank(bankNaam);
			Rekening rekeningNr0 = bank.OpenRekening("voornaam1", "", "achternaam2", "6a", "8944WW", balance: 1000, earnings: 500);
			//kan 250 Euro rood staan (500/2)

			Rekening r0 = bank.ZoekRekening(rekeningNr0.ID);
			Assert.AreEqual(true, r0.GeldOpnemen(500));
			Assert.AreEqual(500, r0.balance);
			Assert.AreEqual(false, r0.GeldOpnemen(-500));
			Assert.AreEqual(500, r0.balance);
			Assert.AreEqual(false, r0.GeldOpnemen(0));
			Assert.AreEqual(500, r0.balance);
			Assert.AreEqual(true, r0.GeldOpnemen(500));
			Assert.AreEqual(0, r0.balance);

			//rood staan
			Assert.AreEqual(false, r0.GeldOpnemen(125));
			Assert.AreEqual(0, r0.balance);
			Assert.AreEqual(false, r0.GeldOpnemen(125));
			Assert.AreEqual(0, r0.balance);

			//te veel rood staan
			Assert.AreEqual(false, r0.GeldOpnemen(10));
			Assert.AreEqual(0, r0.balance);


			Rekening rekeningNr1 = bank.OpenRekening("voornaam2", "", "achternaam2", "6a", "8944WW", balance: 1000);
			Rekening r1 = bank.ZoekRekening(rekeningNr1.ID);
			//kan niet rood staan
			Assert.AreEqual(true, r1.GeldOpnemen(500));
			Assert.AreEqual(500, r1.balance);
			Assert.AreEqual(true, r1.GeldOpnemen(500));
			Assert.AreEqual(0, r1.balance);
			//proberen rood te staan
			Assert.AreEqual(false, r1.GeldOpnemen(10));
			Assert.AreEqual(0, r1.balance);
		}

		[Test]
		public void TestOvermaken()
		{
			Bank bank = new Bank("ing");
			Rekening rekeningNrJoris = bank.OpenRekening("Joris", "", "lops", "6a", "8944AM");
			Rekening rekeningNrDick = bank.OpenRekening("Dick", "", "bruin", "20", "2334WW", 1000, 500);

			Rekening joris = bank.ZoekRekening(rekeningNrJoris.ID);
			Rekening dick = bank.ZoekRekening(rekeningNrDick.ID);

			Assert.AreEqual(false, joris.GeldOvermaken(dick, 100)); //joris heeft geen geld dus kan niet overmaken
			Assert.AreEqual(true, dick.GeldOvermaken(joris, 1000));
			Assert.AreEqual(0, dick.balance);
			Assert.AreEqual(false, dick.GeldOvermaken(joris, 250));
			Assert.AreEqual(0, dick.balance);
			Assert.AreEqual(false, dick.GeldOvermaken(joris, 10));
			Assert.AreEqual(0, dick.balance);
		}

		[Test]
		public void AccountVerwijderen()
		{
			Bank bank = new Bank("ing");
			Rekening rekeningNrJoris = bank.OpenRekening("Joris", "", "lops", "6a", "8944AM");
			Rekening rekeningNrDick = bank.OpenRekening("Dick", "", "bruin", "20", "2334WW", 1000, 500);

			Assert.AreEqual(rekeningNrJoris.ID, bank.VerwijderRekening(rekeningNrJoris.ID).ID);
			Assert.AreEqual(null, bank.ZoekRekening(rekeningNrJoris.ID));
		}

		[Test]
		public void RenteUitkeren()
		{
			Bank bank = new Bank("ing");
			Rekening rekeningNrJoris = bank.OpenRekening("Joris", "", "lops", "6a", "8944AM");
			Rekening rekeningNrDick = bank.OpenRekening("Dick", "", "bruin", "20", "2334WW", 1000, 500);
			Rekening rekeningNrJorisNegatief = bank.OpenRekening("Joris", "", "Lops", "20", "2334WW", 0, 1000);

			Rekening joris = bank.ZoekRekening(rekeningNrJoris.ID);
			Rekening dick = bank.ZoekRekening(rekeningNrDick.ID);
			Rekening jorisNegatief = bank.ZoekRekening(rekeningNrJorisNegatief.ID);
			jorisNegatief.GeldOpnemen(500);
			Assert.AreEqual(0, jorisNegatief.balance);

			decimal totaaluitgekeerd = bank.RenteUitkeren(5);
			Assert.AreEqual(50, totaaluitgekeerd);

			Assert.AreEqual(0, joris.balance);
			Assert.AreEqual(1050, dick.balance);
			Assert.AreEqual(0, jorisNegatief.balance); //sociale bank
		}
	}
}
