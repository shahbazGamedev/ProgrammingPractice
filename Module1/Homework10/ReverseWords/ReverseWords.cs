// Write a program that reverses the words in given sentence.

using System;

class ReverseWords
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine();

        string reversedText = "";
        string currentWord = "";

        for (int i = 0; i < someText.Length; i++)
        {
            if (someText[i] != ' ' && someText[i] != '.' & someText[i] != '?' && someText[i] != '!')
            {
                currentWord += someText[i];
            }
            else
            {
                reversedText += ReverseWord(currentWord) + someText[i];

                currentWord = "";
                continue;
            }
        }
        Console.WriteLine("\nReversed: {0}", reversedText);
    }

    static string ReverseWord(string word)
    {
        string reversedWord = "";
       
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversedWord += word[i];
        }
        return reversedWord;
    }
}

