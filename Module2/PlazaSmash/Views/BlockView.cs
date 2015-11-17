namespace PlazaSmash.Views
{
    using System;
    using Microsoft.Xna.Framework;

    public class BlockView : ViewObject
    {
        public BlockView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Block", modelName);
            string contentDir = string.Format("Characters\\{0}\\Block", modelName);

            this.Initialize(filesDir, contentDir);

            this.OnHold = false;
        }

        public bool OnHold { get; set; }

        public override void Draw(Rectangle modelBounds)
        {
            if (this.OnHold)
            {
                if (this.CurrentImageIndex > this.TotalImageCount - 1)
                {
                    this.CurrentImage = this.Animation[this.TotalImageCount - 1];
                }
                else
                {
                    this.CurrentImage = this.Animation[this.CurrentImageIndex];
                    this.CurrentImageIndex++;
                }
            }

            EntryPoint.Game.SpriteBatch.Draw(this.CurrentImage, modelBounds, Color.White);
        }
    }
}
