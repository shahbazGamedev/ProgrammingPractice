// Write a program that calculates N!*K! / (K-N)! for given N and K
// (1<N<K).

using System;

class FactNFactKPart2
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());

        if (N < 1 || K < N)
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

        long KMinusNFactorial = 1;

        for (int i = 1; i <= (K - N); i++)
        {
            KMinusNFactorial *= i;
        }

        Console.WriteLine("\n" + (factorialN * factorialK) / KMinusNFactorial);
    }
}

