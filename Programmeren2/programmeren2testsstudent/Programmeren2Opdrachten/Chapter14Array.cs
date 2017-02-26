using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
    class Chapter14Array
    {
        //1 Write a method to return the biggest item from a non-empty array of int. 
        //Provide some test cases to test your method.
        [Test]
        public void TestExercise1()
        {
			//write your own tests here
			Assert.AreEqual(Exercise1(new int[] { 1, 2, 3, 4, 5 }), 5);
			Assert.AreEqual(Exercise1(new int[] { 1, 2, 3, 4, 10 }), 10);
			Assert.AreEqual(Exercise1(new int[] { 1, 2, 3, 4, 20 }), 20);
			Assert.AreEqual(Exercise1(new int[] { 1, 150, 3, 4, 20 }), 150);

			Programmeren2Tests.Chapter14Test.TestExercise1(Exercise1);
		}

        public static int Exercise1(int[] xs)
        {
	        if (xs == null && xs.Length <= 0)
		        throw new IndexOutOfRangeException();

	        return xs.ToList().Max();

			int biggest = 0;

			foreach (int item in xs)
			{
				if (item > biggest)
					biggest = item;
			}

			return biggest;
        }

        //2 Write a method to return the sum of all the odd numbers in an array of int. 
        //Provide some test cases to test your method.
        [Test]
        public void TestExercise2()
        {
			//write your own tests here
			Assert.AreEqual(Exercise2(new int[] { 1, 2, 3, 4, 5 }), 9);
			Assert.AreEqual(Exercise2(new int[] { 1, 2, 3, 4, 10 }), 4);
			Assert.AreEqual(Exercise2(new int[] { 1, 2, 3, 4, 20 }), 4);
			Assert.AreEqual(Exercise2(new int[] { 1, 33, 3, 4, 20 }), 37);

			Programmeren2Tests.Chapter14Test.TestExercise2(Exercise2);
        }

        public int Exercise2(int[] xs)
        {
	        return xs.Where(i => i % 2 != 0).Sum();
        }

        //Write a method to search for a given target string in an array of strings. 
        //The method should return the index at which the target is found. 
        //If the target is not found, it should return -1. 
        //Provide test cases to test all the important cases: the target could match the first element or the last element in the array, or some element in the middle, or it may not exist in the array at all.
        [Test]
        public void TestExercise3()
        {
            //write your own tests here
	        Assert.AreEqual(0, Exercise3(new string[] {"blah", "heh", "kek", "c#"}, "blah"));
	        Assert.AreEqual(1, Exercise3(new string[] {"blah", "heh", "kek", "c#"}, "heh"));
	        Assert.AreEqual(2, Exercise3(new string[] {"blah", "heh", "kek", "c#"}, "kek"));
	        Assert.AreEqual(3, Exercise3(new string[] {"blah", "heh", "kek", "c#"}, "c#"));

			Programmeren2Tests.Chapter14Test.TestExercise3(Exercise3);
        }

        public static int Exercise3(string[] xs, string search)
        {
	        string first = xs.FirstOrDefault(s => s == search);
	        string last = xs.LastOrDefault(s => s == search);
	        if (first == null && last == null)
	        {
		        for (int i = 1; i < xs.Length - 1; i++)
		        {
					if (xs[i] == search)
						return i;
		        }
	        }
	        return first != null ? Array.IndexOf(xs, first) : last != null ? Array.IndexOf(xs, last) : -1;
        }
    
        //Use the method above to write a method that turns a month name into a corresponding month number, 
        //so that these tests pass:
        //Assert.AreEqual(Exercise4("January"), 1);
        //Assert.AreEqual(Exercise4("June"), 6);
        //Assert.AreEqual(Exercise4("November"), 11);
        //Assert.AreEqual(Exercise4("NoveMber"), 11);
        [Test]
        public void TestExercise4()
        {
			Assert.AreEqual(Exercise4("January"), 1);
			Assert.AreEqual(Exercise4("June"), 6);
			Assert.AreEqual(Exercise4("November"), 11);
			Assert.AreEqual(Exercise4("NoveMber"), 11);

			Programmeren2Tests.Chapter14Test.TestExercise4(Exercise4);
        }

        public static int Exercise4(string month)
        {
	        month = char.ToUpper(month[0], CultureInfo.CurrentCulture) + month.Substring(1).ToLower();
	        int mm = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
			Debug.WriteLine($"month: {month}, number: {mm}");
			return mm;
        }

        //5 Assume we have this definition in our code:
        //int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //Write a method that takes a day number and a month name, 
        //and returns the day number within the (non-leap) year. 
        //Assume days are numbered starting from 0. For example, dayMonthToDay("March", 12) 
        //should give the result 71.
        [Test]
        public void TestExercise5()
        {
			// teacher made some mistake as it's expecting results from leap years and non leap years, isn't filterable with no year passed
            Programmeren2Tests.Chapter14Test.TestExercise5(Exercise5);
        }

        public static int Exercise5(string month, int day)
        {
			// 2015 is a non-leap year
			return new DateTime(2015, Exercise4(month), day).DayOfYear;
        }

        //6. Arrays can be used to represent mathematical vectors. 
        //In the next few exercises we will write methods to perform standard operations on vectors. 
        //Write C# code to pass the tests in each case.
        [Test]
        public void TestExercise6()
        {
            Assert.AreEqual(DotProduct(new double[] {1, 1}, new double[] {1, 1}),  2);
            Assert.AreEqual(DotProduct(new double[] {1, 4.5}, new double[] {1, 2}), 10);
            Assert.AreEqual(DotProduct(new double[] {1, 4, 3}, new double[] {1, 2, 1}), 12);

            Programmeren2Tests.Chapter14Test.TestExercise6(DotProduct);

			Assert.AreEqual(DotProduct(new double[] { 1, 4, 3 }, new double[] { 1, 2, 1, 5, 6, 7, 8 }), 12); // can work with different sized arrays
			Assert.AreEqual(DotProduct(new double[] { 1, 4, 3, 6, 7, 8, 9, 10, 120, 500 }, new double[] { 1, 2, 1 }), 12); // can work with different sized arrays
		}

        public double DotProduct(double[] xs, double[] ys)
        {
			double d = 0d;

			// the following math allows for arrays with different sizes
			// think: array 1 has 4 values, array 2 has 6 values, or vice versa
		    int size = (xs.Length + ys.Length)/2; // take avg size, cut down
		    int diff = size; // diff = size, starting point
		    diff -= (xs.Length < ys.Length) ? xs.Length : ys.Length; // subtract length from diff. so if size was 5, and smallest array is 4, the diff is 1.
			size -= diff; // subtract diff from size. imagine array of 4 and array of 6, size is 5, diff is 1, size becomes 4.

			// do the math
			for (int i = 0; i < size; i++)
				d += xs[i] * ys[i];

			return d;
        }

        //7 Write a method AddVectors(u, v) that takes two arrays of doubles of the same length, 
        //and returns a new array containing the sums of the corresponding elements of each:
        [Test]
        public void TestExercise7() 
        {
            double[] v1 = {1, 1};
            double[] v2 = {2, 2};
            double[] v3 = {1, 2};
            double[] v4 = {1, 4};
            double[] v5 = {2, 6};
            double[] v6 = {1, 2, 1};
            double[] v7 = {1, 4, 3};
            double[] v8 = {2, 6, 4};

            Assert.AreEqual(AddVectors(v1, v1), v2);
            Assert.AreEqual(AddVectors(v3, v4), v5);
            Assert.AreEqual(AddVectors(v6, v7), v8);

            Programmeren2Tests.Chapter14Test.TestExercise7(AddVectors);
        }

        public double[] AddVectors(double[] xs, double[] ys)
        {
			// sort of the same as DotProduct, but does not allow different sized arrays, because the assignment states "that takes two arrays of doubls OF THE SAME LENGTH"
	        if (xs.Length != ys.Length)
		        throw new IndexOutOfRangeException();

	        int size = (xs.Length + ys.Length)/2;
	        double[] d = new double[size];

	        for (int i = 0; i < size; i++)
		        d[i] = xs[i] + ys[i];

			return d;
        }
        
        //8 Write a method scalarMult(s, v) that takes a number, s, and a array, 
        //v and returns the scalar multiple of v by s:
        [Test]
        public void TestExercise8()
        {
			//Examples of tests
			Assert.AreEqual(new double[] { 5.5, 11.0 }, Exercise8(5.5, new double[] { 1, 2 }));
			Assert.AreEqual(new double[] { 3, 0, -9 }, Exercise8(3, new double[] { 1, 0, -3 }));
			Assert.AreEqual(new double[] { 21, 0, 35, 77, 14 }, Exercise8(7, new double[] { 3, 0, 5, 11, 2 }));

			Programmeren2Tests.Chapter14Test.TestExercise8(Exercise8);
        }

        public double[] Exercise8(double scalar, double[] xs)
        {
			// again somewhat the same
	        int size = xs.Length;
			double[] d = new double[size];

			for (int i = 0; i < size; i++)
				d[i] = xs[i]*scalar;

			return d;
		}
    }
}
