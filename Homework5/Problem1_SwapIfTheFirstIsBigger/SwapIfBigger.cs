// Write an if statement that exchanges the values of 2 numbers if the first
// is bigger than the second

using System;

class SwapIfBigger
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int tempNumber;

        if (firstNumber > secondNumber)
        {
            tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
        }
        Console.WriteLine("\n");
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
    }
}

