namespace PlazaSmash
{
    using System;

    public static class EntryPoint
    {
        public static PlazaSmashGame Game { get; set; }

        public static void Main()
        {
            using (Game = new PlazaSmashGame())
            {
                Game.Run();
            }
        }
    }
}
