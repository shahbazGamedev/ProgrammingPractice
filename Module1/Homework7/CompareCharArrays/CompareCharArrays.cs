// Write a program that compares two char arrays lexicographically (letter by letter).

using System;
using System.Linq;

class CompareCharArrays
{
    static void Main()
    {
        const int arraysLength = 5;

        char[] array1 = new char[arraysLength];
        char[] array2 = new char[arraysLength];

        ReadElementsFromConsole(array1, arraysLength);
        Console.WriteLine();
        ReadElementsFromConsole(array2, arraysLength);

        bool isEqual = true;
        bool arrayOneIsFirst = false;

        for (int i = 0; i < arraysLength; i++)
        {
            if ((int)array1[i] < (int)array2[i])
            {
                arrayOneIsFirst = true;
            }

            if ((int)array1[i] != (int)array2[i])
            {
                isEqual = false;
            }
        }

        if (isEqual)
        {
            Console.WriteLine("\nThe char arrays are equal.");
        }
        else
        {
            if (arrayOneIsFirst)
            {
                Console.WriteLine("\n" + string.Join(", ", array1));
            }
            else
            {
                Console.WriteLine("\n" + string.Join(", ", array2));
            }
        }
    }

    private static void ReadElementsFromConsole(char[] tempArray, int arraysLength)
    {
        Console.WriteLine("Input five letters on a single line (separate with a SPACE):");

        string input = Console.ReadLine();

        for (int i = 0; i < arraysLength; i++)
        {
            tempArray[i] = char.Parse(input.Split(' ').ElementAt(i));
        }
    }
}


