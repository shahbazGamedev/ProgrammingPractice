namespace Shapes.Libraries
{
    public class RegularPolygon : Shape
    {
        public RegularPolygon(int n, double side, double a)
        {
            this.NumberOfSides = n;
            this.Side = side;
            this.Apothem = a;
        }
        
        public int NumberOfSides { get; set; }

        public double Side { get; set; }

        public double Apothem { get; set; }

        public override string ShapeName
        {
            get { return string.Format("Regular {0}-gon", this.NumberOfSides); }
        }

        public override double CalculatePerimeter()
        {
            return (this.NumberOfSides * this.Side);
        }

        public override double CalculateSurface()
        {
            return ((this.Apothem * this.CalculatePerimeter()) / 2);
        }
    }
}
