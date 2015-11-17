namespace PlazaSmash.Models
{
    using Microsoft.Xna.Framework;

    public class BackgroundModel : ModelObject
    {
        public BackgroundModel(string name)
        {
            this.Location = new Vector2(0, 0);
            
            this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight);
            
            this.Name = name;
        }
    }
}
