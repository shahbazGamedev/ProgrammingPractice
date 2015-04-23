// Write a program that reads three integer numbers N, K and S and an array
// of N elements from the console. Find in the array a subset of K elements that
// have sum S or indicate about its absence.

using System;
using System.Linq;

class NKS
{
    static void Main()
    {

        Console.Write("S = ");
        int S = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        Console.WriteLine("Input {0} numbers on a single line (seperate with a COMMA)", N);

        string tmp = Console.ReadLine();
        for (int i = 0; i < N; i++)
        {
            numbers[i] = int.Parse(tmp.Split(',').ElementAt(i));
        }

        string subset;
        int maxSubsets = (int)Math.Pow(2, N);

        for (int i = 1; i < maxSubsets; i++)
        {
            subset = "";
            int tmpSum = 0;
            int lenCounter = 0;
            
            for (int j = 0; j <= N; j++)
            {
                int mask = 1 << j;
                int valueNAndMask = i & mask;
                int bit = valueNAndMask >> j;

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
                    lenCounter++;
                }
            }

            if (tmpSum == S && lenCounter == K)
            {
                Console.WriteLine("{0} = {1}", S, subset);
            }
        }
    }
}

