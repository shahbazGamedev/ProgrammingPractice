namespace LinkedList
{
    public interface ILinkedList<T>
    {
        void AddFirst(T value);

        void AddLast(T value);

        void AddAfter(T afterValue, T value);

        void AddBefore(T beforeValue, T value);

        void RemoveAt(int index);

        int IndexOf(T value);

        object ElementAt(int index);

        T First();

        T Last();

        bool Contains(T value);

        void Clear();
    }
}

