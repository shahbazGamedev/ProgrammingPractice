// Write a program that finds the sequence of maximal sum in given array.
// Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}

using System;
using System.Text;
using System.Linq;

class MaxSumSeq
{
    static void Main()
    {
        Console.WriteLine("Input number of elements:");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] numbers = new int[numberOfElements];

        Console.WriteLine("Input {0} numbers on a single line (seperate with a COMMA):", numberOfElements);

        string tmp = Console.ReadLine();
        for (int i = 0; i < numberOfElements; i++)
        {
            numbers[i] = int.Parse(tmp.Split(',').ElementAt(i));
        }

        int currentSum = 0;
        int largestSum = 0;
        StringBuilder largestSequenceBuild = new StringBuilder();
        string largestSequence = "";

        for (int i = 0; i < numbers.Length; i++)
        {
            currentSum += numbers[i];

            largestSequenceBuild.Append(" " + numbers[i]);
            
            if (currentSum > largestSum)
            {
                largestSum = currentSum;
                largestSequence = largestSequenceBuild.ToString();
            }

            if (currentSum < 0)
            {
                currentSum = 0;
                largestSequenceBuild.Clear();
            }
        }

        Console.WriteLine("\nThe largest sequence is: {0}", largestSequence);
        Console.WriteLine("The sum is: {0} ", largestSum);
    }
}

