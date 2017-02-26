using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    class Program
    {
        static void Main(string[] args) => new Program().Run(args);

        // (c) Daniel Zondervan
        // On 27-9-2016

        public void Run(string[] args = null)
        {
            Console.Clear();
            Console.Title = "Programming1 Week4 Assignments Console";
            Console.WriteLine("Please select which assignment you would like to pursue \n");
            Console.WriteLine($"{"Number",-25}{"Info",-25}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"1",-25}{"show the biggest number",-25}");
            Console.WriteLine($"{"2",-25}{"10 powes of 2",-25}");
            Console.WriteLine($"{"3",-25}{"10 times fibonacci",-25}");
            Console.WriteLine($"{"4",-25}{"avg car usage",-25}");
            Console.WriteLine($"{"5",-25}{"casino simulator",-25}");
            Console.WriteLine($"{"6",-25}{"Exit",-25}");
            Console.Write("\nRun: ");
            var input = Console.ReadKey();
            if (char.IsDigit(input.KeyChar))
            {
                var number = Convert.ToInt32(input.KeyChar.ToString());
                if (number < 6)
                    RunAssignment(args, number);
            }
            else new Program().Run(args);

            Environment.Exit(0);
        }

        // Run which assignment?
        private void RunAssignment(string[] args, int num)
        {
            Console.Clear();
            Console.Title = $"Running assignment {num}";
            if (num == 1)
                Assignment_1(args);
            else if (num == 2)
                Assignment_2(args);
            else if (num == 3)
                Assignment_3(args);
            else if (num == 4)
                Assignment_4(args);
            else if (num == 5)
                Assignment_5(args);
            else
                new Program().Run(args);
        }

        // Show biggest number
        protected void Assignment_1(string[] args = null)
        {
            List<int> numbers = new List<int>();
            Console.Write("Please enter a number: ");
            numbers.Add(Convert.ToInt32(TakeKeys()));
            Console.Write("Please enter another number: ");
            numbers.Add(Convert.ToInt32(TakeKeys()));
            Console.Write("Could you please enter another number: ");
            numbers.Add(Convert.ToInt32(TakeKeys()));
            Console.Write("I promise this ends soon, another number please: ");
            numbers.Add(Convert.ToInt32(TakeKeys()));
            Console.Write("Please enter a final number: ");
            numbers.Add(Convert.ToInt32(TakeKeys()));
            Console.WriteLine();
            Console.Write($"Out of all of your entered numbers, here's your biggest: {numbers.Max()}");
            EndAssignment();
        }

        // powers of 2
        protected void Assignment_2(string[] args = null)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"Showing {i} power of 2: {Math.Pow(2, i)}");
            }
            EndAssignment();
        }

        // fibonacci
        protected void Assignment_3(string[] args = null)
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine($"Showing {i} Fibonacci: {Fibonacci(i)}");
            }
            EndAssignment();
        }

        // car usage
        protected void Assignment_4(string[] args = null)
        {
            var runassign = true;
            var driven = new List<int>();
            var tanked = new List<int>();
            var num1 = 0;
            var num2 = 0;
            do
            {
                Console.Write($"How far did you drive (in KM)? ");
                num1 = Convert.ToInt32(TakeKeys());
                Console.Write($"How much did you tank (in L)? (enter 0 to stop) ");
                num2 = Convert.ToInt32(TakeKeys());
                if (num2 == 0)
                {
                    runassign = false;
                    break;
                }
                else
                {
                    driven.Add(num1);
                    tanked.Add(num2);
                }
            }
            while (runassign);

            if ((driven.Count + tanked.Count) / 2 >= 1)
            {
                var avgusage = new List<int>();
                try
                {
                    for (int i = 0; i < (driven.Count + tanked.Count) / 2; i++)
                    {
                        avgusage.Add(driven[i] / tanked[i]);
                    }
                }
                catch { }

                if (avgusage.Any())
                {
                    var totalavg = 0;
                    foreach (var item in avgusage)
                    {
                        totalavg += item;
                    }
                    Console.WriteLine($"Your total avg tanked litres per KM: {totalavg}");
                }
            }

            EndAssignment(args);
        }

        // how much luck I had during testing: https://i.imgur.com/DW6gK4q.png
        protected void Assignment_5(string[] args = null, int argbet = -1)
        {
            Console.WriteLine("Welcome to casino simulator. What is your bet? (min. 5 EUR, max. 100 EUR)");
            int bet = 0;
            if (argbet < 0)
            {
                bet = Convert.ToInt32(TakeKeys());
                if (bet < 5)
                    bet = 5;
                else if (bet > 100)
                    bet = 100;
            }
            else
                bet = argbet;
            Console.WriteLine($"Accepted bet of {bet}. Simulating casino...");
            Console.WriteLine();
            var rnd = new Random();
            var num6 = 0;
            var mult = 0;
            for (int i = 0; i < 3; i++)
            {
                var num1 = rnd.Next(1, 7);
                Console.WriteLine($"Dice threw {num1}!");
                var num2 = rnd.Next(1, 7);
                Console.WriteLine($"Dice threw {num2}!");
                if (num1 == num2)
                {
                    Console.WriteLine($"Both dice rolled the same number!");
                    mult += 10;
                }
                if (num1 == 6 && num2 == 6)
                {
                    num6++;
                    Console.WriteLine($"Both dice rolled 6!");
                    mult += 50;
                }
                Console.WriteLine();
            }
            if (num6 >= 2)
            {
                Console.WriteLine($"You rolled 6 twice per roll at least two times!");
                mult += 2;
            }
            if (mult > 0)
                Console.WriteLine($"You win {bet * mult} EUR!!! Congrats!!");
            else
                Console.WriteLine($"Im so sorry, but you win nothing!!! HA!");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue....");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Would you like to try out casino simulator again?");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{"1",-25}{$"Yes",-25}");
            Console.WriteLine($"{"2",-25}{$"No",-25}");
            Console.Write("Do: ");
            var input = Convert.ToInt32(TakeKeys());
            Console.WriteLine();
            Console.WriteLine("Would you like to use the same bet?");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"{"1",-25}{$"Yes",-25}");
            Console.WriteLine($"{"2",-25}{$"No",-25}");
            Console.Write("Do: ");
            var usebet = Convert.ToInt32(TakeKeys());

            if (input == 1)
            {
                int newbet = usebet == 1 ? bet : -1;
                Console.Clear();
                Assignment_5(args, newbet);
            }

            new Program().Run(args);
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        protected void EndAssignment(string[] args = null)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue....");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            new Program().Run(args);
        }

        // Take only numeric keys
        protected string TakeKeys()
        {
            ConsoleKeyInfo key;
            string _val = "";
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return _val;
        }
    }
}
