// Write a boolean expression that checks if an integer can be divided by
// 2, 3 and 5 without remainder (use logical operators).

using System;

class DivisionByPrimeNums
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool canBeDivided;

        canBeDivided = (number % 2 == 0) && (number % 3 == 0) && (number % 5 == 0) ? canBeDivided = true : canBeDivided = false;
        Console.WriteLine(canBeDivided);
    }
}

