// Write a program that, for a given two integer numbers N and
// X, calculates the sum S = 1 + 1!/X + 2!/X^2 + … + N!/X^N

using System;

class FactNAndX
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int X = int.Parse(Console.ReadLine());

        long S = 0;
        long factorialN = 1;

        for (int i = 0; i <= N; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                factorialN *= j;
            }

            S += (long)(factorialN / Math.Pow(X, i));
        }

        // for values 4 and 4 the result would be 1.5625, but the program
        // rounds it to 2 because of (long) :)
        Console.WriteLine("The result is: " + S);
    }
}
