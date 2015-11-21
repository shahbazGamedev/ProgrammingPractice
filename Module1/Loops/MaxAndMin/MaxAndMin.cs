// Write a program that reads from the console a sequence of N integer
// numbers and returns the minimal and maximal of them.

using System;

class MaxAndMin
{
    static void Main()
    {
        const int N = 10;

        int[] numberArray = new int[N];

        for (int i = 0; i < N; i++)
        {
            numberArray[i] = int.Parse(Console.ReadLine());
        }

        int minimalElement = numberArray[0];
        int maximalElement = numberArray[0];

        for (int i = 0; i < N; i++)
        {
            if (numberArray[i] < minimalElement)
            {
                minimalElement = numberArray[i];
            }

            if (numberArray[i] > maximalElement)
            {
                maximalElement = numberArray[i];
            }
        }

        Console.WriteLine("The MIN and MAX elements in the array are: {0} and {1}", minimalElement, 
            maximalElement);
    }
}

