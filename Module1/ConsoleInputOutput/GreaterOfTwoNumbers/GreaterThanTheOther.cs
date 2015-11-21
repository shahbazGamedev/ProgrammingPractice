// Write a program that gets two numbers from the console and prints the
// greater of them. Don’t use if statements.

using System;

class GreaterThanTheOther
{
    static void Main()
    {
        decimal firstNumber = decimal.Parse(Console.ReadLine());
        decimal secondNumber = decimal.Parse(Console.ReadLine());

        decimal greaterNumber = firstNumber > secondNumber ? firstNumber : secondNumber;

        Console.WriteLine(greaterNumber);
    }
}

