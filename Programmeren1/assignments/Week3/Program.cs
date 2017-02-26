using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class Program
    {
        // run code outside of main
        static void Main(string[] args) => new Program().Run(args);

        // (c) Daniel Zondervan
        // On 9-15-2016

        // Console code
        public void Run(string[] args = null)
        {
            Console.Clear();
            Console.Title = "Programming1 Week3 Assignments Console";
            Console.WriteLine("Please select which assignment you would like to pursue \n");
            Console.WriteLine($"{"Number", -25}{"Info", -25}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"1",-25}{"Discotheek Versus",-25}");
            Console.WriteLine($"{"2",-25}{"Taalkeuze",-25}");
            Console.WriteLine($"{"3",-25}{"Ideale gewicht",-25}");
            Console.WriteLine($"{"4",-25}{"Exit Console App",-25}");
            Console.Write("\nRun: ");
            var input = Console.ReadKey();
            if (char.IsDigit(input.KeyChar))
            {
                var number = Convert.ToInt32(input.KeyChar.ToString());
                if (number != 4)
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
                Assignment_1();
            else if (num == 2)
                Assignment_2();
            else if (num == 3)
                Assignment_3();
            else
                new Program().Run(args);
        }

        // The Versus Lounge Console App
        protected void Assignment_1(int? age = null, int? numusers = null, bool ladiesnight = false, bool vip = false)
        {
            if (!age.HasValue)
            {
                Console.Write("Enter your age: ");
                var input = TakeKeys();
                if (input == "")
                    input = "0";
                age = Convert.ToInt32(input);
            }

            if (!numusers.HasValue)
            {
                Console.Write("With how many people are you?\nI am with: ");
                var input = TakeKeys();
                if (input == "")
                    input = "1";
                numusers = Convert.ToInt32(input);
                var message = "";
                switch (numusers)
                {
                    case 1:
                    case 2:
                        message = "You are not with 3 people or more. Unfortunately you have no discount.";
                        break;
                    case 3:
                        message = "You are with 3 people! You have 10% discount!";
                        break;
                    case 4:
                        message = "You are with 4 people! You have 20% discount!";
                        break;
                    case 5:
                        message = "You are with 5 people! You have 50% discount!";
                        break;
                    default:
                        message = "You are with a big group of 6 or more, you can enter for free!";
                        break;
                }
                Console.WriteLine();
                Console.WriteLine(message);
                Console.ReadKey();
            }

            if (age >= 16)
            {
                Console.Clear();
                Console.Title = $"The Versus Lounge (Size: {numusers})";
                if (vip)
                    Console.Title += " (VIP)";
                if (ladiesnight)
                    Console.Title += " (LADIES NIGHT!!!)";
                var msgline = "Welcome to the Versus";
                if (vip) msgline += " VIP-Lounge";
                if (ladiesnight) msgline += " (LADIES NIGHT!!!)";
                Console.WriteLine(msgline);
                Console.WriteLine("What would you like to do? \n");
                Console.WriteLine($"{"Number",-25}{"Info",-25}");
                Console.WriteLine("--------------------------------------------------");
                var vipmsg = vip ? "Leave" : "Enter";
                var lnmsg = ladiesnight ? "Leave" : "Enter";
                Console.WriteLine($"{"1",-25}{$"{vipmsg} VIP-Lounge",-25}");
                Console.WriteLine($"{"2",-25}{$"{lnmsg} ladies night",-25}");
                Console.WriteLine($"{"3",-25}{"Leave",-25}");
                Console.Write("\nDo: ");
                var key = Console.ReadKey();
                if (char.IsDigit(key.KeyChar))
                {
                    var trigger = vip;
                    var newln = ladiesnight;

                    if (key.KeyChar == '1')
                    {
                        var msg = "";
                        if (age >= 21)
                        {
                            var triggermsg = vip ? "left" : "entered";
                            msg = $"\n\nYou have {triggermsg} the Versus VIP-Lounge!";
                            trigger = !vip;
                        }
                        else
                        {
                            msg = "\n\nYou need to be 21 years or older to enter the VIP-Lounge!";
                        }
                        Console.WriteLine(msg);
                        Console.ReadKey();

                    }
                    else if (key.KeyChar == '2')
                    {
                        var inln = ladiesnight;
                        var input = "";
                        if (!inln)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Are you a female?");
                            Console.WriteLine("-----------------");
                            Console.WriteLine($"{"1",-25}{$"Yes",-25}");
                            Console.WriteLine($"{"2",-25}{$"No",-25}");
                            Console.Write("Do: ");
                            input = TakeKeys();
                        }
                        else
                        {
                            input = "1";
                            inln = true;
                        }

                        if (inln || input == "1")
                        {
                            var triggermsg = ladiesnight ? "left" : "entered";
                            var msg = $"\n\nYou have {triggermsg} the ladies night!";
                            newln = !ladiesnight;
                            Console.WriteLine(msg);
                            Console.ReadKey();
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine("Ladies night is for ladies only!");
                            Console.ReadKey();
                        }
                    }
                    else if (key.KeyChar == '3')
                        new Program().Run();

                    Assignment_1(age, numusers, newln, trigger);
                }
                RunAssignment(null, 1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to be 16 years or older to enter the Verus!");
                Console.ResetColor();
                Console.ReadKey();
                new Program().Run(null);
            }
        }

        // Print a goodbye message in the selected language
        protected void Assignment_2()
        {
            Console.WriteLine("Please select your language \n");
            Console.WriteLine($"{"Number",-25}{"Info",-25}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"1",-25}{"NL - Nederlands - Dutch",-25}");
            Console.WriteLine($"{"2",-25}{"EN - Engels - English",-25}");
            Console.WriteLine($"{"3",-25}{"FR - Frans - French",-25}");
            Console.WriteLine($"{"4",-25}{"FY - Fries/Frysk - Frisian",-25}");
            Console.WriteLine($"{"5",-25}{"GR - Duits - German",-25}");
            Console.Write("\nLanguage: ");
            var input = Console.ReadKey();
            if (char.IsDigit(input.KeyChar))
                RunGoodbye(Convert.ToInt32(input.KeyChar.ToString()));
            else new Program().Run(null);
        }

        // Calculate the perfect weight for male or female by given weight (and wrist circumference for women)
        protected void Assignment_3()
        {
            Console.WriteLine("Are you male or female?");
            Console.Write("m/f: ");
            var input = Console.ReadKey();
            if (char.IsLetter(input.KeyChar) && (input.KeyChar == 'm' || input.KeyChar == 'f'))
            {
                Console.WriteLine("");
                Console.Write("Please enter your height in cm: ");
                var weight = 0;
                var height = TakeKeys();
                if (height == "")
                    height = "0";

                if (input.KeyChar == 'm')
                {
                    weight = CalculateMaleWeight(Convert.ToInt32(height));
                }
                else if (input.KeyChar == 'f')
                {
                    Console.Write("Please enter your wrist circumference in cm: ");
                    var circumference = TakeKeys();
                    if (circumference == "")
                        circumference = "0";

                    weight = CalculateFemaleWeight(Convert.ToInt32(height), Convert.ToInt32(circumference));
                }
                else RunAssignment(null, 3);

                Console.WriteLine($"Your perfect weight is {weight}kg!");

                Console.ReadKey();
                new Program().Run(null);
            }
            else RunAssignment(null, 3);
        }

        // Print a goodbye message
        protected void RunGoodbye(int lang)
        {
            var message = "Goodbye!";
            switch (lang)
            {
                default:
                    message = "Goodbye!";
                    break;
                case 1:
                    message = "Tot ziens!";
                    break;
                case 3:
                    message = "Au revoir!";
                    break;
                case 4:
                    message = "Oant sjen!";
                    break;
                case 5:
                    message = "Aufwiederesehen!";
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n{message}");
            Console.ResetColor();

            Console.ReadKey();
            new Program().Run();
        }

        // Calculate perfect male weight in kgs by height in cm
        protected int CalculateMaleWeight(int height)
        {
            return (int)Math.Floor((height - 100) * 0.9f);
        }

        // Calculate perfect female weight in kgs by height in cm and wrist circumference in cm
        protected int CalculateFemaleWeight(int height, int circumference)
        {
            return (int)Math.Floor((height + 4 * circumference - 100) * 0.5f);
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
