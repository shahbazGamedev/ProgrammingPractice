using System;
using LinkedList;

namespace HashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        public HashTable()
        {
            this.tableSize = 128;
            this.table = new LinkedList<KeyValuePair<TKey, TValue>>[tableSize];
        }

        private int tableSize;
        private LinkedList<KeyValuePair<TKey, TValue>>[] table;

        #region KeyValuePair

        public class KeyValuePair<TKey, TValue>
        {
            public KeyValuePair(TKey key, TValue value)
            {
                this.Key = key;
                this.Value = value;
            }

            public TKey Key { get; set; }

            public TValue Value { get; set; }
        }

        #endregion

        public void Add(TKey key, TValue value)
        {
            int hash = key.GetHashCode() % this.tableSize;

            if (this.table[hash] == null)
            {
                this.table[hash] = new LinkedList<KeyValuePair<TKey, TValue>>();
                this.table[hash].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                this.table[hash].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public TValue GetValue(TKey key)
        {
            TValue value = default(TValue);

            int hash = key.GetHashCode() % this.tableSize;

            if (this.table[hash] != null)
            {
                if (this.table[hash].Count == 1)
                {
                    value = this.table[hash].First.Value;
                }
                else
                {
                    foreach (KeyValuePair<TKey, TValue> pair in this.table[hash])
                    {
                        if (pair.Key.Equals(key))
                        {
                            value = pair.Value;
                            break;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("No record found with such key");
            }
        
            return value;
        }

        public void Delete(TKey key)
        {
            int hash = key.GetHashCode() % this.tableSize;

            if (this.table[hash] != null)
            {
                if (this.table[hash].Count == 1)
                {
                    this.table[hash] = null;
                }
                else
                {
                    KeyValuePair<TKey, TValue> deletedPair;

                    foreach (KeyValuePair<TKey, TValue> pair in this.table[hash])
                    {
                        if (pair.Key.Equals(key))
                        {
                            deletedPair = pair;
                            break;
                        }
                    }

                    deletedPair = null;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("No record found with such key");
            }
        }
    }
}

