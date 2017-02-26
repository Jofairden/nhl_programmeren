using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// daniel zondervan

namespace VoorbereidenTW1
{
    class Program
    {   
        // vraag1: schrijf een programma die je drie getalen invoeren en reken de gemiddelde er van
        public static void vraag1()
        {
            int loops = 3;
            int num = 0;
            
            for (int i = 0; i < loops; i++)
            {
                Console.Write("Geef een nummer: ");
                num += Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Gemiddelde: { (float)(num / loops)}");
            Console.ReadKey();
        }
        // vraag2:
        // declare een array getalen die heeft size7 
        // vul de array met getalen 
        //print de inhoud van de array 
        // print de array van achter naar voeren 
        public static void vraag2()
        {
            Random rand = new Random();
            int[] numbers = new int[7];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(numbers.Length);
                Console.WriteLine(numbers[i].ToString());
            }

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                Console.WriteLine(numbers[i].ToString());
            }

            Console.ReadKey();
        }
        // vraag3:  
        // enter 3 getalen en print de klein getal uit.
        public static void vraag3()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Geef een nummer: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            int lowest = numbers[0];

            foreach (var item in numbers)
            {
                if (item < lowest)
                    lowest = item;
            }

            Console.WriteLine($"Kleinste getal: {lowest}" );
        }
        static void Main(string[] args)
        {
            vraag1();
            vraag2();
            vraag3();

            Console.ReadKey();
        }
    }
}
