// Write a boolean expression for finding if the bit 2 (counting from 0) of a
// given integer is 1 or 0.

using System;

class CheckSecondBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (Convert.ToBoolean(( (number & (1 << 2) ) >> 2) ))
        {
            Console.WriteLine("The bit at position 2 is 1");
        }
        else
        {
            Console.WriteLine("The bit at position 2 is 0");
        }
    }
}
