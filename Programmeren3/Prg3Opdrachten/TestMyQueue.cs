using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    public class TestMyQueue
    {
        [Test]
        public void TestCount()
        {
            MyQueue<int> cq = new MyQueue<int>(4);

            Assert.AreEqual(0, cq.Count);
            Assert.AreEqual(0, cq.Count);

            cq.Enqueue(1);

            Assert.AreEqual(1, cq.Count);
            Assert.AreEqual(1, cq.Count);

            cq.Enqueue(2);

            Assert.AreEqual(2, cq.Count);
            Assert.AreEqual(2, cq.Count);

            cq.Dequeue();
            cq.Enqueue(2);

            Assert.AreEqual(2, cq.Count);
            Assert.AreEqual(2, cq.Count);

            cq.Dequeue();
            cq.Dequeue();

            Assert.AreEqual(0, cq.Count);
            Assert.AreEqual(0, cq.Count);
        }

        [Test]
        public void TestEnqueDeque()
        {
            MyQueue<int> cq = new MyQueue<int>(4);
            for (int i = 0; i < 10; i++)
            {
                cq.Enqueue(1);
                cq.Dequeue();
            }
            Assert.AreEqual(0, cq.Count);
        }

        [Test]
        public void TestEnqueueFullException()
        {
            MyQueue<int> cq = new MyQueue<int>(4);
            cq.Enqueue(1);
            cq.Enqueue(2);
            cq.Enqueue(3);
            cq.Enqueue(4);
            Assert.Catch(() => cq.Enqueue(5)); //should be full
        }

        [Test]
        public void TestDequeueEmptyException()
        {
            MyQueue<int> cq = new MyQueue<int>(4);
            Assert.Catch(() => cq.Dequeue()); //should be empty exception

            cq.Enqueue(1);
            cq.Enqueue(2);
            cq.Enqueue(3);
            cq.Enqueue(4);

            Assert.AreEqual(1, cq.Dequeue());
            Assert.AreEqual(2, cq.Dequeue());
            Assert.AreEqual(3, cq.Dequeue());
            Assert.AreEqual(4, cq.Dequeue());

            Assert.Catch(() => cq.Dequeue()); //should be empty exception
        }
    }
}
