using System;
using LinkedList;

namespace Tree
{
    public class Test
    {
        public static void Main()
        {
            Tree<int> tree =
                new Tree<int>(1,
                    new Tree<int>(2,
                        new Tree<int>(5),
                        new Tree<int>(6)),
                    new Tree<int>(3),
                    new Tree<int>(4,
                        new Tree<int>(7),
                        new Tree<int>(8),
                        new Tree<int>(9)));

            LinkedList<int> bfs = tree.BreadthFirstSearch();
            foreach (int element in bfs)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();

            LinkedList<int> dfs = tree.DepthFirstSearch();
            foreach (int element in dfs)
            {
                Console.WriteLine(element);
            }
        }
    }
}

