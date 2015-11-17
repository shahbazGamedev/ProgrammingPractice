// Write a program that reads a string from the console and lists all
// different words in the string along with information how many times each
// word is found.

using System;
using System.Collections.Generic;

class AllWords
{
    static void Main()
    {
        Dictionary<string, int> differentWords = new Dictionary<string, int>();
        
        Console.Write("Enter your string: ");

        string someText = Console.ReadLine();

        Console.WriteLine();

        string[] wordsFromText = someText.Split(new[]{ ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < wordsFromText.Length; i++)
        {
            if (!differentWords.ContainsKey(wordsFromText[i]))
            {
                differentWords.Add(wordsFromText[i], 1);
            }
            else
            {
                differentWords[wordsFromText[i]] += 1;
            }
        }

        foreach (KeyValuePair<string, int> pair in differentWords)
        {
            Console.WriteLine(pair);
        }

        Console.WriteLine();
    }
}

