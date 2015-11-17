namespace TwentyFortyEightGame.Libs
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    public class Background
    {
        public Vector2 Location { get; private set; }
        public Texture2D Image { get; private set; }

        public Background(Vector2 location, Texture2D image)
        {
            this.Image = image;
            this.Location = location;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(this.Image, this.Location);
        }
    }
}
