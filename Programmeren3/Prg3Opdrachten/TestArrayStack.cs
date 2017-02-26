using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    public class TestArrayStack
    {
        private static decimal fillFactor = 0.25m;

        [Test]
        public void TestStackOperations()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
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
        public void TestCount()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

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
            ArrayStack<int> stack = new ArrayStack<int>();
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

        [Test]
        public void TestCapacity()
        {
            //capacity 2,4,8,16,32,64
            ArrayStack<int> stack = new ArrayStack<int>();
            int powerOfTwo = 2;
            for (int i = 0; i < 64; i++)
            {
                stack.Push(i);

                if (i == powerOfTwo)
                {
                    powerOfTwo = powerOfTwo * 2;
                }

                Assert.AreEqual(powerOfTwo, stack.Capacity);
            }

            //capacity 64, 32 (cnt=15), 16 (cnt=7), 8 (cnt=3), 4 (cnt=1), 2 (cnt=0)
            for (int i = 0; i < 64; i++)
            {
                stack.Pop();
                if (stack.Count < powerOfTwo * fillFactor)
                {
                    powerOfTwo = powerOfTwo / 2;
                }
                Assert.AreEqual(powerOfTwo, stack.Capacity);
            }
        }
    }
}
