namespace Shapes.Libraries
{
    public class Square : Quadrilateral
    {
        public Square(double a)
        {
            this.SideA = a;
            this.SideB = a;
            this.SideC = a;
            this.SideD = a;
        }

        public override string QuadrilateralSpecificName
        {
            get { return "Square"; }
        }

        protected override double QuadrilateralSpecificSurface
        {
            get { return (this.SideA * this.SideA); }
        }
    }
}
