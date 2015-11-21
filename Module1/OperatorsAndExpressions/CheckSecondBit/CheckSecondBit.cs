// Write a boolean expression for finding if the bit 2 (counting from 0) of a
// given integer is 1 or 0.

using System;

class CheckSecondBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        
        //  e.g.:
        
        //  0101 (5)
        //   &
        //  0100 (0001 shifted 2 positions to the left)  
        //  ----
        //  0100 (we now have the desired bit surrounded by zeros (this is the case if the 2-nd pos was one))
        
        //  0001 (0100 (1), shifted again to the right; if it was 0000 it would be (0), obviuosly) 

        bool isBitOne = Convert.ToBoolean(((number & (1 << 2)) >> 2)) ? isBitOne = true : isBitOne = false;
        Console.WriteLine("The bit at position two is 1: {0}", isBitOne);
    }
}

