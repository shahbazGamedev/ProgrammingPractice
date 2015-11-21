// Write an expression to check if the 3rd digit of an integer is 3. e.g. 2351
// -> true

using System;

class ThridDigit
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        if ((number % 1000) / 100 == 3)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

