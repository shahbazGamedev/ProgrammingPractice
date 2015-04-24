// Write a program that finds the maximal sequence of equal elements in an
// array. Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

using System;
using System.Linq;

class MaxSequence
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

        Console.WriteLine();

        int currentSequence = 1;
        int longestSequence = 1;
        int indexOfLongest = new int();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
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

        Console.Write("{0} -> ", longestSequence);
        for (int i = indexOfLongest; i < indexOfLongest + longestSequence; i++)
        {
            Console.Write("[{0}] ", numbers[i]);
        }

        Console.WriteLine();
    }
}