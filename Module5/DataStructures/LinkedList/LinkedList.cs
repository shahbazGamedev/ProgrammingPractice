using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : ILinkedList<T>, IEnumerable<T>, IComparer<T>
    {
        public int Count { get; private set; }

        public T First
        {
            get
            {
                if (this.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("List is empty");
                }

                return this.first.Value;
            }
        }

        public T Last
        {
            get
            {
                if (this.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("List is empty");
                }

                return this.last.Value;
            }
        }

        private Element<T> first;
        private Element<T> last;

        public class Element<T> : IComparable<Element<T>>
        {
            public Element(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Element<T> Previous { get; set; }

            public Element<T> Next { get; set; }

            public int CompareTo(Element<T> other)
            {
                int result;

                if (this.Value.Equals(other.Value))
                {
                    result = 0;
                }
                else
                {
                    IComparable comparator = (IComparable)this.Value;
                    if (comparator != null)
                    {
                        result = comparator.CompareTo(other.Value) < 0 ? 1 : -1;
                    }
                    else
                    {
                        throw new InvalidCastException("Could not compare the elements properly");
                    }
                }
            
                return result;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Element<T> element = this.first;

            while (element != null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Compare(T first, T second)
        {
            Element<T> firstElement = new Element<T>(first);
            Element<T> secondElement = new Element<T>(second);

            return firstElement.CompareTo(secondElement);
        }

        public void AddFirst(T value)
        {
            Element<T> element = new Element<T>(value);

            if (this.first == null)
            {
                this.first = element;
                this.last = element;
            }
            else
            {
                this.first.Previous = element;
                element.Next = this.first;
                this.first = element;
            }

            this.Count++;
        }

        public void AddLast(T value)
        {
            Element<T> element = new Element<T>(value);

            if (this.first == null)
            {
                this.first = element;
                this.last = element;
            }
            else
            {
                this.last.Next = element;
                element.Previous = this.last;
                this.last = element;
            }

            this.Count++;
        }

        public void AddAfter(T afterValue, T value)
        {
            if (!this.Contains(afterValue))
            {
                throw new ArgumentOutOfRangeException("The value specified does not exist in the list");
            }

            Element<T> requiredElement = (Element<T>)this.ElementAt(this.IndexOf(afterValue));

            Element<T> insertionElement = new Element<T>(value);

            if (requiredElement.Next != null)
            {
                insertionElement.Next = requiredElement.Next;
                insertionElement.Previous = requiredElement;

                requiredElement.Next.Previous = insertionElement;
                requiredElement.Next = insertionElement;

                this.Count++;
            }
            else
            {
                this.AddLast(value);
            }
        }

        public void AddBefore(T beforeValue, T value)
        {
            if (!this.Contains(beforeValue))
            {
                throw new ArgumentOutOfRangeException("The value specified does not exist in the list");
            }

            Element<T> requiredElement = (Element<T>)this.ElementAt(this.IndexOf(beforeValue));

            Element<T> insertionElement = new Element<T>(value);

            if (requiredElement.Previous != null)
            {
                insertionElement.Next = requiredElement;
                insertionElement.Previous = requiredElement.Previous;

                requiredElement.Previous.Next = insertionElement;
                requiredElement.Previous = insertionElement;

                this.Count++;
            }
            else
            {
                this.AddFirst(value);
            }
        }

        public void InsertAt(int index, T value)
        {
            Element<T> insertionElement = new Element<T>(value);

            Element<T> previous = null;
            if (index + 1 < this.Count)
            {
                previous = (Element<T>)this.ElementAt(index + 1);
                previous.Next = insertionElement;
            }

            Element<T> next = null;
            if (index >= 0)
            {
                next = (Element<T>)this.ElementAt(index - 1);
                next.Previous = insertionElement;
            }

            insertionElement.Next = next;
            insertionElement.Previous = previous;

            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("List is empty");
            }

            Element<T> removedElement = (Element<T>)this.ElementAt(index);

            if (removedElement.Previous != null)
            {
                removedElement.Previous.Next = removedElement.Next;
            }
            else
            {
                this.first = removedElement.Next;
            }

            if (removedElement.Next != null)
            {
                removedElement.Next.Previous = removedElement.Previous;
            }
            else
            {
                this.last = removedElement.Previous;
            }

            this.Count--;
        }

        public int IndexOf(T value)
        {
            int index = 0;

            bool elementFound = false;
            foreach (T element in this)
            {
                if (element.Equals(value))
                {
                    elementFound = true;
                    break;
                }	

                index++;
            }

            if (!elementFound)
            {
                index = -1;
            }

            return index;
        }

        public T this [int index]
        {
            get
            {
                Element<T> element = (Element<T>)this.ElementAt(index);
                return element.Value;
            }
            set
            {
                Element<T> element = (Element<T>)this.ElementAt(index);
                element.Value = value;
            }
        }

        public bool Contains(T value)
        {
            bool contains = false;

            if (this.IndexOf(value) != -1)
            {
                contains = true;
            }

            return contains;
        }

        public void Clear()
        {
            this.first = null;
            this.last = null;
            this.Count = 0;
        }

        public void Swap(int first, int second)
        {
            T temp = this[first];
            this[first] = this[second];
            this[second] = temp;
        }

        private object ElementAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            Element<T> element = this.first;

            int Counter = 0;
            while (true)
            {
                if (element.Next == null || Counter == index)
                {
                    break;
                }

                Counter++;
                element = element.Next;
            }

            return element;
        }

    }
}

