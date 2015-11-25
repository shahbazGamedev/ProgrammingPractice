using System;
using LinkedList;

namespace SelectionSort
{
    public static class LinkedListExtensions
    {
        public static void Sort<T>(this LinkedList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int smallestElementIndex = i;

                for (int j = i; j < list.Count; j++)
                {
                    if (list.Compare(list[smallestElementIndex], list[j]) == -1)
                    {
                        smallestElementIndex = j;
                    }
                }

                list.Swap(i, smallestElementIndex);
            }
        }
    }
}

