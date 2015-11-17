namespace CustomGenericList.Libraries
{
    using System;
    using System.Text;
    
    public class CustomList<T>
    {
        private const int InitialCapacity = 4;

        private T[] items;
        private int capacity;

        public CustomList()
        {
            this.Capacity = InitialCapacity;
            this.Count = 0;
            this.items = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity 
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value % 2 != 0 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect value for the list capacity");
                }
                this.capacity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index must be higher than or equal to zero " +
                    "and less than the collection's count.");
                }
                this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                T[] temp = new T[this.Capacity];
                this.items.CopyTo(temp, 0);
                this.Capacity *= 2;
                this.items = new T[this.Capacity];
                temp.CopyTo(items, 0);

                this.items[this.Count] = item;
                this.Count++;
            }
            else
            {
                this.items[this.Count] = item;
                this.Count++;
            }
        }

        public void InsertAt(int position, T item)
        {
            if (position < 0 || position > this.Count)
            {
                throw new ArgumentOutOfRangeException("Position must be higher than or equal to zero " +
                "and less than the collection's count.");
            }

            if (position == this.Count)
            {
                this.Add(item);
            }
            else
            {
                T[] temp = new T[this.Capacity];
                int counter = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    if (i == position)
                    {
                        temp[i] = item;
                        counter++;

                        temp[counter] = items[i];
                        counter++;
                        continue;
                    }
                    temp[counter] = items[i];
                    counter++;
                }

                this.Count = counter;
                temp.CopyTo(items, 0);
            }
        }

        public bool Find(T value)
        {
            bool found = false;

            foreach (T item in items)
            {
                if (item.Equals(value))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
        
        public void RemoveAt(int position)
        {
            if (position < 0 || position >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Position must be higher than or equal to zero " +
                "and less than the collection's count.");
            }

            T[] temp = new T[this.Capacity];
            int counter = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (i == position)
                {
                    continue;
                }
                temp[counter] = items[i];
                counter++;
            }

            this.Count = counter;
            temp.CopyTo(items, 0);
        }

        public void Clear()
        {
            this.Count = 0;
            items = new T[this.capacity];
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.Append(items[i] + " ");
            }

            return result.ToString();
        }
    }
}
