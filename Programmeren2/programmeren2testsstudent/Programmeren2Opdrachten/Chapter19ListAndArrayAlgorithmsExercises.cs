using NUnit.Framework;
using Programmeren2Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
    class Chapter19ListAndArrayAlgorithmsExercises
    {
        //The section in this chapter called Alice in Wonderland, again! 
        //started with the observation that the merge algorithm uses a pattern that 
        //can be reused in other situations. Adapt the merge algorithm to write each of 
        //these methods, as was suggested there:
        //
        //a Return only those items that are present in both arrays.
        //the array's xs and ys don't contain any duplicates

        //Example:  int[] xs = { 1, 2, 3, 4, 5 }; int[] ys = { 1, 2, 4 }; ==> zs = {1, 2, 4}
        [Test]
        public void Programmeren2TestsA()
        {
            Chapter19Test.TestExercise19A(Exercise19A);
        }

        public static int[] Exercise19A(int[] xs, int[] ys)
        {
	        if (xs == null || ys == null)
		        throw new ArgumentNullException();

	        List<int> joined = xs.ToList().Concat(ys).ToList(); // join arrays together, (concatenate)
			// make an array of just the duplicates, SQL like code
	        int[] duplicates = joined.GroupBy(x => x) // group by number
		        .Where(group => group.Count() > 1) // where there is more than 1 of the number
		        .Select(group => group.Key).ToArray(); // select just the number, make it an array
	        return duplicates;
        }

        //b Return only those items that are present in the first array, but not in the second.
        //the array's xs and ys don't contain any duplicates
        //Example:  int[] xs = { 1, 2, 3, 4, 5 }; int[] ys = { 2 }; ==> zs = {1, 3, 4, 5}
        [Test]
        public void TestExercice1B()
        {
            Chapter19Test.TestExercise19B(Exercise19B);
        }

        public static int[] Exercise19B(int[] xs, int[] ys)
        {
	        return ReturnSingles(xs, ys);
        }

        //Return only those items that are present in the second list, but not in the first.
        //the array's xs and ys don't contain any duplicates

        //Example: int[] xs = { 1, 8, 9, 10, 30 }; int[] ys = { 0, 1, 5, 9, 11, 24 }; ==> int[] zs = { 0, 5, 11, 24 };
        [Test]
        public void TestExercice1C()
        {   
            Chapter19Test.TestExercise19C(Exercise19C);
        }

        public static int[] Exercise19C(int[] xs, int[] ys)
        {
			//same as 1b, but reverse
	        return ReturnSingles(ys, xs);
        }

		/// <summary>
		/// Returns elements present in the source array, but not in the secondary
		/// </summary>
		/// <param name="source">The source array</param>
		/// <param name="secondary">The secondary array</param>
	    private static int[] ReturnSingles(int[] source, int[] secondary)
	    {
			if (source == null || secondary == null)
				throw new ArgumentNullException();

			List<int> singles = new List<int>(); // make empty list
			foreach (int i in source) // loop first array contents (xs)
			{
				if (!secondary.Contains(i)) // if ys doesnt contain i element of xs
					singles.Add(i); // add it to the list
			}
			return singles.ToArray(); // return the list in array form
		}

        //Return items that are present in either the first or the second list.
        //the array's xs and ys don't contain any duplicates
        //int[] xs = { 1, 8, 9, 10, 30 }; int[] ys = { 0, 1, 5, 9, 11, 24 }; int[] zs = { 0, 5, 8, 10, 11, 24, 30 };
        [Test]
        public void Programmeren2TestsD()
        {
            Chapter19Test.TestExercise19D(Exercise19D);
        }

        public static int[] Exercise19D(int[] xs, int[] ys)
        {
			if (xs == null || ys == null)
				throw new ArgumentNullException();

			//fuck u I use var
			var list1 = xs.Except(ys); // or use my own method: ReturnSingles
			var list2 = ys.Except(xs);
			var singles = list1.Concat(list2).ToList();
			singles.Sort();
			return singles.ToArray();
		}


        //Return items from the first list that are not eliminated by a matching element in 
        //the second list. In this case, an item in the second list “knocks out” just 
        //one matching item in the first list. This operation is sometimes called bagdiff. 
        //For example bagdiff(new int[] {5,7,11,11,11,12,13}, new int[] {7,8,11}); 
        //would return new int[] {5,11,11,12,13}
        [Test]
        public void Programmeren2TestsE()
        {
            Chapter19Test.TestExercise19E(Exercise19E);
        }

	    public static int[] Exercise19E(int[] xs, int[] ys)
	    {
		    return BagDiff(xs, ys);
	    }

	    private static int[] BagDiff(int[] xs, int[] ys)
	    {
			List<int> diff = new List<int>(); // new list
			List<int> bag = ys.ToList(); // bag list to list
			for (int i = 0; i < xs.Length; i++) // loop over xs
			{
				if (bag.Contains(xs[i])) // if the bag contains i element from xs
				{
					bag.Remove(xs[i]); // remove it from the bag
				}
				else diff.Add(xs[i]); // else add it to our diff list
			}
			return diff.ToArray(); // return diff in array form
		}

    }
}
