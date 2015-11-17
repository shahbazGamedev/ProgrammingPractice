// Write a program that prints all the numbers from 1 to N.

using System;

class OneToN
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        
        Console.WriteLine();
        
        for (int i = 1; i <= N; i++)
        {
            Console.Write(i + ", ");
        }
    }
}

