namespace PlazaSmash.Views
{
    using System;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class ViewObject
    {
        public int CurrentImageIndex { get; set; }

        public bool ToBeDrawn { get; set; }

        public bool Drawn { get; set; }

        protected Texture2D[] Animation { get; set; }

        protected Texture2D CurrentImage { get; set; }

        // CACHES ALL PIXEL MATRIX INFO FOR THE COLLISIONS
        protected Color[][] AnimationColorData { get; set; }

        protected int TotalImageCount { get; set; }

        public void Initialize(string filesDir, string contentDir)
        {
            this.TotalImageCount = this.GetTotalNumberOfImages(filesDir);

            this.Animation = new Texture2D[this.TotalImageCount];
            for (int i = 0; i < this.TotalImageCount; i++)
            {
                this.Animation[i] = EntryPoint.Game.Content.Load<Texture2D>(string.Format("{0}\\{1}", contentDir, i));
            }

            this.AnimationColorData = new Color[this.TotalImageCount][];
            for (int i = 0; i < this.TotalImageCount; i++)
            {
                this.AnimationColorData[i] = new Color[this.Animation[i].Bounds.Width * this.Animation[i].Bounds.Height];
                this.Animation[i].GetData(this.AnimationColorData[i]);
            }

            this.CurrentImageIndex = 0;
            this.CurrentImage = this.Animation[this.CurrentImageIndex];
            this.ToBeDrawn = false;
            this.Drawn = false;
        }

        // SCANS THE TARGET DIR FOR ANIMATION LENGTH
        public int GetTotalNumberOfImages(string targetDir)
        {
            string[] files = Directory.GetFiles(Path.GetFullPath(targetDir));

            return files.Length;
        }

        public Color[] GetColorData()
        {
            // RETURNS THE CACHED COLOR DATA OF THE CURRENT SPRITE WHICH IS BEEN DRAWN
            if (this.CurrentImageIndex > this.TotalImageCount - 1)
            {
                return this.AnimationColorData[this.TotalImageCount - 1];
            }
            else
            {
                return this.AnimationColorData[this.CurrentImageIndex];
            }
        }

        public virtual void Draw(Rectangle modelBounds)
        {
            if (this.CurrentImageIndex > this.TotalImageCount - 1)
            {
                this.CurrentImageIndex = 0;
                this.Drawn = true;
            }
            else
            {
                this.CurrentImage = this.Animation[this.CurrentImageIndex];
                this.CurrentImageIndex++;
                this.Drawn = false;
            }

            EntryPoint.Game.SpriteBatch.Draw(this.CurrentImage, modelBounds, Color.White);
        }
    }
}
