// Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

class FactNFactKPart1
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        if (K < 1 || N < K)
        {
            return;
        }

        long factorialN = 1, factorialK = 1;

        for (int i = 1; i <= N; i++)
        {
            factorialN *= i;
        }

        for (int i = 1; i <= K; i++)
        {
            factorialK *= i;
        }

        Console.WriteLine("\n" + factorialN / factorialK);
    }
}
