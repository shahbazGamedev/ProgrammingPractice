// Write a program, that reads from the console an array of numbers integers and an integer K, 
// sorts the array and using the method Array.BinSearch() 
// finds the largest number in the array which is ≤ K. 

using System;
using System.Linq; // for the array input...

class LargestInArray
{
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        Console.WriteLine("Input {0} numbers on a single line (separate with a COMMA)", N);

        int[] numbers = new int[N];
        string tmp = Console.ReadLine();
        for (int i = 0; i < N; i++)
        {
            numbers[i] = int.Parse(tmp.Split(',').ElementAt(i));
        }

        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());

        Array.Sort(numbers);
        int indexOfK = Array.BinarySearch(numbers, K);

        Console.WriteLine();

        if (K < numbers[0])
        {
            Console.WriteLine("No such number in the array!");
        }
        else
        {
            if (indexOfK >= 0 && indexOfK < numbers.Length)
            {
                Console.WriteLine(numbers[indexOfK]);
            }
            else if (Math.Abs(indexOfK) > numbers[numbers.Length - 1])
            {
                Console.WriteLine(numbers[numbers.Length - 1]);
            }
        }
    }
}
