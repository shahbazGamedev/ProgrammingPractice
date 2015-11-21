using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
	public class LinkedList<T> : IEnumerable<T>
	{
		public int Count { get; private	set; }

		private Element<T> First { get; set; } 
		private Element<T> Last { get; set; } 

		public IEnumerator<T> GetEnumerator ()
		{
			Element<T> element = this.First;

			while (element != null)
			{
				yield return element.Value;
				element = element.Next;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator();
		}

		public void AddFirst(T value)
		{
			Element<T> element = new Element<T> (value);

			if (this.First == null)
			{
				this.First = element;
				this.Last = element;
			}
			else
			{
				this.First.Previous = element;
				element.Next = this.First;
				this.First = element;
			}

			this.Count++;
		}

		public void AddLast(T value)
		{
			Element<T> element = new Element<T> (value);

			if (this.First == null)
			{
				this.First = element;
				this.Last = element;
			}
			else
			{
				this.Last.Next = element;
				element.Previous = this.Last;
				this.Last = element;
			}

			this.Count++;
		}

		public void AddAfter(T afterValue, T value)
		{
			if (!this.Contains(afterValue))
			{
				throw new ArgumentOutOfRangeException ("The value specified does not exist in the list");
			}

			Element<T> requiredElement = this.ElementAt(this.IndexOf(afterValue));

			Element<T> insertionElement = new Element<T> (value);

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
				this.AddLast (value);
			}
		}

		public void AddBefore(T beforeValue, T value)
		{
			if (!this.Contains(beforeValue))
			{
				throw new ArgumentOutOfRangeException ("The value specified does not exist in the list");
			}

			Element<T> requiredElement = this.ElementAt(this.IndexOf(beforeValue));

			Element<T> insertionElement = new Element<T> (value);

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
				this.AddFirst (value);
			}
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
			this.First = null;
			this.Last = null;
			this.Count = 0;
		}

		private class Element<G>
		{
			public Element (T value)
			{
				this.Value = value;
			}

			public T Value { get; set; }
			public Element<G> Previous { get; set; }
			public Element<G> Next { get; set; }
		}

		private Element<T> ElementAt(int index)
		{
			if (index < 0 || index >= this.Count) 
			{
				throw new ArgumentOutOfRangeException ("Invalid index");
			}

			Element<T> element = this.First;

			int counter = 0;
			while (true)
			{
				if (element.Next == null || counter == index)
				{
					break;
				}

				counter++;
				element = element.Next;
			}

			return element;
		}
	}
}

