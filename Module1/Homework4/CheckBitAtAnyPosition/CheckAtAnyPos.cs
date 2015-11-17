// Write a Boolean expression that returns if the bit at position p (counting
// from 0 ) in a given integer v has value of 1.

using System;

class CheckAtAnyPos
{
    static void Main()
    {
        // pretty much the same as Problem5:
        
        int v = int.Parse(Console.ReadLine()); // number
        int p = int.Parse(Console.ReadLine()); // position

        if (((v & (1 << p)) >> p) == 1)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

