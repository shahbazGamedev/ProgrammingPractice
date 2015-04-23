// Sorting an array means to arrange its elements in increasing order. Write a
// program to sort an array. Use the "selection sort" algorithm.

using System;
using System.Linq;

class SelectionSort
{
    static void Main()
    {
        Console.WriteLine("Input ten numbers on a single line (separate with a COMMA):");

        string input = Console.ReadLine();

        int[] numbers = new int[10];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input.Split(',').ElementAt(i));
        }
        
        for (int i = 0; i < numbers.Length; i++)
        {
            int indexOfMin = i;

            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[indexOfMin] > numbers[j])
                {
                    indexOfMin = j;
                }
            }
            int tmp = numbers[i];
            numbers[i] = numbers[indexOfMin];
            numbers[indexOfMin] = tmp;
        }
        Console.WriteLine("\n{0}", string.Join(", ", numbers));
    }
}
