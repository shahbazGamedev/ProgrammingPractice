namespace Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T value);

        void Dequeue();

        T Peek();

        int Count();

        bool Contains(T value);

        void Clear();
    }
}

