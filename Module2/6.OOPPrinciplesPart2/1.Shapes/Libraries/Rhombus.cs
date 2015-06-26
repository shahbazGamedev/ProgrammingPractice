namespace Shapes.Libraries
{
    public class Rhombus : Quadrilateral
    {
        public Rhombus(double a, double p, double q)
        {
            this.SideA = a;
            this.SideB = a;
            this.SideC = a;
            this.SideD = a;
            this.FirstDiagonal = p;
            this.SecondDiagonal = q;
        }

        public double FirstDiagonal { get; set; }

        public double SecondDiagonal { get; set; }

        public override string QuadrilateralSpecificName
        {
            get { return "Rhombus"; }
        }

        protected override double QuadrilateralSpecificSurface
        {
            get { return ((this.FirstDiagonal * this.SecondDiagonal) / 2); }
        }
    }
}
