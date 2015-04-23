// Write an expression that checks if given integer is odd or even.

using System;

class OddOrEven
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isEven;

        isEven = number % 2 == 0 ? isEven = true : isEven = false;
        Console.WriteLine(isEven);
    }
}

