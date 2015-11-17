namespace PlazaSmash.Controllers.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using PlazaSmash;

    public class IntroState : State
    {
        private const int FirstIntroIntervalInSeconds = 5;
        private const int SecondIntroIntervalInSeconds = 10;

        public IntroState(State nextState)
            : base(nextState)
        {
            this.TeamLogo = EntryPoint.Game.Content.Load<Texture2D>("Intro\\Merge Gaming");
            this.AcademyLogo = EntryPoint.Game.Content.Load<Texture2D>("Intro\\Zariba");
            this.GameTitle = EntryPoint.Game.Content.Load<Texture2D>("Intro\\Game");
            this.AlphaValue = 1;
            this.FadeIncrement = 5;
            this.FadeDelay = 0.035;
        }

        private Texture2D TeamLogo { get; set; }

        private Texture2D AcademyLogo { get; set; }

        private Texture2D GameTitle { get; set; }

        private int AlphaValue { get; set; }

        private int FadeIncrement { get; set; }

        private double FadeDelay { get; set; }

        public override void Execute()
        {
        }

        public override void Draw()
        {
            this.HandleIntroFading();
            this.DrawIntro();
        }

        private void HandleIntroFading()
        {
            this.FadeDelay -= EntryPoint.Game.GameTimeElapsed;

            if (this.FadeDelay <= 0)
            {
                this.FadeDelay = 0.035;
                this.AlphaValue += this.FadeIncrement;

                if (EntryPoint.Game.TotalElapsedTime.Seconds == FirstIntroIntervalInSeconds)
                {
                    this.AlphaValue = 0;
                    this.FadeIncrement = 8;
                }
            }
        }

        private void DrawIntro()
        {
            if (EntryPoint.Game.TotalElapsedTime.Seconds < FirstIntroIntervalInSeconds)
            {
                EntryPoint.Game.SpriteBatch.Draw(
                    this.AcademyLogo, 
                    new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight),
                    new Color(255, 255, 255, (byte)MathHelper.Clamp(this.AlphaValue, 0, 255)));
            }
            else if (EntryPoint.Game.TotalElapsedTime.Seconds >= FirstIntroIntervalInSeconds &&
                EntryPoint.Game.TotalElapsedTime.Seconds < SecondIntroIntervalInSeconds)
            {
                EntryPoint.Game.SpriteBatch.Draw(
                    this.TeamLogo, 
                    new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight),
                    new Color(255, 255, 255, (byte)MathHelper.Clamp(this.AlphaValue, 0, 255)));

                AudioController.PlaySound(AudioController.IntroSongInstance);
            }
            else if (EntryPoint.Game.TotalElapsedTime.Seconds >= SecondIntroIntervalInSeconds)
            {
                EntryPoint.Game.SpriteBatch.Draw(
                    this.GameTitle, 
                    new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight), 
                    Color.White);

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    AudioController.StopSound(AudioController.IntroSongInstance);
                    PlazaSmashGame.SM.ChangeState();
                }
            }
        }
    }
}
