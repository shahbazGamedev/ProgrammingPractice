using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
	public class LinkedList<T> : ILinkedList<T>, IEnumerable<T>
	{
		public int Count { get; private	set; }

		private Element<T> first;
		private Element<T> last;

		public class Element<G>
		{
			public Element(T value)
			{
				this.Value = value;
			}

			public T Value { get; set; }

			public Element<G> Previous { get; set; }

			public Element<G> Next { get; set; }
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

		public void RemoveAt(int index)
		{
			if (this.Count == 0)
			{
				throw new ArgumentOutOfRangeException("Stack is empty");
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

		public object ElementAt(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new ArgumentOutOfRangeException("Invalid index");
			}
			
			Element<T> element = this.first;
			
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

		public T First()
		{
			if (this.Count == 0)
			{
				throw new ArgumentOutOfRangeException("Stack is empty");
			}

			return this.first.Value;
		}

		public T Last()
		{
			if (this.Count == 0)
			{
				throw new ArgumentOutOfRangeException("Stack is empty");
			}

			return this.last.Value;
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
	}
}

