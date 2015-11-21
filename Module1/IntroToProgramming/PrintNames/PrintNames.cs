// Write a program to read your first and last names and print them on the
// console, separated by space.

using System;

class PrintNames
{
    static void Main()
    {
        string firstName, lastName;

        firstName = Console.ReadLine();
        lastName = Console.ReadLine();

        Console.WriteLine(firstName + ' ' + lastName);
    }
}

