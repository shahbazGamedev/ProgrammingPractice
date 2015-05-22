/*
    Print:
 
    7  11   14  16  
    4   8   12  15
    2   5    9  13
    1   3    6  10
*/

using System;

class PrintMatrix
{
    public static void Main()
    {
        const int SIZE = 4;
        int[,] matrix = new int[SIZE, SIZE];
        int counter = 1;
        int counterTwo = (int)Math.Pow(SIZE, 2);
        int up = 0;

        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            int currentRow = row;
            int currentCol = 0;

            matrix[currentRow, currentCol] = counter;
            counter++;

            while (true)
            {
                currentRow += 1;
                currentCol += 1;
                if (currentCol < 0 || currentRow < 0 || currentCol > SIZE - 1 || currentRow > SIZE - 1)
                {
                    break;
                }

                matrix[currentRow, currentCol] = counter;
                counter++;
            }

            currentRow = up;
            currentCol = SIZE - 1;

            if (currentCol > 0)
            {
                matrix[currentRow, currentCol] = counterTwo;
                counterTwo--;

                while (true)
                {
                    currentRow -= 1;
                    currentCol -= 1;

                    if (currentCol < 0 || currentRow < 0 || currentCol > SIZE - 1 || currentRow > SIZE - 1)
                    {
                        break;
                    }

                    matrix[currentRow, currentCol] = counterTwo;
                    counterTwo--;
                }
            }
            up++;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine("\n\n");
        }
    }
}

