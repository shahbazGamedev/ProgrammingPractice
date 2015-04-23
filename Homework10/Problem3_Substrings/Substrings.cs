// Write a program that finds how many times a substring is contained in a
// given text (perform case insensitive search).

using System;
using System.Linq;

class Substrings
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine().ToLower();

        Console.Write("Input your search string: ");
        string searchString = Console.ReadLine().ToLower();

        int containedCounter = 0;

        for (int i = 0; i <= someText.Length - searchString.Length; i++)
        {
            if (someText.Substring(i, searchString.Length) == searchString)
            {
                containedCounter++;
            }        
        }
        Console.WriteLine("\nThe substring was found {0} time/s.", containedCounter);
    }
}

