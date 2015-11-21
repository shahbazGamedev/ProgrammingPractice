// Write a program that finds in given array of integers a sequence of given sum
// S (if present). Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

using System;
using System.Linq;

class SequenceOfGivenSum
{
    static void Main()
    {
        Console.WriteLine("Input ten numbers on a single line (separate with a comma):");

        string input = Console.ReadLine();

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input.Split(',').ElementAt(i));
        }

        Console.Write("\nS = ");
        int S = int.Parse(Console.ReadLine());

        Console.WriteLine();

        int generatedSum = 0;
        int startingIndexOfSequence = new int();
        int lastIndexOfSequence = new int();
        bool doesSumExist = true;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            startingIndexOfSequence = i;
            generatedSum += numbers[i];

            for (int j = i + 1; j < numbers.Length; j++)
            {
                generatedSum += numbers[j];
                if (generatedSum == S)
                {
                    lastIndexOfSequence = j;
                    break;
                }
            }

            if (generatedSum == S) // exit the first for loop
            {
                doesSumExist = true;
                break;
            }
            else
            {
                doesSumExist = false;
                generatedSum = 0;
            }
        }

        if (!doesSumExist)
        {
            Console.WriteLine("No such sum exists!");
        }
        else
        {
            for (int i = startingIndexOfSequence; i <= lastIndexOfSequence; i++)
            {
                Console.Write("[{0}] ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}

