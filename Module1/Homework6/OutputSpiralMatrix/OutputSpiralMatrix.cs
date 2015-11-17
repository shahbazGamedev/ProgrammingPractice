// Write a program that reads a positive integer number N (N < 20)
// from console and outputs in the console the numbers 1 ... N numbers
// arranged as a spiral.

using System;

class OutputSpiralMatrix
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        if (N >= 20 || N <= 0)
        {
            return;
        }

        int counter = 1; //  value to fill each cell with

        int[,] spiralMatrix = new int[N, N];

        int i, j; // for the for-loops

        // vars for storing information about the current element's position
        // they represent the four edges of the matrix:
        int topMostPosition = 0; // starts at top-left
        int bottomMostPosition = N - 1; // starts at bottom-left
        int leftMostPosition = 0; // also starts at bottom-left
        int rightMostPosition = N - 1; // starts at bottom-right

        // shows the current direction of element insertion
        // right -> 0; down -> 1; left -> 2 and up -> 3 :
        int insertDirection = 0;

        // when the loop gets to the last element(the middle one), break:
        while (topMostPosition <= bottomMostPosition && leftMostPosition <= rightMostPosition)
        {
            switch (insertDirection)
            {
                case 0:
                    for (i = leftMostPosition; i <= rightMostPosition; i++)
                    {
                        spiralMatrix[topMostPosition, i] = counter;
                        counter++;
                    }
                    topMostPosition++;
                    break;
                case 1:
                    for (i = topMostPosition; i <= bottomMostPosition; i++)
                    {
                        spiralMatrix[i, rightMostPosition] = counter;
                        counter++;
                    }
                    rightMostPosition--;
                    break;
                case 2:
                    for (i = rightMostPosition; i >= leftMostPosition; i--)
                    {
                        spiralMatrix[bottomMostPosition, i] = counter;
                        counter++;
                    }
                    bottomMostPosition--;
                    break;
                case 3:
                    for (i = bottomMostPosition; i >= topMostPosition; i--)
                    {
                        spiralMatrix[i, leftMostPosition] = counter;
                        counter++;
                    }
                    leftMostPosition++;
                    break;
            }
            // the insert direction gets new value each time the loop does an iteration
            // it resets back to zero after the third iteration(up)
            // this is better than just saying insertDirection = 0 to 3 in each case(code gets longer):
            insertDirection = (insertDirection + 1) % 4;
        }

        // print on the console:
        for (i = 0; i < N; i++)
        {
            Console.WriteLine("\n");
            for (j = 0; j < N; j++)
            {
                // for prettier formatting:
                if (spiralMatrix[i, j] < 10)
                {
                    Console.Write(spiralMatrix[i, j] + "   ");
                }
                else
                {
                    Console.Write(spiralMatrix[i, j] + "  ");
                }
            }
        }
        Console.WriteLine("\n");
    }
}

