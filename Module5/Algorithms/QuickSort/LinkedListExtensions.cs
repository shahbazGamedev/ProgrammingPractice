using System;
using LinkedList;

namespace QuickSort
{
    public static class LinkedListExtensions
    {
        public static void Sort<T>(this LinkedList<T> list, int leftMostPosition, int rightMostPosition)
        {
            int i = leftMostPosition;
            int j = rightMostPosition;
            T pivotElement = list[(leftMostPosition + rightMostPosition) / 2];

            int leftMostElement = 0;
            int rightMostElement = list.Count - 1;

            while (i <= j)
            {
                while (list.Compare(list[i], pivotElement) < 0)
                {
                    i++;
                }

                while (list.Compare(list[j], pivotElement) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    list.Swap(i, j);

                    i++;
                    j--;
                }
            }

            if (leftMostElement < i)
            {
                Sort(list, leftMostElement, j);
            }
            else if (rightMostElement < j)
            {
                Sort(list, i, rightMostElement);
            }
        }
    }
}

