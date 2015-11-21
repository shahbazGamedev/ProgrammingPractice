// Write a program that reads a rectangular matrix of size N x M and finds in it the
// square 3 x 3 that has maximal sum of its elements.

using System;
using System.Linq;

class MaxSum3By3
{
    static void Main()
    {
        Console.WriteLine("Enter number of rows:");
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter number of columns:");
        int M = int.Parse(Console.ReadLine());

        if (N < 3 || M < 3)
        {
            return;
        }

        int[,] matrix = new int[N, M];

        Console.WriteLine("Enter {0} rows with {1} numbers on each (separate with a COMMA):", N, M);

        for (int i = 0; i < N; i++)
        {
            string tmp = Console.ReadLine();

            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = int.Parse(tmp.Split(',').ElementAt(j));
            }
        }

        Console.WriteLine("The maximal sum of 3 x 3 elements is: {0}", MaxSum(matrix));
    }

    public static int MaxSum(int[,] matrix)
    {
        int largestSum = int.MinValue;

        for (int rows = 0; rows < matrix.GetLength(0) - 2; rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1) - 2; cols++)
            {
                int currentSum = 0;

                for (int newRow = rows; newRow < rows + 3; newRow++)
                {
                    for (int newCol = cols; newCol < cols + 3; newCol++)
                    {
                        currentSum += matrix[newRow, newCol];
                    }
                }

                if (largestSum <= currentSum)
                {
                    largestSum = currentSum;
                }
            }
        }
        return largestSum;
    }
}

