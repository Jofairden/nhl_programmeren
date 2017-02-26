using System.Text;

namespace BankOpdracht
{
	// een rekening houder
	public class RekeningHouder
	{
		// variables
		public string Firstname;
		public string Middlename;
		public string Surname;
		public string Huisnr;
		public string Zip;
		public int Earnings;

		//constructor
		public RekeningHouder(string name, string middlename, string surname, string huisnr, string zip, int earnings)
		{
			this.Firstname = name;
			this.Middlename = middlename;
			this.Surname = surname;
			this.Huisnr = huisnr;
			this.Zip = zip;
			this.Earnings = earnings;
		}

		// override ToString
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("---------------------------");
			sb.AppendLine("Owner info");
			sb.AppendLine("---------------------------");
			sb.AppendLine($"Firstname: {Firstname}");
			sb.AppendLine($"MIDdlename: {Middlename}");
			sb.AppendLine($"Surname: {Surname}");
			sb.AppendLine($"Huisnr: {Huisnr}");
			sb.AppendLine($"Zip/Postal-code: {Zip}");
			sb.AppendLine($"Earnings: {Earnings}");
			sb.AppendLine("---------------------------");
			return sb.ToString();
		}
	}

	// rekening class
    public class Rekening
    {
		//properties
		//snelkoppeling: prop
		public int ID { get; protected set; } // ID van rekening
		public int balance { get; protected set; } // saldo van rekening
		public RekeningHouder owner { get; protected set; } // eigenaar (owner)

		//ctor
		public Rekening(int ID, string name, string middlename, string surname, string huisnr, string zip, int balance = 0, int earnings = 0)
		{
			this.ID = ID;
			this.balance = balance;
			owner = new RekeningHouder(name, middlename, surname, huisnr, zip, earnings); // maak nieuwe rekeninghouder aan
		}

		private bool RedCheck()
		{
			return balance <= -owner.Earnings / 2;
		}

		// Probeer geld te storten
		public bool GeldStorten(int amount)
		{
			if (amount <= 0) return false; // Kan niet negatief storten! (is opnemen)
			balance += amount;// toevoegen
			return true;
		}

		// Probeer geld op te nemen
		public bool GeldOpnemen(int amount)
		{
			if (RedCheck() || balance < 0 || balance < amount || amount <= 0) return false; // kan niet opnemen als er nieet genoeg saldo is! (of negatief)
			balance -= amount; // afhalen
			return true;
		}

		// Probeer over te maken naar andere rekening
		public bool GeldOvermaken(Rekening receiver, int amount)
		{
			if (RedCheck() || balance < amount || receiver == null || amount <= 0) return false; // kan niet overnemen als er niet genoeg saldo is of rekening is null
			receiver.balance += amount; // voeg toe aan saldo van ontvanger
			balance -= amount; // neem af van zender rekening
			return true;
		}

		// override ToString
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("---------------------------");
			sb.AppendLine($"Showing account info of owner {owner.Firstname} {owner.Middlename} {owner.Surname}");
			sb.AppendLine("---------------------------");
			sb.AppendLine($"ID: {ID}");
			sb.AppendLine($"Balance: {balance}");
			sb.AppendLine($"{owner.ToString()}");
			sb.AppendLine("---------------------------");
			return sb.ToString();
		}

		// eigen clone
		internal Rekening Clone()
		{
			return this.MemberwiseClone() as Rekening;
		}
	}
}
