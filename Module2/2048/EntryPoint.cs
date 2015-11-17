namespace TwentyFortyEightGame
{
    using System;

#if WINDOWS || LINUX
    public static class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new TwentyFortyEight())
                game.Run();
        }
    }
#endif
}
