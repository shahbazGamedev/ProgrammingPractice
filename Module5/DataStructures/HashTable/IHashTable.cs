using System;

namespace HashTable
{
    public interface IHashTable<TKey, TValue>
    {
        void Add(TKey key, TValue value);

        TValue GetValue(TKey key);

        void Delete(TKey key);
    }
}

