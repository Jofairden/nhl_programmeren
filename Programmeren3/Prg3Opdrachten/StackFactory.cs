using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    public class StackFactory
    {
        public enum StackType
        {
            Stack,
            Array,
            Link
        }

        private static StackType type = StackType.Stack;

        public void SetStackType(StackType stackType)
        {
            type = stackType;
        }

        public static IStack<T> CreateStack<T>()
        {
            switch (type)
            {
                case StackType.Stack:   return new StackAdapter<T>(new Stack<T>());
                case StackType.Link:    return new LinkStack<T>();
                case StackType.Array:   return new ArrayStack<T>();
                default: throw new ArgumentException();
            }
        }
    }

    public interface IStack<T>
    {
        int Count { get; }

        T Peek();
        T Pop();
        void Push(T item);
    }

    public class StackAdapter<T> : IStack<T>
    {
        private Stack<T> stack;

        public int Count {
            get {
                return stack.Count;
            }
        }

        public StackAdapter(Stack<T> stack)
        {
            this.stack = stack;
        }

        public T Peek()
        {
            return stack.Peek();
        }

        public T Pop() 
        {
            return stack.Pop();
        }

        public void Push(T item)
        {
            stack.Push(item);
        }
    }

}
