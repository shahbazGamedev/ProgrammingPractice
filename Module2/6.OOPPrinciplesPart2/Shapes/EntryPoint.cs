namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using Shapes.Libraries;
    
    public class EntryPoint
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(2.55));
            shapes.Add(new Triangle(3, 4, 5));
            shapes.Add(new Square(12));
            shapes.Add(new Rectangle(2.50, 7.15));
            shapes.Add(new Trapezium(12, 35, 55, 55, 25.15));
            shapes.Add(new Rhombus(8.20, 11, 12));
            shapes.Add(new RegularPolygon(5, 10, 14.50));

            foreach (Shape s in shapes)
            {
                Console.WriteLine(s);
            }
        }
    }
}
