// Write an expression that checks if a given point (x,y) is within a circle
// with radius 4 and centre at (0,0)

using System;

class PointInCircle
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine()); // coord
        int y = int.Parse(Console.ReadLine()); // coord

        if (x > 4 || y > 4)
        {
            Console.WriteLine("The point with coords {0} and {1} is outside the circle.", x, y);
        }
        else
        {
            Console.WriteLine("The point with coords {0} and {1} is inside the circle.", x, y);
        }
    }
}

