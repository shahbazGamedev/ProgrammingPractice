// Write a program that reads two numbers N and K and generates all the
// variations of K elements from the set [1..N]. Example:
// N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3} 
//                 {2, 1}, {2, 2}, {2, 3}
//                 {3, 1}, {3, 2}, {3, 3}

using System;

class Variations
{
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());
        int[] numbers = new int[K];

        Console.WriteLine();

        Variate(numbers, 0, N);
    }

    private static void Variate(int[] numbers, int index, int N)
    {
        if (numbers.Length == index)
        {
            PrintNumbers(numbers);
        }
        else
        {
            for (int i = 1; i <= N; i++)
            {
                numbers[index] = i;

                Variate(numbers, index + 1, N);
            }
        }
    }

    private static void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
    }
}

