// Write a program that reads the coefficients a, b and c of a quadratic
// equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class QEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        Console.WriteLine("\nx = " + (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a);
        Console.WriteLine("x = " + (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a);
    }
}

