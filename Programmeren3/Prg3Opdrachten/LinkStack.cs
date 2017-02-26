using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    //zie Blackboard voor opdrachten uitleg
    public class LinkStack<T> : IStack<T>
    {
        private class Node
        {
            public T value;
            public Node next;
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Push(T value)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }

   
}
