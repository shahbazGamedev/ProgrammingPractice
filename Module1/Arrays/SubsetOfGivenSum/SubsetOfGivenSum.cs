// We are given an array of integers and a number S. Write a program to
// find if there exists a subset of the elements of the array that has a sum S.
// Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

using System;
using System.Linq;

class SubsetOfGivenSum
{
    static void Main()
    {
        Console.Write("S = ");
        int S = int.Parse(Console.ReadLine());

        Console.WriteLine("Input number of elements:");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] numbers = new int[numberOfElements];

        Console.WriteLine("Input {0} numbers on a single line (seperate with a COMMA)", numberOfElements);

        string tmp = Console.ReadLine();
        for (int i = 0; i < numberOfElements; i++)
        {
            numbers[i] = int.Parse(tmp.Split(',').ElementAt(i));
        }

        string subset;
        int maxSubsets = (int)Math.Pow(2, numberOfElements);

        for (int i = 1; i < maxSubsets; i++)
        {
            int tmpSum = 0;
            subset = "";
            
            for (int j = 0; j <= numberOfElements; j++)
            {
                int mask = 1 << j;
                int valueAndMask = i & mask;
                int bit = valueAndMask >> j;

                if (bit == 1)
                {
                    tmpSum += numbers[j];
                    if (subset == "")
                    {
                        subset += numbers[j];    
                    }
                    else
                    {
                        subset += " + " + numbers[j];
                    }
                }
            }

            if (tmpSum == S)
            {
                Console.WriteLine("\n{0} = {1}", S, subset);
            }
        }
    }
}
