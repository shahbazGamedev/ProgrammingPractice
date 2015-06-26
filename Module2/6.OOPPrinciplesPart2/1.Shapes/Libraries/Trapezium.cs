namespace Shapes.Libraries
{
    public class Trapezium : Quadrilateral
    {
        public Trapezium(double a, double b, double c, double d, double h)
        {
            this.SideA = a;
            this.SideB = b;
            this.SideC = c;
            this.SideD = d;
            this.Height = h;
        }

        public double Height { get; set; }

        public override string QuadrilateralSpecificName
        {
            get { return "Trapezium"; }
        }

        protected override double QuadrilateralSpecificSurface
        {
            get { return (((this.SideA + this.SideB) / 2) * this.Height); }
        }
    }
}
