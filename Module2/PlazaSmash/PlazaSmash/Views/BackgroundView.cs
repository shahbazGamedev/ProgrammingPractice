namespace PlazaSmash.Views
{
    public class BackgroundView : ViewObject
    {
        public BackgroundView(string modelName)
        {
            string filesDir = string.Format("Content\\Backgrounds\\{0}\\", modelName);
            string contentDir = string.Format("Backgrounds\\{0}", modelName);

            this.Initialize(filesDir, contentDir);
        }
    }
}
