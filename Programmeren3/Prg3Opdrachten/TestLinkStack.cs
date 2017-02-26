using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    public class TestListStack
    {
        [Test]
        public void TestStackOperations()
        {
            LinkStack<int> stack = new LinkStack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            Assert.AreEqual(1, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(2, stack.Peek());

            stack.Push(3);
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(3, stack.Peek());

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(2, stack.Peek());

            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Peek());
            Assert.AreEqual(1, stack.Peek());

            Assert.AreEqual(1, stack.Pop());
            Assert.Catch(() => stack.Peek());   //een lege stack geeft een Exception!
            Assert.Catch(() => stack.Peek());   //een lege stack geeft een Exception!
        }

        [Test]
        public void TestPushPopCheck()
        {
            LinkStack<int> stack = new LinkStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [Test]
        public void TestCount()
        {
            LinkStack<int> stack = new LinkStack<int>();

            Assert.AreEqual(0, stack.Count);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Count);
            stack.Pop();
            Assert.AreEqual(2, stack.Count);
            stack.Pop();
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void TestPopEmpty()
        {
            LinkStack<int> stack = new LinkStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());

            //Op een lege stack kunnen we geen pop doen
            //we controleren op een "fout" (Exception)
            Assert.Catch(() => stack.Pop());
        }
    }
}
