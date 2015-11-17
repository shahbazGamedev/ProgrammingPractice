namespace PlazaSmash.Views
{
    using System;

    public class GetHitView : ViewObject
    {
        public GetHitView(string modelName)
        {
            string filesDir = String.Format("Content\\Characters\\{0}\\GetHit", modelName);
            string contentDir = String.Format("Characters\\{0}\\GetHit", modelName);

            this.Initialize(filesDir, contentDir);
        }

    }
}
