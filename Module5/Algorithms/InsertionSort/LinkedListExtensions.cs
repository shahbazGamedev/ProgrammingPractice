using System;
using LinkedList;

namespace InsertionSort
{
    public static class LinkedListExtensions
    {
        public static void Sort<T>(this LinkedList<T> list)
        {
            int i;
            int j;
            T value;

            for (i = 1; i < list.Count; i++)
            {
                value = list[i];
                j = i - 1;

                while ((j >= 0) && (list.Compare(list[j], value) == -1))
                {
                    list[j + 1] = list[j];
                    j -= 1;
                }

                list[j + 1] = value;
            }
        }
    }
}

