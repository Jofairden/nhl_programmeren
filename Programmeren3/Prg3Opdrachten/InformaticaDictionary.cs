using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    /* 
        De dictionaries zijn al aangemaakt, zie code hieronder. 
        De testcases zijn ook al gemaakt! 

        Er zijn verschillende dictionaries die je kunt gebruiken voor de opdrachten.
        Het idee is dat je dezelfde opdrachten nog eens maakt (van programmeren 2), 
        maar nu met dictionaries i.p.v. lijsten. 

        Opmerking: gebruik dus niet de lijst courses of exams in je methodes maar alleen de dictionaries.
        Let op: sommige dictionaries returnen niet 1 waarde maar een lijst van waardes. 
        
        Er is al 1 opdracht uitgewerkt, zie hiervoor de sheets van week 5.  
    */

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
        private static Student jan = new Student() { StudentNr = 1, Name = "Jan" };
        private static Student piet = new Student() { StudentNr = 2, Name = "Piet" };
        private static Student klaas = new Student() { StudentNr = 3, Name = "Klaas" };
        private static Student katrijn = new Student() { StudentNr = 4, Name = "Katrijn" };

        private static Course cSharp = new Course() { VakNr = 1, Name = "C#", Teacher = "Joris" };
        private static Course math = new Course() { VakNr = 2, Name = "Wiskunde", Teacher = "Jos" };
        private static Course coo = new Course() { VakNr = 3, Name = "Computer Organisation", Teacher = "Sibbele" };
        private static Course se = new Course() { VakNr = 4, Name = "Software Engineering", Teacher = "David" };
        private static Course python = new Course() { VakNr = 5, Name = "Python", Teacher = "Wouter" };

        
        private static Course pythonJoris = new Course() { VakNr = 6, Name = "Python", Teacher = "Joris" };
        

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

        //Zie opmerking hieronder!
        private static List<Course> courses = new List<Course>() {
            cSharp, math, coo, se, python //, pythonJoris
        };

        //Opmerking: dit gaat goed, maar dan ook alleen maar omdat geen enkele sleutel duplicaten heeft!
        //In de echt wereld gaat dit niet goed, als pythonJoris toegevoegd wordt ontstaat er een exception (runtime fout).
        private static Dictionary<int, Course> courseByVakNr = courses.ToDictionary(crs => crs.VakNr);
        private static Dictionary<string, Course> courseByName = courses.ToDictionary(crs => crs.Name);
        private static Dictionary<string, Course> courseByTeacher = courses.ToDictionary(crs => crs.Teacher);

        private static Dictionary<string, Student> studentByName = new Dictionary<string, Student>()
        {
            [jan.Name] = jan,
            [piet.Name] = piet,
            [klaas.Name] = klaas,
            [katrijn.Name] = katrijn
        };

        private static Dictionary<int, Student> studentByStudentNr = new Dictionary<int, Student>()
        {
            [jan.StudentNr] = jan,
            [piet.StudentNr] = piet,
            [klaas.StudentNr] = klaas,
            [katrijn.StudentNr] = katrijn
        };

        private static Dictionary<Student, List<Exam>> examsByStudent = CreateExamsByStudent();
        private static Dictionary<Course, List<Exam>> examsByCourse = CreateExamsByCourse();
        private static Dictionary<decimal, List<Exam>> examsByScore = CreateExamsByScore();

        public static Dictionary<Student, List<Exam>> CreateExamsByStudent()
        {
            Dictionary<Student, List<Exam>> res = new Dictionary<Student, List<Exam>>();
            foreach (Exam exam in exams)
            {
                if (!res.ContainsKey(exam.Student))
                {
                    res[exam.Student] = new List<Exam>();
                }

                res[exam.Student].Add(exam);
            }
            return res;
        }

        public static Dictionary<Course, List<Exam>> CreateExamsByCourse()
        {
            //dit geeft hetzelfde resultaat als de andere twee methoden
            return exams.GroupBy(x => x.Course)
                .ToDictionary(x => x.Key, x => x.ToList());
        }

        public static Dictionary<decimal, List<Exam>> CreateExamsByScore()
        {
            Dictionary<decimal, List<Exam>> res = new Dictionary<decimal, List<Exam>>();
            foreach (Exam exam in exams)
            {
                if (!res.ContainsKey(exam.Score))
                {
                    res[exam.Score] = new List<Exam>();
                }

                res[exam.Score].Add(exam);
            }
            return res;
        }

        //Geef alle scores van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetScoreByStudentName()
        {
            CollectionAssert.AreEquivalent(new List<decimal>() { 3, 7, 5, 6 }, GetScoreByStudentName("Jan"));
            CollectionAssert.AreEquivalent(new List<decimal>() { 5, 8, 5 }, GetScoreByStudentName("Piet"));
            CollectionAssert.AreEquivalent(new List<decimal>() { 9 }, GetScoreByStudentName("Klaas"));
            CollectionAssert.AreEquivalent(new List<decimal>() { 6, 6, 8, 9.5m }, GetScoreByStudentName("Katrijn"));
        }

        public static List<decimal> GetScoreByStudentName(string name)
        {
            throw new NotImplementedException();
        }

        //Bepaal het hoogste behaalde resultaat van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetHighestScoreByStudentName()
        {
            Assert.AreEqual(7, GetHighestScoreByStudentName("Jan"));
            Assert.AreEqual(8, GetHighestScoreByStudentName("Piet"));
            Assert.AreEqual(9, GetHighestScoreByStudentName("Klaas"));
            Assert.AreEqual(9.5m, GetHighestScoreByStudentName("Katrijn"));
        }

        public static decimal GetHighestScoreByStudentName(string name)
        {
            throw new NotImplementedException();
        }

        //Welke studenten hebben alleen maar voldoendes gehaald?
        [Test]
        public static void TestGoodStudents()
        {
            List<Student> expected = new List<Student>() { klaas, katrijn };
            CollectionAssert.AreEquivalent(expected, GoodStudents());
        }

        public static List<Student> GoodStudents()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

            public override string ToString()
            {
                return $"Name: {Name} Score: {Score}";
            }
        }

        //Bepaal voor een student (naam) zijn gemiddelde score 
        [Test]
        public static void TestGetAverageScoreByStudentName()
        {
            //schrijf je eigen test cases
            Assert.AreEqual(new StudentAverage() { Name = "Jan", Score = 21.0m / 4 }, GetAverageScoreByStudent("Jan"));
            Assert.AreEqual(new StudentAverage() { Name = "Piet", Score = 18.0m / 3 }, GetAverageScoreByStudent("Piet"));
            Assert.AreEqual(new StudentAverage() { Name = "Klaas", Score = 9.0m }, GetAverageScoreByStudent("Klaas"));
            Assert.AreEqual(new StudentAverage() { Name = "Katrijn", Score = 29.5m / 4 }, GetAverageScoreByStudent("Katrijn"));
        }

        public static StudentAverage GetAverageScoreByStudent(string name)
        {
            throw new NotImplementedException();
        }

        //Bepaal voor een alle student de gemiddelde score 
        [Test]
        public static void TestGetAverageScoreAllStudents()
        {
            List<StudentAverage> expected = new List<StudentAverage>()
            {
                new StudentAverage() {Name = "Jan", Score = 21.0m/4 },
                new StudentAverage() { Name = "Klaas", Score = 9.0m  },
                new StudentAverage() { Name = "Piet", Score = 18.0m / 3 },
                new StudentAverage() { Name = "Katrijn", Score = 29.5m / 4 }
            };

            CollectionAssert.AreEquivalent(expected, GetAverageScoreByStudent());
        }

        public static List<StudentAverage> GetAverageScoreByStudent()
        {
            throw new NotImplementedException();
        }

        //Pittig: Hoeveel herkansingen zijn er gedaan?
        //Een herkansing is een toest die nog een keer is gedaan door dezelfde student
        //Tip: doorloop de examsByStudent, maak in de body van deze lus een Dictionary<Course, int> aan en vul deze!
        [Test]
        public static void TestNumberOfResits()
        {
            Assert.AreEqual(3, NumberOfResits());
            //schrijf je eigen test cases
        }

        public static int NumberOfResits()
        {
            throw new NotImplementedException();
        }
    }
}
