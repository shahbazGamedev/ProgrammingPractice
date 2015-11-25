using System;
using LinkedList;

namespace Queue
{
    public class Queue<T> : IQueue<T>
    {
        public Queue()
        {
            this.elements = new LinkedList<T>();
        }

        private LinkedList<T> elements;

        public void Enqueue(T value)
        {
            this.elements.AddFirst(value);
        }

        public void Dequeue()
        {
            int count = this.elements.Count;

            this.elements.RemoveAt(count - 1);
        }

        public T Peek()
        {
            return this.elements.Last;
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

