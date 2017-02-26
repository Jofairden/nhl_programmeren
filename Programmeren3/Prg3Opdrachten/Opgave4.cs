using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    class Opgave4
    {
        //zie Blackboard voor opdrachten uitleg
        public static int PostFixEvaluation(string postfix)
        {
            IStack<int> stack = StackFactory.CreateStack<int>();
            throw new NotImplementedException();
        }

        static List<string> operators = new List<string> { "*", "/", "+", "-" };
        static List<int> precedence = new List<int> { 3, 3, 4, 4 };   //zie https://en.wikipedia.org/wiki/Order_of_operations        

        public static string ToPostfix(string infix)
        {
            IStack<string> op = StackFactory.CreateStack<string>();
            throw new NotImplementedException();
        }

        [Test]
        public void TestEvaluate1()
        {
            string postfix = "1 5 +";
            int expected = 1 + 5;
            int actual = PostFixEvaluation(postfix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEvaluate2()
        {
            string postfix = "3 2 + 4 *";
            int expected = (3 + 2) * 4;
            int actual = PostFixEvaluation(postfix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEvaluate3()
        {
            string postfix = "7 8 + 3 2 + /";
            int expected = (7 + 8) / (3 + 2); //15/5=3 //let op als je 5/15=0 zit je dichtbij, / is niet commutative
            int actual = PostFixEvaluation(postfix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix1()
        {
            string infix = "3 - 4 * 5";
            string expected = "3 4 5 * -";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix2()
        {
            string infix = "A * B + C * D";
            string expected = "A B * C D * +";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix3()
        {
            string infix = "( 3 - 4 ) * 5";
            string expected = "3 4 - 5 *";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix4()
        {
            string infix = "A * B + C * D";
            string expected = "A B * C D * +";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix5()
        {
            string infix = "A * ( B + C ) * D";
            string expected = "A B C + * D *";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToPostfix6()
        {
            string infix = "( 7 + 8 ) / ( 3 + 2 )";
            string expected = "7 8 + 3 2 + /";
            string actual = ToPostfix(infix);
            Assert.AreEqual(expected, actual);
        }
    }
}
