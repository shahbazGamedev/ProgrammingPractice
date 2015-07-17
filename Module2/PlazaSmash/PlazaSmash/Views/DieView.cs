namespace PlazaSmash.Views
{
    using System;

    public class DieView : ViewObject
    {
        public DieView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Die", modelName);
            string contentDir = string.Format("Characters\\{0}\\Die", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
