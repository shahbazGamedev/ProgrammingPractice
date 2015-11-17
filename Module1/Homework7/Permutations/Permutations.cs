// Write a program that reads a number N and generates and prints all the
// permutations of the numbers [1 … N]. Example:
// n = 3 -> {1, 2, 3}, {1, 3, 2}, 
//          {2, 1, 3}, {2, 3, 1}, 
//          {3, 1, 2}, {3, 2, 1}

using System;

class Permutations
{
    static void Main()
    {
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            numbers[i] = i + 1;
        }

        Permute(ref numbers, 0, N);
    }

    static void Swap(ref int x, ref int y)
    {
        int tmp = x;
        x = y;
        y = tmp;
    }

    static void Permute(ref int[] numbers, int i, int N)
    {
        if (i == N)
        {
            Console.WriteLine("\n{0}", string.Join(", ", numbers));
        }
        else
        {
            for (int j = i; j < N; j++)
            {
                Swap(ref numbers[i], ref numbers[j]);
                Permute(ref numbers, i + 1, N);
                Swap(ref numbers[i], ref numbers[j]);
            }
        }
    }
}