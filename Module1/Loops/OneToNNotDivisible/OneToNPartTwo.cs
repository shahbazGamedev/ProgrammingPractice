// Write a program that prints all the numbers from 1 to N, that are not
// divisible by 3 and 7 at the same time.

using System;

class OneToNPartTwo
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine();

        for (int i = 1; i <= N; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.Write(i + ", ");
            }
        }
    }
}

