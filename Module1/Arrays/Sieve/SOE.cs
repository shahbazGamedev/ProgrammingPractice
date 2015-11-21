// Write a program that finds all prime numbers in the range [1...10 000 000].

using System;
using System.Collections.Generic;

class SOE
{
    static void Main()
    {
        Console.Write("Input number: ");

        int N = int.Parse(Console.ReadLine());
        int squareOfN = (int)Math.Sqrt(N);

        bool[] isNotPrime = new bool[N + 1];

        for (int i = 2; i < squareOfN; i++)
        {
            if (!isNotPrime[i])
            {
                Console.WriteLine(i);
            }

            for (int j = i*i; j < N; j += i)
            {
                isNotPrime[j] = true;
            }
        }

        for (int i = squareOfN; i < N; i++)
        {
            if (!isNotPrime[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}
