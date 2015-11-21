// Read two integer values from the console and exchange their values.

using System;

class SwapInts
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        int tempNumber = firstNumber;
        firstNumber = secondNumber;
        secondNumber = tempNumber;

        Console.WriteLine();
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
    }
}

