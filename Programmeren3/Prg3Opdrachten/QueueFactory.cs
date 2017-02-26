using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    public class QueueFactory
    {
        public enum QueueType
        {
            Queue,
            MyQueue
        }

        private static QueueType type = QueueType.Queue;

        public static void SetQueueType(QueueType queueType)
        {
            type = queueType;
        }

        public static IQueue<T> CreateQueue<T>(int capacity = 10)
        {
            switch (type)
            {
                case QueueType.Queue: return new QueueAdapater<T>(new Queue<T>());
                case QueueType.MyQueue: return new MyQueue<T>(capacity);
                default: throw new ArgumentException();
            }
        }
    }

    public interface IQueue<T>
    {
        int Count { get;  }

        T Dequeue();
        void Enqueue(T item);
        T Peek();
    }

    public class QueueAdapater<T> : IQueue<T> 
    {
        private Queue<T> queue;

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        public QueueAdapater(Queue<T> queue)
        {
            this.queue = queue;
        }



        public T Dequeue()
        {
            return queue.Dequeue();
        }
        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }
        
        public T Peek()
        {
            return queue.Peek();
        }


    }
}
