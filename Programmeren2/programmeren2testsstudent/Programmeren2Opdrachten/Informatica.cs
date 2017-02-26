using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
    public class Student
    {
        public int StudentNr { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int VakNr { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    }

    public class Exam
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public decimal Score { get; set; }
    }

    public class TentamenCijfers
    {
        private static Student jan =        new Student() { StudentNr = 1, Name = "Jan" };
        private static Student piet =       new Student() { StudentNr = 2, Name = "Piet" };
        private static Student klaas =      new Student() { StudentNr = 3, Name = "Klaas" };
        private static Student katrijn =    new Student() { StudentNr = 4, Name = "Katrijn" };

        private static List<Student> students = new List<Student>() {
            jan, piet, klaas, katrijn
        };

        private static Course cSharp =  new Course() { VakNr = 1, Name = "C#", Teacher = "Joris" };
        private static Course math =    new Course() { VakNr = 2, Name = "Wiskunde", Teacher = "Jos" };
        private static Course coo =     new Course() { VakNr = 3, Name = "Computer Organisation", Teacher = "Sibbele" };
        private static Course se =      new Course() { VakNr = 4, Name = "Software Engineering", Teacher = "David" };
        private static Course python  = new Course() { VakNr = 5, Name = "Python", Teacher = "Wouter" };

        private static List<Course> courses = new List<Course>() {
            cSharp, math, coo, se, python
        };

        private static List<Exam> exams = new List<Exam>() {
            new Exam() { Student = jan,       Course = math,      Score = 3 },
            new Exam() { Student = piet,      Course = math,      Score = 5 },
            new Exam() { Student = jan,       Course = coo,       Score = 7 },
            new Exam() { Student = klaas,     Course = cSharp,    Score = 9 },
            new Exam() { Student = jan,       Course = cSharp,    Score = 5 },
            new Exam() { Student = jan,       Course = math,      Score = 6 },
            new Exam() { Student = katrijn,   Course = cSharp,    Score = 6 },
            new Exam() { Student = katrijn,   Course = coo,       Score = 6 },
            new Exam() { Student = piet,      Course = math,      Score = 8 },
            new Exam() { Student = piet,      Course = coo,       Score = 5 },
            new Exam() { Student = katrijn,   Course = se,        Score = 8 },
            new Exam() { Student = katrijn,   Course = se,        Score = 9.5m }
        };

		// self method
		public static IEnumerable<Exam> GetExamsByStudentName(string name)
		{
			return exams.Where(x => x.Student.Name.ToUpper() == name.ToUpper());
		}

        //Geef alle scores van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetScoreByStudentName()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(new List<decimal>() { 3, 7, 5, 6 }, GetScoreByStudentName("jan"));
        }

        public static List<decimal> GetScoreByStudentName(string name)
		{
			List<decimal> scores = new List<decimal>();
			GetExamsByStudentName(name).ToList().ForEach(x => scores.Add(x.Score));
			return scores;
        }

        //Bepaal het hoogste behaalde resultaat van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetHighestScoreByStudentName()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(7, GetHighestScoreByStudentName("jan"));
        }

        public static decimal GetHighestScoreByStudentName(string name)
        {
			return GetExamsByStudentName(name).Max(exam => exam.Score);
        }

        //Welke studenten hebben alleen maar voldoendes gehaald?
        [Test]
        public static void TestGoodStudents()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(new List<Student>() { klaas, katrijn }, GoodStudents());
        }

		// custom linq feature,alternate to line 3 in GoodStudents()
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>
	(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			HashSet<TKey> seenKeys = new HashSet<TKey>();
			foreach (TSource element in source)
			{
				if (seenKeys.Add(keySelector(element)))
				{
					yield return element;
				}
			}
		}

		public static List<Student> GoodStudents()
        {
			List<Student> students = new List<Student>(); // new list of students
			exams.GroupBy(exam => exam.Student).Select(student => student.First()).ToList().ForEach(exam => students.Add(exam.Student)); // get all students in exams, add them
			//DistinctBy(exams, exam => exam.Student).ToList().ToList().ForEach(exam => students.Add(exam.Student));
			for (int i = 0; i < students.Count; i++) // loop students
			{
				Student student = students[i]; // current student
				List<Exam> all = exams.Where(exam => exam.Student == student).ToList(); // get all exams of current student
				if (all.Any(exam => exam.Score < 5.5m)) // if any score is < 5.5m
				{
					students.RemoveAt(i); // remove this student, it's not a good student
					i--; // subtract from i because student was removed
				}
			};
			return students;
        }

        //Voor welke vak zijn de meeste toetsen gedaan?
        [Test]
        public static void TestMostExamsByCourse()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(math, MostExamsByCourse());
        }

        public static Course MostExamsByCourse()
        {
			// ;) linq ftw
			// groups the courses by their count, return the first course (which is the most frequent)
			var count = from exam in exams
						group exam.Course by exam.Course into g
						select new { g.Key, Count = g.Count() };
			return count.FirstOrDefault().Key;
        }

        //Bepaal voor iedere student zijn gemiddelde score 
        //Pittig
        [Test]
        public static void TestGetAverageScoreByStudent()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(new List<StudentAverage>() { new StudentAverage { Name = "jan", Score = 5.25m } }, GetAverageScoreByStudent("jan"));
        }

        public class StudentAverage
        {
            public String Name { get; set; }
            public decimal Score { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is StudentAverage)
                {
                    StudentAverage s = (StudentAverage)obj;
                    return Name == s.Name && Score == s.Score;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode() + Score.GetHashCode();
            }
        }

		// waarom return een lijst van student averages, terwijl er geen student average list wordt gegeven ?
		public static List<StudentAverage> GetAverageScoreByStudent(string name)
		{
			IEnumerable<Exam> all = GetExamsByStudentName(name); // get exams from student
			List<StudentAverage> avg = new List<StudentAverage>(); // new list of avg
			avg.Add(new StudentAverage() { Name = name, Score = all.Average(exam => exam.Score) }); // add a new student average to the list
			return avg;
        }

        //Pittig: Hoeveel herkansingen zijn er gedaan?
        //Een herkansing is een toest die nog een keer is gedaan door dezelfde student
        [Test]
        public static void TestNumberOfResits()
        {
			//schrijf je eigen test cases
			Assert.AreEqual(2, NumberOfResits());
        }
        
        public static int NumberOfResits()
        {
			List<Student> students = new List<Student>(); // new list of students
			Dictionary<Student, List<Exam>> dict = new Dictionary<Student, List<Exam>>();
			exams.GroupBy(exam => exam.Student).Select(student => student.First()).ToList().ForEach(exam => students.Add(exam.Student)); // get all students in exams, add them
			foreach (Student student in students)
				dict.Add(student, exams.Where(exam => exam.Student.Name.ToUpper() == student.Name.ToUpper()).ToList());
			int resits = 0;
			foreach (KeyValuePair<Student, List<Exam>> item in dict)
			{
				List<Course> distCourses = item.Value.Select(exam => exam.Course).ToList();
				foreach (Course distCourse in distCourses)
				{
					if (item.Value.Where(exam => exam.Course == distCourse).Count() > 1)
						resits++;
				}
			}
			return resits;
		}
    }
}
