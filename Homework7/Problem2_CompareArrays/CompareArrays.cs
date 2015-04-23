// Write a program that reads two arrays from the console and compares them element by element.

using System;
using System.Linq;

class CompareArrays
{
    static void Main()
    {
        const int arraysLength = 5;

        int[] array1 = new int[arraysLength];
        int[] array2 = new int[arraysLength];

        // so there isn't a need to repeat the same code:
        ReadElementsFromConsole(array1, arraysLength);
        Console.WriteLine();
        ReadElementsFromConsole(array2, arraysLength);

        bool isEqual = true;

        for (int i = 0; i < arraysLength; i++)
        {
            if (array1[i] != array2[i])
            {
                isEqual = false;
            }
        }

        if (isEqual)
        {
            Console.WriteLine("\nThe arrays are equal.");
        }
        else
        {
            Console.WriteLine("\nThe arrays are not equal.");
        }
    }

    private static void ReadElementsFromConsole(int[] tempArray, int arraysLength)
    {
        Console.WriteLine("Input five numbers on a single line (separate with a COMMA):");

        string input = Console.ReadLine();

        for (int i = 0; i < arraysLength; i++)
        {
            tempArray[i] = int.Parse(input.Split(',').ElementAt(i));
        }
    }
}
