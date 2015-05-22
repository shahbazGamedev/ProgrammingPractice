// Write a program that reads a string from the console and replaces
// all series of consecutive identical letters with a single one. Example:
// “zzzzzaaaarrrriiiiiiiibbbbbbbaaaaa" -> “zariba".

using System;
using System.Text;

class SingleLetter
{
    static void Main()
    {
        Console.Write("Input your string: ");
        string someText = Console.ReadLine().ToLower();

        StringBuilder someTextWithoutRepetition = new StringBuilder();

        someTextWithoutRepetition.Append(someText[0]);

        for (int i = 1; i < someText.Length; i++)
        {
            if (someText[i] != someText[i - 1])
            {
                someTextWithoutRepetition.Append(someText[i]);
            }
        }
        Console.WriteLine(someTextWithoutRepetition);
    }
}

