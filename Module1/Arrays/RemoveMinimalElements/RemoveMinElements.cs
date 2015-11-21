// Write a program that reads an array of integers and removes from it a
// minimal number of elements in such way that the remaining array is sorted in
// increasing order. Print the remaining sorted array. 
// Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;
using System.Linq;

class RemoveMinElements
{
    static void Main()
    {
        Console.WriteLine("Input 10 numbers on a single line (separate with a COMMA):");

        string tmp = Console.ReadLine();

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(tmp.Split(',').ElementAt(i));
        }

        int len = 0;
        int bestLen = 0;
        List<int> bestResult = new List<int>();
        int maxSubsets = (int)Math.Pow(2, numbers.Length);

        for (int i = 1; i < maxSubsets; i++)
        {
            List<int> result = new List<int>();

            for (int j = 0; j <= numbers.Length; j++)
            {
                int mask = 1 << j;
                int valueAndMask = i & mask;
                int bit = valueAndMask >> j;
                if (bit == 1)
                {
                    result.Add(numbers[j]);
                    len++;
                }
            }

            if (IsListSorted(result))
            {
                if (len > bestLen)
                {
                    bestLen = len;
                    bestResult = result;
                }
            }
            len = 0;
        }

        foreach (int number in bestResult)
        {
            Console.Write("{0}, ", number);
        }

        Console.WriteLine();
    }

    private static bool IsListSorted(List<int> numbers)
    {
        bool isSorted = true;
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (!(numbers[i] <= numbers[i + 1]))
            {
                isSorted = false;
            }
        }
        return isSorted;
    }
}

