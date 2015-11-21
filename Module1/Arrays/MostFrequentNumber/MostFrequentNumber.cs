// Write a program that finds the most frequent number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;
using System.Linq;

class MostFrequentNumber
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

        int matchCounter = 1;
        int largestMatchFound = 1;
        int currentNumHolder;
        int largestMatchNumHolder = new int();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            currentNumHolder = numbers[i];

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    matchCounter++;
                }
            }

            if (matchCounter >= largestMatchFound)
            {
                largestMatchFound = matchCounter;
                largestMatchNumHolder = currentNumHolder;
            }

            matchCounter = 1;
        }

        if (largestMatchFound == 1)
        {
            Console.WriteLine("\n{0} (1 time)", numbers[0]);
        }
        else
        {
            Console.WriteLine("\n{0} ({1} times)", largestMatchNumHolder, largestMatchFound);
        }
    }
}

