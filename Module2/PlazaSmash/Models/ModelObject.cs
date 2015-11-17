namespace PlazaSmash.Models
{
    using Microsoft.Xna.Framework;
    
    public abstract class ModelObject
    {
        public Vector2 Location { get; set; }

        public Rectangle Bounds { get; set; }

        public string Name { get; set; }
    }
}
