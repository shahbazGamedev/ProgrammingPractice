namespace Shapes.Libraries
{
    public abstract class Quadrilateral : Shape
    {
        public double SideA { get; set; }

        public double SideB { get; set; }

        public double SideC { get; set; }

        public double SideD { get; set; }

        public abstract string QuadrilateralSpecificName { get; }

        public override string ShapeName
        {
            get { return QuadrilateralSpecificName; }
        }

        public override double CalculatePerimeter()
        {
            return this.SideA + this.SideB + this.SideC + this.SideD;
        }

        public override double CalculateSurface()
        {
            return this.QuadrilateralSpecificSurface;
        }

        protected abstract double QuadrilateralSpecificSurface { get; }
    }
}
