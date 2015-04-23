// Write an expression that checks if a given positive integer n<=100 is
// prime.

using System;

class IsPrime
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // number

        // stop the program if the number is out of range:
        if (n < 0 || n > 100)
        {
            Console.WriteLine("The number you entered is invalid.");
            return;
        }
        
        bool isPrime = true;

        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
            }
        }
        Console.WriteLine("The given number {0} is prime: {1}", n, isPrime);
    }
}

