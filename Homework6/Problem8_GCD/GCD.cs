// Write a program that calculates the greatest common divisor (GCD) of
// given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

class GCD
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int tempNumber;

        while (firstNumber != 0 && secondNumber != 0)
        {
            tempNumber = secondNumber;
            secondNumber %= firstNumber;
            firstNumber = tempNumber;
        }
        // only one of them is 0 so print the other:
        Console.WriteLine("\nGCD is: " + (firstNumber + secondNumber));
    }
}

