// Write a program that reads from the console a string of maximum
// 20 characters. If the length of the string is less than 20, the rest of
// the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class Asterisks
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine();
        StringBuilder asterisks = new StringBuilder();

        if (someText.Length >= 20)
        {
            return;
        }
        else
        {
            for (int i = 1; i < 21 - someText.Length; i++)
            {
                asterisks.Append('*');
            }

            Console.WriteLine("\n" + someText + asterisks);
        }
    }
}

