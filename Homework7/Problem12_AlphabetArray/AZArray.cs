// Write a program that creates an array containing all letters from the alphabet
// (A-Z). Read a word from the console and print the index of each of its letters
// in the array.

using System;

class AZArray
{
    static void Main()
    {
        // the problem is quite easy solvable without an array; I don't see the point in creating one (?)
        char[] alphabet = new char[26];
        alphabet[0] = 'a';

        // this part is pointless:
        for (int i = 1; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)(alphabet[i - 1] + 1);
        }
        
        string word = Console.ReadLine();

        Console.WriteLine();

        for (int i = 0; i < word.Length; i++)
        {
            Console.Write("{0} -> {1}\n", word[i], (int)word[i] - alphabet[0]);
        }

        Console.WriteLine();
    }
}


