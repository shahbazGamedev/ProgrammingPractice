namespace PlazaSmash
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using PlazaSmash.Controllers;

    public class PlazaSmashGame : Game
    {
        public const int WindowWidth = 1200;
        
        public const int WindowHeight = 500;
       
        public PlazaSmashGame()
        {
            this.Window.Title = "\u00A9 2015 PLAZA SMASH - TEAM MERGE";
            this.Window.AllowAltF4 = true;

            this.Content.RootDirectory = "Content";

            this.Graphics = new GraphicsDeviceManager(this);
            this.Graphics.PreferredBackBufferHeight = WindowHeight;
            this.Graphics.PreferredBackBufferWidth = WindowWidth;

            SM = new StateController();

            this.GameTimeElapsed = 0;
        }
        
        public static StateController SM { get; private set; }
        
        public GraphicsDeviceManager Graphics { get; private set; }

        public SpriteBatch SpriteBatch { get; private set; }    

        public TimeSpan TotalElapsedTime { get; set; }

        public double GameTimeElapsed { get; set; }

        private bool GamePaused { get; set; }

        private bool PauseKeyDown { get; set; }

        private Texture2D PauseScreenImage { get; set; }

        private KeyboardState KeyboardState { get; set; }

        protected override void Initialize()
        {
            base.Initialize();

            this.GamePaused = false;        
            
            SM.Initialize();
            SM.CurrentState = SM.States["IntroState"];
        }

        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);
            this.PauseScreenImage = Content.Load<Texture2D>("Menu\\PauseScreen");
        }

        protected override void Update(GameTime gameTime)
        {
            this.KeyboardState = Keyboard.GetState();
            this.CheckPauseKey(this.KeyboardState);

            if (!this.GamePaused)
            {
                this.TotalElapsedTime += gameTime.ElapsedGameTime;
                SM.CurrentState.Execute();
                this.GameTimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.SpriteBatch.Begin();

            if (this.GamePaused)
            {
                this.SpriteBatch.Draw(this.PauseScreenImage, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);
            }
            else
            {
                if (this.GameTimeElapsed > 0.06)
                {
                    GraphicsDevice.Clear(Color.White);
                    SM.CurrentState.Draw();
                    this.GameTimeElapsed = 0;
                }       
            }
          
            this.SpriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void CheckPauseKey(KeyboardState keyboardState)
        {
            bool pauseKeyDownThisFrame = this.KeyboardState.IsKeyDown(Keys.P);

            if (!this.PauseKeyDown && pauseKeyDownThisFrame)
            {
                if (!this.GamePaused)
                {
                    this.GamePaused = true;
                    AudioController.PauseSound(AudioController.BattleSongInstance);
                }
                else
                {
                    this.GamePaused = false;
                    AudioController.ResumeSound(AudioController.BattleSongInstance);
                }
            }

            this.PauseKeyDown = pauseKeyDownThisFrame;
        }
    }
}
