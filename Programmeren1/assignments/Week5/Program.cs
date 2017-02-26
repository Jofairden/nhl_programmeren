using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    class Program
    {
        static void Main(string[] args) => new Program().Run(args);

        // (c) Daniel Zondervan
        // On 03-10-2016

        public void Run(string[] args = null)
        {
            Console.Clear();
            Console.Title = "Programming1 Week5 Assignments Console";
            Console.WriteLine("Please select which assignment you would like to pursue \n");
            Console.WriteLine($"{"Number",-25}{"Info",-25}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"1",-25}{"sum of 2 numbers in array",-25}");
            Console.WriteLine($"{"2",-25}{"9 numbers in array, 1 by request",-25}");
            Console.WriteLine($"{"3",-25}{"10 numbers in array, show even numbers",-25}");
            Console.WriteLine($"{"4",-25}{"3 arrays with 5 values",-25}");
            Console.WriteLine($"{"5",-25}{"student names in array",-25}");
            Console.WriteLine($"{"6",-25}{"student names in array alphabetical",-25}");
            Console.WriteLine($"{"7",-25}{"Exit",-25}");
            Console.Write("\nRun: ");
            var input = Console.ReadKey();
            if (char.IsDigit(input.KeyChar))
            {
                var number = Convert.ToInt32(input.KeyChar.ToString());
                if (number < 7)
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
            else if (num == 6)
                Assignment_6(args);
            else
                new Program().Run(args);
        }

        // Give X student names, add them to array. Sort array alphabetically. Show all student names in array.
        private void Assignment_6(string[] args)
        {
            // give X student names, show them alphabetically
            Console.Write("How many student names do you want to pass? : ");
            var num_names = Convert.ToInt32(TakeKeys());
            var names = new string[num_names];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"Enter student name ({i + 1}): ");
                names[i] = Console.ReadLine();
            }

            Console.WriteLine("Sorting names alphabetically");
            // Sort names alphabetically (A-Z)
            Array.Sort<string>(names);

            Console.WriteLine("Showing student array:");
            Console.WriteLine();

            var msg = "";

            for (int i = 0; i < names.Length; i++)
            {
                msg += $"{names[i]} ({i + 1}), ";
            }

            msg = msg.Remove(msg.Length - 2); // trim string

            Console.WriteLine(msg);

            EndAssignment();
        }

        // Give X student names, add them to array. Show all student names in array.
        private void Assignment_5(string[] args)
        {
            Console.Write("How many student names do you want to give? : ");
            var num_names = Convert.ToInt32(TakeKeys());
            var names = new string[num_names];

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"Enter student name ({i + 1}): ");
                names[i] = Console.ReadLine();
            }

            Console.WriteLine("Showing student array:");
            Console.WriteLine();

            var msg = "";

            for (int i = 0; i < names.Length; i++)
            {
                msg += $"{names[i]} ({i + 1}), ";
            }

            msg = msg.Remove(msg.Length - 2); // trim string

            Console.WriteLine(msg);

            EndAssignment();
        }

        // array 1 and 2 filled with random numbers ranging from 0 to 9
        // third array filled with the sum of matching numbers from array 1 and array 2
        // display sum of each array's values
        private void Assignment_4(string[] args)
        {
            var arr1 = new int[5];
            var arr2 = new int[arr1.Length];
            var arr3 = new int[arr1.Length];
            var rnd = new Random();

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rnd.Next(0, 10);
                arr2[i] = rnd.Next(0, 10);
            }

            for (int i = 0; i < arr3.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    arr3[i] = (arr1[i] + arr2[i]);
                }
                else
                {
                    arr3[i] = 0;
                }
            }

            var sums = new int[3];
            for (int i = 0; i < arr1.Length; i++)
            {
                sums[0] += arr1[i];
                sums[1] += arr2[i];
                sums[2] += arr3[i];
            }

            Console.WriteLine("Showing sum of each array's values:");
            Console.WriteLine($"Array 1: {sums[0]}");
            Console.WriteLine($"Array 2: {sums[1]}");
            Console.WriteLine($"Array 3: {sums[2]}");

            EndAssignment();
        }

        // Ask for 10 numbers, add them to array. Display all even numbers.
        private void Assignment_3(string[] args)
        {
            var numbers = new int[10];

            for (int i = 1; i < 11; i++)
            {
                Console.Write($"Please enter number {i} to add to array: ");
                numbers[i - 1] = Convert.ToInt32(TakeKeys());
            }

            Console.Write("Showing your even numbers: ");

            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{item}, ");
                }
            }

            EndAssignment();
        }

        // Ask for 9 numbers, and add them to array. Show requested number from array.
        private void Assignment_2(string[] args)
        {
            var numbers = new int[9];

            for (int i = 1; i < 10; i++)
            {
                Console.Write($"Please enter number {i} to add to array: ");
                numbers[i - 1] = Convert.ToInt32(TakeKeys());
            }

            Console.WriteLine();
            Console.Write("Which number would you like to display? (1-9) : ");
            var num = Convert.ToInt32(TakeKeys());
            if (num < 0)
            {
                num = 0;
                Console.WriteLine("Number was lower than minimum, changed to 0.");
            }
            else if (num > 9)
            {
                num = 9;
                Console.WriteLine("Number was higher than maximum, changed to 9.");
            }

            Console.WriteLine($"Your requested number is: {numbers[num - 1]}");

            EndAssignment();
        }


        private void Assignment_1(string[] args)
        {
            var sum = 0;

            Console.Write("Please enter a number: ");
            sum += Convert.ToInt32(TakeKeys());
            Console.Write("Please enter a second number: ");
            sum += Convert.ToInt32(TakeKeys());
            Console.Write("Please enter a third and final number: ");
            sum += Convert.ToInt32(TakeKeys());

            Console.WriteLine($"Sum of numbers: {sum}");
            EndAssignment();
        }

        // extra
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
