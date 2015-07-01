namespace TwentyFortyEightGame.Libs
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Tile
    {
        public Vector2 Location { get; set; }
        public int Number { get; set; }
        public bool IsVisible { get; set; }

        public Tile()
        {

        }

        public Tile(Vector2 location)
        {
            this.Location = location;
            this.Number = 0;
            this.IsVisible = false;
        }

        public void Draw(SpriteBatch sb, SpriteFont font)
        {
            if (this.IsVisible)
            {
                sb.DrawString(font, this.Number.ToString(), this.Location, Color.Black);
            }
        }
    }
}
