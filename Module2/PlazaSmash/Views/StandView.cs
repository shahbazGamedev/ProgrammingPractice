namespace PlazaSmash.Views
{
    using System;

    public class StandView : ViewObject
    {
        public StandView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Stand", modelName);
            string contentDir = string.Format("Characters\\{0}\\Stand", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
