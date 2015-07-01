namespace Shapes.Libraries
{
    public class Rectangle : Quadrilateral
    {
        public Rectangle(double a, double b)
        {
            this.SideA = a;
            this.SideC = a;
            this.SideB = b;
            this.SideD = b;
        }
        
        public override string QuadrilateralSpecificName
        {
            get { return "Rectangle"; }
        }

        protected override double QuadrilateralSpecificSurface
        {
            get { return (this.SideA * this.SideB); }
        }
    }
}
