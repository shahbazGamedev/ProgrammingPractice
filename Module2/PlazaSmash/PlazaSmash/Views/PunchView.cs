namespace PlazaSmash.Views
{
    using System;

    public class PunchView : ViewObject
    {
        public PunchView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Punch", modelName);
            string contentDir = string.Format("Characters\\{0}\\Punch", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
