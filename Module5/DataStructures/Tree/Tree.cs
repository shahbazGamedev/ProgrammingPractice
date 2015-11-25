using System;
using LinkedList;
using Queue;
using Stack;

namespace Tree
{
    public class Tree<T> : ITree<T>
    {
        public Tree(Vertex<T> root)
        {
            this.Root = root;
        }

        public Tree(T value)
        {
            this.Root = new Vertex<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.Root.AddChild(child.Root);
            }
        }

        public Vertex<T> Root { get; private set; }

        #region Vertex

        public class Vertex<T>
        {
            public Vertex(T value)
            {
                this.Value = value;
                this.Children = new LinkedList<Vertex<T>>();
            }

            public T Value { get; set; }

            public LinkedList<Vertex<T>> Children { get; set; }

            private bool hasParent;

            public int ChildrenCount()
            {
                return this.Children.Count;
            }

            public void AddChild(Vertex<T> vertex)
            {
                if (vertex.hasParent)
                {
                    throw new ArgumentException("The vertex already has a parent");
                }

                vertex.hasParent = true;
                this.Children.AddLast(vertex);
            }

            public Vertex<T> GetChild(int index)
            {
                return this.Children[index];
            }
        }

        #endregion

        public LinkedList<T> BreadthFirstSearch()
        {
            LinkedList<T> orderedElements = new LinkedList<T>();

            Queue<Vertex<T>> elements = new Queue<Vertex<T>>();

            elements.Enqueue(this.Root);

            while (elements.Count() != 0)
            {
                Vertex<T> currentElement = (Vertex<T>)elements.Peek();
                orderedElements.AddLast(currentElement.Value);
                elements.Dequeue();

                foreach (var child in currentElement.Children)
                {
                    elements.Enqueue(child);
                }
            }

            return orderedElements;
        }

        public LinkedList<T> DepthFirstSearch()
        {
            LinkedList<T> orderedElements = new LinkedList<T>();

            Stack<Vertex<T>> elements = new Stack<Vertex<T>>();

            elements.Push(this.Root);

            while (elements.Count() != 0)
            {
                Vertex<T> currentElement = (Vertex<T>)elements.Peek();
                orderedElements.AddLast(currentElement.Value);
                elements.Pop();

                foreach (var child in currentElement.Children)
                {
                    elements.Push(child);
                }
            }

            return orderedElements;
        }
    }
}

