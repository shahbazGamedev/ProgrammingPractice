// Write a method that counts how many times given number appears
// in given array. Write a test program to check if the method is working correctly.

using System;

class CountNumber
{
    static void Main()
    {
        Console.WriteLine("Enter your number:");

        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("That number can be found {0} time/s in the array!", CountNumberInArray(number));
    }

    private static int CountNumberInArray(int number)
    {
        int[] numbers = { 1, 4, 32, 5, 654, 23, 12, 54, 23, 5 };

        int counter = 0;

        foreach (var element in numbers)
        {
            if (element == number)
            {
                counter++;
            }
        }

        return counter;
    }
}

