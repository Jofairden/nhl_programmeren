using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    //https://en.wikipedia.org/wiki/Circular_buffer
    //zie sheets...
    //zie Blackboard voor opdrachten uitleg
    public class MyQueue<T> : IQueue<T>
    {
        //Mijn tip: gebruik een extra variabele count om bij te houden hoeveel elementen er momenteel in de queue zitten.
        //Dit vereenvoudigt de code!
      
        public int Count
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        public MyQueue(int capacity)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T value)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
