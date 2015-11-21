// Write a program that extracts from a given text all sentences containing given word.

using System;

class ExtractSentences
{
    static void Main()
    {
        Console.Write("Enter your string: ");
        string someText = Console.ReadLine();

        Console.Write("Enter your word: ");
        string word = Console.ReadLine();

        char[] separators = { '.', '?', '!' };
        string[] wordsFromText = someText.Split(separators);

        for (int i = 0; i < wordsFromText.Length; i++)
        {
            wordsFromText[i] = wordsFromText[i].Trim();

            if (wordsFromText[i].Contains(word))
            {
                Console.WriteLine(wordsFromText[i] + "\n");
            }
        }
    }
}
