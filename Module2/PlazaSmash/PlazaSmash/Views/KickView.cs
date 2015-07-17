namespace PlazaSmash.Views
{
    using System;

    public class KickView : ViewObject
    {
        public KickView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Kick", modelName);
            string contentDir = string.Format("Characters\\{0}\\Kick", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
