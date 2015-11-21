// Write a program that finds the index of given element in a sorted array of
// integers by using the binary search algorithm.

using System;
using System.Linq;

class BinSearch
{
    static void Main()
    {
        Console.WriteLine("Input ten numbers on a single line (separate with a COMMA):");

        string input = Console.ReadLine();

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input.Split(',').ElementAt(i));
        }

        int tmp;

        // ascending selection sort:
        for (int i = 0; i < numbers.Length; i++)
        {
            int indexOfMin = i;

            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[indexOfMin] > numbers[j])
                {
                    indexOfMin = j;
                }
            }
            tmp = numbers[i];
            numbers[i] = numbers[indexOfMin];
            numbers[indexOfMin] = tmp;
        }

        Console.Write("\nn = ");
        int n = int.Parse(Console.ReadLine()); // given number

        // binary search:
        int lowestIndex = 0;
        int highestIndex = numbers.Length;
        while (lowestIndex + 1 < highestIndex)
        {
            tmp = (lowestIndex + highestIndex) / 2; // the middle

            if (numbers[tmp] > n)
            {
                highestIndex = tmp;
            }
            else
            {
                lowestIndex = tmp;
            }
        }
        if (numbers[lowestIndex] == n)
        {
            Console.WriteLine("\nThe index of the number is {0}.\n", lowestIndex - 1);
        }
        else
        {
            Console.WriteLine("\nThere is no such number in the array.\n");
        }
    }
}

