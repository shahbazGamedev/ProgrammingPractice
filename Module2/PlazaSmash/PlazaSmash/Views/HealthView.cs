namespace PlazaSmash.Views
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class HealthView
    {
        public HealthView(Vector2 location)
        {
            this.Font = EntryPoint.Game.Content.Load<SpriteFont>("Fonts\\HealthFont");
            this.Location = new Vector2(location.X, location.Y);
        }
        
        public SpriteFont Font { get; set; }

        private Vector2 Location { get; set; }

        public void Draw(string fighterHealth)
        {
            EntryPoint.Game.SpriteBatch.DrawString(this.Font, fighterHealth, new Vector2(this.Location.X, this.Location.Y), Color.DarkRed);
        }
    }
}
