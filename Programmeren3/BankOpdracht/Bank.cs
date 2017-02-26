using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOpdracht
{
	public class Bank
    {
		public string identity; // naam van de bank
		public readonly List<Rekening> accounts; // lijst van accounts (rekeningen)

		private int curid = 0; // huidige account id
		public int nextid // volgende account id
		{
			get
			{
				return curid + 1;
			}
			set
			{
				curid = value;
			}
		}

		// constructor
		public Bank(string identity)
		{
			this.identity = identity;
			accounts = new List<Rekening>();
		}

		// maak een nieuwe rekening
		public Rekening OpenRekening(string name, string middlename, string surname, string huisnr, string zip, int balance = 0, int earnings = 0)
		{
			accounts.Add(new Rekening(nextid, name, middlename, surname, huisnr, zip, balance, earnings));
			nextid = curid + 1;
			return accounts.Last();
		}

		// zoek een rekening op id
		public Rekening ZoekRekening(int id)
		{
			return accounts.FirstOrDefault(x => 
											x.ID == id);
		}

		// zoek een rekening op volledige naam
		public Rekening ZoekRekening(string name, string middlename = "", string surname = "")
		{
			return accounts.First(x => 
									x.owner.Firstname == name 
									&& x.owner.Middlename == middlename 
									&& x.owner.Surname == surname);
		}

		// je zou zo nog verder kunnen gaan, bijvoorbeeld op postcode, woonplaats, saldo, e.d.


		// Verwijder een rekening
		public Rekening VerwijderRekening(int id)
		{
			Rekening rekening = ZoekRekening(id).Clone(); // omdat de return van ZoekRekening naar dezelfde rekening in de memory verwijst als die in de accounts List staat, clonen we deze zodat we een nieuwe in memory hebben (Deze variable)
			if (rekening != null) // als de rekening gevonden is...
			{
				// verwijderen maar!
				try // safeguard
				{
					accounts.Remove(accounts.First(x =>
													x.ID == rekening.ID));
				}
				catch
				{
					return null;
				}
				return rekening;
			}
			return null;
		}

		public decimal RenteUitkeren(int percentage)
		{
			double total = 0;
			double stortAmount = 0d;
			foreach (Rekening rekening in accounts)
			{
				stortAmount = rekening.balance * (percentage / 100d);
				rekening.GeldStorten((int)stortAmount);
				total += stortAmount;
			}
			return (decimal)total;
		}

		// override ToString
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("---------------------------");
			sb.AppendLine("Showing bank info");
			sb.AppendLine($"Bank identity: {identity}");
			sb.AppendLine("---------------------------");
			foreach (Rekening account in accounts)
			{
				sb.AppendLine(account.ToString());
			}
			sb.AppendLine("---------------------------");
			return sb.ToString();
		}
	}
}
