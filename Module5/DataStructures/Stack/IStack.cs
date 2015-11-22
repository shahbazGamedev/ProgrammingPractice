namespace Stack
{
    public interface IStack<T>
    {
        void Push(T value);

        void Pop();

        T Peek();

        int Count();

        bool Contains(T value);

        void Clear();
    }
}

