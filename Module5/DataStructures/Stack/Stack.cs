using System;
using LinkedList;

namespace Stack
{
    public class Stack<T> : IStack<T>
    {
        public Stack()
        {
            this.elements = new LinkedList<T>();
        }

        private LinkedList<T> elements;

        public void Push(T value)
        {
            this.elements.AddLast(value);
        }

        public void Pop()
        {
            int count = this.elements.Count;

            this.elements.RemoveAt(count - 1);
        }

        public T Peek()
        {
            return this.elements.Last();
        }

        public int Count()
        {
            return this.elements.Count;
        }

        public bool Contains(T value)
        {
            return this.elements.Contains(value);
        }

        public void Clear()
        {
            this.elements.Clear();
        }
    }
}

