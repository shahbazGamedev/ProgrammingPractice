namespace PlazaSmash.Views
{
    using System;

    public class HitView : ViewObject
    {
        public HitView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Hit", modelName);
            string contentDir = string.Format("Characters\\{0}\\Hit", modelName);

            this.Initialize(filesDir, contentDir);

            this.Drawn = true;
        }
    }
}
