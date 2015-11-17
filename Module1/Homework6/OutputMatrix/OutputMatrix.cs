// Write a program that reads from the console a positive integer number
// N (N < 20) and outputs a matrix like the following: ...

using System;

class OutputMatrix
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        if (N >= 20 || N <= 0)
        {
            return;
        }

        for (int row = 0; row < N; row++)
        {
            Console.WriteLine("\n");
            for (int col = (row + 1); col <= (N + row); col++)
            {
                // for prettier formatting :) =>
                if (col < 10)
                {
                    Console.Write(" {0}  ", col);
                }
                else
                {
                    Console.Write(" {0} ", col);
                }
            }
        }
        Console.WriteLine("\n");
    }
}

