namespace Shapes.Libraries
{
    public abstract class Shape
    {
        public abstract string ShapeName { get; }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("({0}) Perimeter: {1}, Surface: {2}", this.ShapeName, 
                this.CalculatePerimeter(), this.CalculateSurface());
        }
    }
}
