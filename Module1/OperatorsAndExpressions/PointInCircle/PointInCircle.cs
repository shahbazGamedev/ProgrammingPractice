// Write an expression that checks if a given point (x,y) is within a circle
// with radius 4 and centre at (0,0)

using System;

class PointInCircle
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine()); // coord
        int y = int.Parse(Console.ReadLine()); // coord

        bool isPointInCircle = (x > 4 || y > 4) ? isPointInCircle = false : isPointInCircle = true;

        Console.WriteLine("The point with x = {0}, y = {1} is inside the circle: {2}", x, y, isPointInCircle);
    }
}
