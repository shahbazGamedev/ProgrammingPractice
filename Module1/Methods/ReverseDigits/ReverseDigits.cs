// Write a method that reverses the digits of given decimal number.
// Example: 256 -> 652

using System;

class ReverseDigits
{
    static void Main()
    {
        Console.WriteLine("Input your number:");

        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("The reversed version is: {0}", Reverse(number));
    }

    private static string Reverse(int number)
    {
        string reversedNumber = "";

        while (number >= 1)
        {
            reversedNumber += number % 10;
            
            number /= 10;
        }

        return reversedNumber;
    }
}

