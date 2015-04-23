// Write a program that gets a number n and after that gets more n
// numbers and calculates and prints their sum.

using System;

class GetNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // number
        
        Console.WriteLine();

        int anotherNumber;
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            anotherNumber = int.Parse(Console.ReadLine());
            sum += anotherNumber;
        }

        Console.WriteLine("The sum of all numbers is: {0}", sum);
    }
}

