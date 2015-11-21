/*
    Print:
 
    1   8    9  16
    2   7   10  15
    3   6   11  14
    4   5   12  13
*/

using System;

class PrintMatrix
{
    static void Main()
    {
        int[,] matrix = new int[4, 4];

        int currentNumber = 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, i] = currentNumber;
                    currentNumber++;
                }
            }
            else
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[j, i] = currentNumber;
                    currentNumber++;
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, 4}", matrix[i, j]);
            }
            Console.WriteLine("\n\n");
        }
    }
}

