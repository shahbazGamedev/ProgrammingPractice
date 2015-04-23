// Write a program that finds the maximal increasing sequence in an array.
// Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;
using System.Linq;

class MaxIncreasingSeq
{
    static void Main()
    {
        Console.WriteLine("Input ten numbers on a single line (separate with a COMMA)");

        string input = Console.ReadLine();

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input.Split(',').ElementAt(i));
        }

        Console.WriteLine();

        int currentSequence = 1;
        int longestSequence = 1;
        int indexOfLongest = new int();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] + 1 == numbers[i + 1]) // the only difference    
            {
                currentSequence++;
            }
            else
            {
                if (longestSequence < currentSequence)
                {
                    longestSequence = currentSequence;
                    indexOfLongest = i - currentSequence + 1;
                }
                currentSequence = 1;
            }
        }

        for (int i = indexOfLongest; i < indexOfLongest + longestSequence; i++)
        {
            Console.Write("[{0}] ", numbers[i]);
        }

        Console.WriteLine();
    }
}

