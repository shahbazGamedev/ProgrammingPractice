namespace PlazaSmash.Views
{
    using System;

    public class ReversedMoveView : ViewObject
    {
        public ReversedMoveView(string modelName)
        {
            string filesDir = string.Format("Content\\Characters\\{0}\\ReversedMove", modelName);
            string contentDir = string.Format("Characters\\{0}\\ReversedMove", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
