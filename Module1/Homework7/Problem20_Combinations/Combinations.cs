// Write a program that reads two numbers N and K and generates all the
// combinations of K distinct elements from the set [1..N]. Example:
// N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, 
//                 {2, 3}, {2, 4}, {2, 5}, 
//                 {3, 4}, {3, 5}, 
//                 {4, 5}

using System;

class Combinations
{
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            numbers[i] = i + 1;
        }

        Console.WriteLine();

        string subset;
        int lenCounter = 0;
        int maxSubsets = (int)Math.Pow(2, N);
        
        for (int i = 1; i < maxSubsets; i++)
        {
            subset = "";

            for (int j = 0; j <= N; j++)
            {
                int mask = 1 << j;
                int valueAndMask = i & mask;
                int bit = valueAndMask >> j;

                if (bit == 1)
                {
                    subset += numbers[j] + " ";
                    lenCounter++;
                }
            }

            if (lenCounter == K)
            {
                Console.WriteLine(subset + "\n");
            }

            lenCounter = 0;
        }
    }
}