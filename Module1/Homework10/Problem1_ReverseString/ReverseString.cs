// Write a program that reads a string, reverses it and prints the result at
// the console. Do NOT use any built in methods!

using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine();

        StringBuilder someReversedText = new StringBuilder();

        for (int i = someText.Length - 1; i >= 0; i--)
        {
            someReversedText.Append(someText[i]);
        }

        Console.WriteLine(someReversedText);
    }
}
