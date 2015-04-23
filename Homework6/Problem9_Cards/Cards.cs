// Write a program that prints all possible cards from a standard deck of
// 52 cards (without jokers). The cards should be printed with their English
// names. Use nested for loops and switch-case.

using System;

class Cards
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();

        char cardType = '\u2663';

        for (int allCardTypes = 1; allCardTypes <= 4; allCardTypes++)
        {
            switch (cardType)
            {
                case '\u2663':
                    Console.ForegroundColor = ConsoleColor.Black;

                    PrintCards(cardType);

                    cardType = '\u2666';
                    break;
                case '\u2666':
                    Console.ForegroundColor = ConsoleColor.Red;

                    PrintCards(cardType);

                    cardType = '\u2665';
                    break;
                case '\u2665':
                    Console.ForegroundColor = ConsoleColor.Red;

                    PrintCards(cardType);

                    cardType = '\u2660';
                    break;
                case '\u2660':
                    Console.ForegroundColor = ConsoleColor.Black;

                    PrintCards(cardType);
                    break;
            }
        }
    }

    private static void PrintCards(char cardType)
    {
        Console.Write("A-" + cardType + "    ");
        for (int i = 2; i <= 10; i++)
        {
            Console.Write(i + "-" + cardType + " ");
        }
        Console.Write("   ");
        Console.Write("J-" + cardType + " ");
        Console.Write("Q-" + cardType + " ");
        Console.Write("K-" + cardType + " ");

        Console.WriteLine("\n");
    }
}

