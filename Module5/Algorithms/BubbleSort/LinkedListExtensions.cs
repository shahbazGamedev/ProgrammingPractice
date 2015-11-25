using System;
using LinkedList;

namespace BubbleSort
{
    public static class LinkedListExtensions
    {
        public static void Sort<T>(this LinkedList<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list.Compare(list[i], list[j]) == -1)
                    {
                        list.Swap(i, j);
                    }
                }
            }
        }
    }
}

