// Write a program that reads two positive integer numbers and prints
// how many numbers p exist between them such that the reminder of the
// division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class DivisionByFive
{
    static void Main()
    {
        int p = 0; // how many numbers can be divided by 5
        int firstNumber = Math.Abs(int.Parse(Console.ReadLine()));
        int secondNumber = Math.Abs(int.Parse(Console.ReadLine()));

        for (int i = firstNumber; i <= secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }    
        }

        Console.WriteLine(p);
    }
}

