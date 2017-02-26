using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        // (c) Daniel Zondervan
        // Made on 9-15-2016
        // Hello Fiona, I prefer to write code in English. I hope you don't mind.
        // If anything is unclear, please let me know! :)

        // Run our code outside of Main because I'm used to it and prefer it
        static void Main(string[] args) => new Program().Run(args);

        // Variables
        private int assignment = 1;
        // Assignment 1
        // 1.1
        private string name = "Fiona";
        private char letter = 'C';
        private int number1 = 123;
        private float number2 = 1.5f;
        private bool status = false;
        private int age = 35;

        // Assignment 2
        // 2.1
        private string wordA = "Hallo";
        private string wordB = "wereld";
        private string sentence;

        // Program code
        public void Run(string[] args)
        {
            Console.Title = $"Current assignment: {assignment}";
            // Assignment 1
            // 1.2
            Console.WriteLine($"{name + " Sariedine",-20}{letter,-20}\n{number1,-20}{number2,-20}\n{age,-20}{status,-20}");
            // 1.3
            var rest = number1 / number2;
            // 1.4
            Console.WriteLine($"\nRest: {rest.ToString()}");

            NextAssignment();

            // Assignment 2
            // 2.1
            sentence = $"{wordA} {wordB}";
            // 2.2
            var temp = "bla";
            for (int i = 0; i < 5; i++)
            {
                temp += "bla";
            }
            Console.WriteLine($"temp = {temp}");

            NextAssignment();

            // Assignment 3
            Console.WriteLine("Write a number and press enter");
            var num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Number {num1} accepted. Write another number and press enter");
            var num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Number {num2} accepted. Exchanging variables and printing to screen...");
            var temp2 = num1;
            num1 = num2;
            num2 = temp2;
            Console.WriteLine($"num1: {num1} (was {temp2})");
            Console.WriteLine($"num2: {num2} (was {num1})");

            NextAssignment();

            // Assignment 4
            Console.WriteLine($"Convert X celsius to Y fahrenheit and Z kelvin. Enter X amount of celsius: ");
            var celsius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Calculating Y fahrenheit and Z kelvin value...");
            var fahrenheit = ToFahrenheit(celsius);
            var kelvin = ToKelvin(celsius);
            Console.WriteLine($"Calculated {fahrenheit} degrees fahrenheit and {kelvin} degrees kelvin from {celsius} degrees celsius");
            // Proof: https://www.google.nl/search?q=%3D+212+degrees+Fahrenheit&ie=utf-8&oe=utf-8&client=firefox-b&gfe_rd=cr&ei=yQbYV_-vB6XH8AeD6aOIBQ#q=%3D+100+degrees+celsius

            NextAssignment();

            // Assignment 5
            var text = @"The Decimal, Double, and Float variable types are different in the way that they store the values.Precision is the main difference where float is a single precision (32 bit) floating point data type, double is a double precision (64 bit) floating point data type and decimal is a 128 - bit floating point data type.
Float - 32 bit(7 digits)
Double - 64 bit(15 - 16 digits)
Decimal - 128 bit(28 - 29 significant digits)
 
The main difference is Floats and Doubles are binary floating point types and a Decimal will store the value as a floating decimal point type.So Decimals have much higher precision and are usually used within monetary (financial)applications that require a high degree of accuracy.But in performance wise Decimals are slower than double and float types.
 
Decimal can 100% accurately represent any number within the precision of the decimal format, whereas Float and Double, cannot accurately represent all numbers, even numbers that are within their respective formats precision.";
            // Dus in het kort: decimal is heel erg precies. floats en doubles zijn minder precies. float is het minst precies. maar floats en doubles zijn sneller dan decimals. heb je dus niet super accurate nummers nodig, gebruik je veelal floats. heb je preciezer nodig, dan gebruik je doubles en decimals
            Console.WriteLine(text);

            NextAssignment();

            // Assignment 6
            var multiplication = 1.2231;
            Console.WriteLine($"Convert X EUR to Y USD. Enter X amount of euros:");
            var eur = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Calculating USD value...");
            Console.WriteLine($"{eur} EUR is equal to {eur * multiplication} USD");

            NextAssignment();

            // Assignment 7
            Console.WriteLine($"Enter your first name:");
            var firstname = Console.ReadLine();
            Console.WriteLine($"Enter your surname:");
            var surname = Console.ReadLine();
            Console.WriteLine($"Enter your address:");
            var address = Console.ReadLine();
            Console.WriteLine($"Enter your ZIP code:");
            var zip = Console.ReadLine();
            Console.WriteLine($"Enter your town:");
            var town = Console.ReadLine();

            var ticket = $"{firstname + " " + surname,-25}{address,-25} \n" +
                         $"{zip,-25} {town,-25}";

            Console.WriteLine("Creating ticket..\n\n");
            Console.WriteLine(ticket);

            NextAssignment();

            // Assignment 8
            Console.WriteLine("Please enter value A:");
            var valA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter value B:");
            var valB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter value C:");
            var valC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Calculating using formula.. Please stand by...\n\n");
            Console.WriteLine($"Your number: {UseFormula(valA, valA, valC).ToString()}");

            // Wait until program finishes
            Console.ReadKey();
            //  Task.Delay(0);
        }

        // Attempt next assignment
        private void NextAssignment()
        {
            Console.WriteLine("\n\nPress a character to proceed to the next assignment"); // proceed prompt
            Console.ReadKey(); // wait for user input
            assignment++; // update current assignment integer
            Console.Title = $"Current assignment: {assignment}"; // update console title
            Console.Clear(); // clear console
        }

        // Calculate degrees fahrenheit from degrees celsius
        private double ToFahrenheit(double celsius)
        {
            return celsius * 1.8000 + 32;
        }

        // Calculate degrees kelvin from degrees celsius
        private double ToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        // Calculate X value from a, b and c, used for assignment 8 
        private int UseFormula(int a, int b, int c)
        {
            try
            {
                return a * (b / c);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                return 0;
            }
        }
    }
}
