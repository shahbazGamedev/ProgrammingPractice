// Write a program that sorts an array of strings using the quick sort algorithm.

using System;
using System.Linq;

class QuickSort
{
    static void Main()
    {
        string[] input = { "a", "b", "c", "d", "e", "f" };

        Console.WriteLine("Unsorted: {0}\n", string.Join(", ", input));

        QuickSorting(input, 0, input.Length - 1);

        Console.WriteLine("Sorted: {0}\n", string.Join(", ", input));
    }

    private static void QuickSorting(IComparable[] array, int leftMostPosition, int rightMostPosition)
    {
        int i = leftMostPosition;
        int j = rightMostPosition;
        IComparable pivotElement = array[(leftMostPosition + rightMostPosition) / 2];

        int leftMostElement = 0;
        int rightMostElement = array.Length - 1;

        while (i <= j)
        {
            while (array[i].CompareTo(pivotElement) < 0)
            {
                i++;
            }

            while (array[j].CompareTo(pivotElement) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                IComparable tmp = array[i];
                array[i] = array[j];
                array[j] = tmp;

                i++;
                j--;
            }
        }

        if (leftMostElement < i)
        {
            QuickSorting(array, leftMostElement, j);
        }
        else if (rightMostElement < j)
        {
            QuickSorting(array, i, rightMostElement);
        }
    }
}


