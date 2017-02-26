using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
	// week 46
    class Chapter11Iteration
    {
        //Write a method to count how many odd numbers are in an array.
        [Test]
        public void TestExercise1()
        {
            Programmeren2Tests.Chapter11Test.TestExercise1(Exercise1);
        }

        public static int Exercise1(int[] xs)
        {
            // use linq to return the number of odd elements in an array
			int c = xs.ToList().Count(i => i % 2 != 0);
	        Debug.WriteLine($"Count: {c}");
			return c;

			// alternatively
	        int count = 0;
	        foreach (int i in xs)
	        {
				if (i % 2 != 0)
				 count += i;
	        }
			return count;
        }

        //Sum up all the even numbers in an array.
        [Test]
        public void TestExercise2()
        {
            Programmeren2Tests.Chapter11Test.TestExercise2(Exercise2);
        }

        public static int Exercise2(int[] xs)
        {
			// use linq to sum all even numbers
			int s = xs.ToList().Where(i => i % 2 == 0).Sum();
	        Debug.WriteLine($"Sum: {s}");
	        return s;

			// alternatively, but linq is the way to go
	        int sum = 0;
	        foreach (int i in xs)
	        {
				if (i % 2 == 0)
					sum += i;
	        }
			return sum;

			//or this
	        sum = 0;
	        Array.ForEach(xs, delegate(int i)
	        {
				if (i % 2 == 0)
					sum += i;
	        });
			return sum;
        }


        //Sum up all the negative numbers in an array.
        [Test]
        public void TestExercise3()
        {
            Programmeren2Tests.Chapter11Test.TestExercise3(Exercise3);
        }

        public static int Exercise3(int[] xs)
        {
			int s = xs.ToList().Where(i => Math.Sign(i) < 0).Sum();
	        Debug.WriteLine($"Sum: {s}");
			return s;

			// alternatively
	        int sum = 0;
	        foreach (int i in xs)
	        {
				if (Math.Sign(i) < 0)
					sum += i;
	        }
			return sum;
			// you can also do Math.Sign manually like this, make sure to filter out 0 because you can't divide by 0
	        // int sign = number/Math.Abs(number);
			// sign returns -1 for negative numbers, 0 if the number is 0 , otherwise 1
        }

        //Count how many words in an array have length 5. (Use help to find out how to determine the length of a string.)
        [Test]
        public void TestExercise4()
        {
            Programmeren2Tests.Chapter11Test.TestExercise4(Exercise4);
        }

        public static int Exercise4(string[] xs)
        {
			int c = xs.Count(s => s.Length == 5);
	        Debug.WriteLine($"Count: {c}");
			return c;

			// alternatively
	        int count = 0;
	        foreach (string s in xs)
	        {
		        if (s.Length == 5)
			        count++;
	        }
			return count;

			// even more alternatively
	        int char_count = 0;
	        count = 0;
			foreach (string s in xs)
			{
				char_count = 0;
				foreach (char character in s)
					char_count++;

				if (char_count == 5)
					count++;
			}
			return count;
		}

        //Sum all the elements in an array up to but not including the first even number. 
        //(Write your unit tests. What about the case when there is no even number?)
        [Test]
        public void TestExercise5()
        {
            Programmeren2Tests.Chapter11Test.TestExercise5(Exercise5);
        }

        public int Exercise5(int[] xs)
        {
	        int sum = 0;
	        foreach (int i in xs)
	        {
				if (i % 2 == 0) // break once we hit an even number
					break;
				sum += i;
	        }
	        Debug.WriteLine($"Sum: {sum}");
			return sum;
        }

        //Count how many words occur in an array up to and including the first occurrence of the word “sam”. 
        //(Write your unit tests for this case too. Do something sensible if “sam” does not occur.)
        [Test]
        public void TestExercise6()
        {
            Programmeren2Tests.Chapter11Test.TestExercise6(Exercise6);
        }

        public int Exercise6(string[] xs)
        {
	        int count = 0;
	        foreach (string s in xs)
	        {
		        count++;
				if (s.ToLower() == "sam")
					break;
				// alternatively: s.ToLower().Contains("sam")
	        }
			Debug.WriteLine($"Count: {count}");
			return count;
        }

        //Add a print statement to Newton’s sqrt method to show better each time it is calculated. 
        //In Testprogramma kan je geen Console.WriteLine gebruiken, maar wel:
        //System.Diagnostics.Debug.WriteLine(better);
        //Call your modified method with 25 as an argument and record the results.
        //Write down the result in comments
        //This is not a real test, but rather an exercise in tracing
        //Extra assignment: try to capture the values of the variable better with the debugging 
        //facilities from Visual Studio 

        [Test]
        public void TestExercise7()
        {
            sqrt(25);
        }

        public static double sqrt(double n)
        {
            double approx = n / 2.0;     // Start with some or other guess at the answer
            while (true) // loop 'infinitely'
            {
                double better = (approx + n / approx) / 2.0;
				Debug.WriteLine(better); // show 'better' when calculated
				if (Math.Abs(approx - better) < 0.001)
                {
                    return better;
                }
                approx = better;
            }
        }

        //Trace the execution of the last version of generateTable and make yourself more 
        //comfortable with single stepping, and debugging.
        [Test]
        public void TestExercise8()
        {
            generateMultiplicationTable(5);
        }

        public static void generateMultiplicationTable(int sz)
        {
            for (int r = 1; r <= sz; r++)
            {
                for (int c = 1; c <= r; c++)
                {
                    Debug.Write(string.Format("{0,5}", r * c));
					// use string interpolation instead! $"{0,5}" instead of string.Format
                }
                Debug.Write("\n");
            }
        }

        //Write a method that prints the n-th triangular numbers. 
        //A call to triangular_numbers(5) would produce the following output: 15
        //https://en.wikipedia.org/wiki/Triangular_number
        [Test]
        public void TestExercise9()
        {
            Programmeren2Tests.Chapter11Test.TestExercise9(Exercise9);
        }

        public static int Exercise9(int n)
        {
			int nth = n * (n + 1) / 2;
			Debug.WriteLine($"n-th: {nth}");
			return nth;
        }


        //What happens if we call our Collatz sequence generator with a negative integer?
        //What happens if we call it with zero?
        //Change the method so that it outputs an error message in either of these cases, and doesn’t get into an infinite loop.
		[Test]
        public static void TestExercise10()
        {
            //Collatz(-10); // works
            //Collatz(0); // works
	        Collatz(150);
        }

        private static void Collatz(int n)
        {
			// throw new exception if negative or 0
	        int sign = Math.Sign(n);
	        if (sign < 0)
		        throw new Exception("n for Collatz cannot be negative!");
			else if (sign == 0)
		        throw new Exception("n for Collatz cannot be zero!");

            while (n != 1)
            {
                Debug.WriteLine("{0}, ", n);
                if (n % 2 == 0)        // n is even
                {
                    n /= 2;
                }
                else                  // n is odd
                {
                    n = n * 3 + 1;
                }
            }
            Debug.WriteLine("{0}. Yes, it got to 1!", n);
        }

        //Write a method, isPrime, which takes a single integer argument and returns true 
        //when the argument is a prime number and false otherwise. 
        //Add tests for cases like this:
        //The last cases could represent your birth date. 
        //Were you born on a prime day? In a class of 100 students, how many do you think would have prime birth dates?
        [Test]
        public void TestExercise11()
        {
            Programmeren2Tests.Chapter11Test.TestExercise11(Exercise11);
        }

        public static bool Exercise11(int n)
        {
	        bool b = IsPrime(n);
	        Debug.WriteLine($"is {n} a prime? {b}");
	        return IsPrime(n);
        }

	    private static bool IsPrime(int number)
	    {
			for (int i = 3; (i * i) <= number; i += 2)
			{
				if (number % i == 0)
				{
					return false;
				}
			}
			return number != 1;
		}

        //What will num_digits(0) return? Modify it to return 1 for this case. 
        //Does a call to num_digits(-12345) work? 
        //Trace through the execution and see what happens if you start with a negative number. 
        //Modify num_digits so that it works correctly with any integer value. 
        //Add these tests:
        [Test]
        public void TestExercise15()
        {
	        Debug.WriteLine(num_digits(-12345));
	        Debug.WriteLine(num_digits(0));
			Debug.WriteLine(num_digits(501));
        }

        public static int num_digits(int n)
        {
	        n = Math.Abs(n); // handle negative numbers
	        if (n == 0) return 1; // log10(0) is undefined, so return 1
			return (int)Math.Floor(Math.Log10(n)) + 1; // shorter version instead of looping stuff

			// 1 liner
			return n == 0 ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(n))) + 1;
		}

		[Test]
        //Without making use of strings, write a method numEvenDigits(n) that counts 
        //the number of even digits in n. Here are some tests that should pass:
        //Remark: don't use conversions/casts, i.e. don't use strings!
        public void TestExercise16()
        {
			Assert.AreEqual(NumEvenDigits(123456), 3);
			Assert.AreEqual(NumEvenDigits(2468), 4);
			Assert.AreEqual(NumEvenDigits(1357), 0);
			// Normally we never put leading zeros on numbers, but our number
			// system has a special case that probably needs special case handling in the code.
			Assert.AreEqual(NumEvenDigits(0), 1);
			Assert.AreEqual(NumEvenDigits(0002468), 4);
			Assert.AreEqual(NumEvenDigits(-12345), 2);
			Assert.AreEqual(NumEvenDigits(-2468), 4);

			Programmeren2Tests.Chapter11Test.TestExercise16(NumEvenDigits);
        }

        public static int NumEvenDigits(int n)
        {
			n = Math.Abs(n); // take absolute value
	        if (n == 0) return 1; // 0 is an even number
			int count = 0;
			while (n != 0)
			{
				int right = n%10; // take right number
				if (right % 2 == 0) // digit is even
					count++;
				n /= 10;
			}
			Debug.WriteLine($"Count: {count}");
			return count;

			// alternatively (but with string)
	        return n.ToString().Count(c => char.IsDigit(c) && c % 2 == 0);
        }

        //Write a method sum_of_squares(xs) that computes the sum of the squares of the numbers in the array xs. For example, 
        //sum_of_squares(new double[] {2, 3, 4}) should return 4+9+16 which is 29:
        [Test]
        public void TestExercise17()
        {
            Programmeren2Tests.Chapter11Test.TestExercise17(Exercise17);
        }

        public static double Exercise17(double[] xs)
        {
	        double total = 0;
	        xs.ToList().ForEach(x => total += Math.Pow(x, 2));
			// this is basically it:
	        //foreach (double d in xs)
	        //{
		       // total += Math.Pow(d, 2);
	        //}
	        Debug.WriteLine($"Total: {total}");
			return total;
        }
    }
}
