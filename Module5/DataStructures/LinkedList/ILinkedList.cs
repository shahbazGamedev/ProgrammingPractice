namespace LinkedList
{
    public interface ILinkedList<T>
    {
        void AddFirst(T value);

        void AddLast(T value);

        void AddAfter(T afterValue, T value);

        void AddBefore(T beforeValue, T value);

        void InsertAt(int index, T value);

        void RemoveAt(int index);

        int IndexOf(T value);

        bool Contains(T value);

        void Clear();

        void Swap(int first, int second);
    }
}

