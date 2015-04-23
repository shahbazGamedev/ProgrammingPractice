// Write a program that evaluates the area of a trapezium, given its sides
// and height.

using System;

class AreaOfTrapezium
{ 
    static void Main()
    {
        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Console.WriteLine("The area of the figure is: " + ((sideA + sideB) / 2) * height);
    }
}