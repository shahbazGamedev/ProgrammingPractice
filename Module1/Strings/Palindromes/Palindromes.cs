// Write a program that extracts from a given text all palindromes, e.g. “level", “stats", “radar".

using System;
using System.Collections.Generic;
using System.Text;

class Palindromes
{
    static void Main()
    {
        Console.Write("Input text: ");
        string someText = Console.ReadLine();

        string wordHolder = "";
        string mirroredWordHolder = "";
        List<string> palindromeHolder = new List<string>();

        for (int i = 0; i < someText.Length; i++)
        {
            if (someText[i] != ' ' && someText[i] != ',' && someText[i] != '.' && someText[i] != '?' && someText[i] != '!')
            {
                wordHolder += someText[i].ToString().ToLower();
            }
            else
            {
                for (int j = wordHolder.Length - 1; j >= 0; j--)
                {
                    mirroredWordHolder += wordHolder[j];
                }
                if (wordHolder == mirroredWordHolder)
                {
                    palindromeHolder.Add(wordHolder.ToString());
                }
                wordHolder = "";
                mirroredWordHolder = "";

                continue;
            }
        }
        Console.WriteLine("\nPalindromes found: {0}", string.Join(" ", palindromeHolder));
    }
}
