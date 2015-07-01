namespace Shapes.Libraries
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }

        public override string ShapeName
        {
            get { return "Circle"; }
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
