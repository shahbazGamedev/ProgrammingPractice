// Write a program that reads a number N and calculates the sum of the
// first N members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21,
// 34, 55, 89, 144, 233, 377, …

using System;
using System.Collections.Generic;

class Fibonacci
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        List<int> fibonacciSequence = new List<int>() { 0, 1 };
        int listIndexCounter = 2;

        while (fibonacciSequence.Count <= N)
        {
            fibonacciSequence.Add(fibonacciSequence[listIndexCounter - 2] + 
                fibonacciSequence[listIndexCounter - 1]);

            listIndexCounter++;
        }

        foreach (var number in fibonacciSequence)
        {
            Console.Write(number + ", ");
        }

        Console.WriteLine("\n");
    }
}

