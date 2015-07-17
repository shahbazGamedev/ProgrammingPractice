namespace PlazaSmash.Views
{
    using System;

    public class MoveView : ViewObject
    {
        public MoveView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\Move", modelName);
            string contentDir = string.Format("Characters\\{0}\\Move", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
