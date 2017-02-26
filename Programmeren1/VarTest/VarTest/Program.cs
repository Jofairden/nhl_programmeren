using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < int.MaxValue; j++)
                {
                    var variable = rand.Next(int.MaxValue);
                }
            }


            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
            stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < int.MaxValue; j++)
                {
                    int variable = rand.Next(int.MaxValue);
                }
            }
            

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
            Console.ReadLine();
        }
    }
}
