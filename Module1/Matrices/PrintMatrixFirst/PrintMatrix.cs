/*
    Print:
 
    1   5    9  13
    2   6   10  14
    3   7   11  15
    4   8   12  16
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
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[j, i] = currentNumber;
                currentNumber++;
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

