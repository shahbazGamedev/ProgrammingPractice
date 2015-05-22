// Write a program that reads a string from the console and prints all
// different letters in the string along with information how many times
// each letter is found.

using System;

class AllLetters
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine().ToLower();

        int[] lettersCounter = new int[28];

        for (int i = 0; i < lettersCounter.Length; i++)
        {
            lettersCounter[i] = 0;
        }

        for (int i = 0; i < someText.Length; i++)
        {
            if (someText[i] != ' ')
            {
                lettersCounter[(int)someText[i] - 97]++;
            }
        }

        Console.WriteLine();

        for (int i = 0; i < lettersCounter.Length; i++)
	    {
			 if (lettersCounter[i] != 0)
             {
                Console.WriteLine("{0} -> {1} time/s", (char)(i + 97), lettersCounter[i]);
             }
	    }       
    }
}

