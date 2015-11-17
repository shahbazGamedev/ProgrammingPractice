// Write a program that reads an integer number n from the console and
// prints all the numbers in the interval [1..n], each on a single line.

using System;

class PrintOneToN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // number

        Console.WriteLine();

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

