// Write a method that asks the user for his name and prints “Hello,
// <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class PrintName
{
    static void Main()
    {
        Console.WriteLine("Hello, {0}!", GetName());
    }

    private static string GetName()
    {
        Console.WriteLine("Input your name!");

        string name = Console.ReadLine();

        return name;
    }
}



