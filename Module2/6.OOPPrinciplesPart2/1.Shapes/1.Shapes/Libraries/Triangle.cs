namespace Shapes.Libraries
{
    using System;

    public class Triangle : Shape
    {    
        public Triangle(double a, double b, double c)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;
        }
        
        public double SideA { get; set; }

        public double SideB { get; set; }
        
        public double SideC { get; set; }

        public override string ShapeName
        {
            get { return "Triangle"; }
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override double CalculateSurface()
        {
            double p = this.CalculatePerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }
}
