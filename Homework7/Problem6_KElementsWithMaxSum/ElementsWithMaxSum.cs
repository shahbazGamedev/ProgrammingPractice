// Write a program that reads two integer numbers N and K and an array of
// N elements from the console. Find in the array those K elements that have
// maximal sum.

using System;
using System.Linq;

class ElementsWithMaxSum
{
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        Console.WriteLine("\nInput ten numbers on a single line (separate with a COMMA):");

        string input = Console.ReadLine();

        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input.Split(',').ElementAt(i));
        }

        Console.WriteLine();

        // descending bubble sort:
        int tmp;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] < numbers[j])
                {
                    tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;
                }
            }
        }

        int maximalSum = 0;
        for (int i = 0; i < K; i++)
        {
            maximalSum += numbers[i];
            Console.Write("[{0}] ", numbers[i]);
        }
        Console.WriteLine("\nSum = {0}\n", maximalSum);
    }
}

