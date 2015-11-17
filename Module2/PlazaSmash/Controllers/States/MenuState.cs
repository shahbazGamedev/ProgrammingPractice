namespace PlazaSmash.Controllers.States
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MenuState : State
    {
        private const int TotalButtonsCount = 4;

        private Random rng;
        private KeyboardState previousKeyboardState;

        public MenuState(State nextState)
            : base(nextState)
        {
            AudioController.Initialize();

            this.rng = new Random();
            this.MenuBackground = EntryPoint.Game.Content.Load<Texture2D>("Menu\\MenuBackground");
            this.NewGameButton = EntryPoint.Game.Content.Load<Texture2D>("Menu\\NewGame");
            this.NewGameButtonOnScroll = EntryPoint.Game.Content.Load<Texture2D>("Menu\\NewGameOnScroll");
            this.DonateMoneyButton = EntryPoint.Game.Content.Load<Texture2D>("Menu\\Donate");
            this.DonateMoneyButtonOnScroll = EntryPoint.Game.Content.Load<Texture2D>("Menu\\DonateOnScroll");
            this.QuitGameButton = EntryPoint.Game.Content.Load<Texture2D>("Menu\\QuitGame");
            this.QuitGameButtonOnScroll = EntryPoint.Game.Content.Load<Texture2D>("Menu\\QuitGameOnScroll");
            this.CaryCaffreyMotto = EntryPoint.Game.Content.Load<Texture2D>("Menu\\CaryCaffrey");
            this.EdParkerMotto = EntryPoint.Game.Content.Load<Texture2D>("Menu\\EdParker");
            this.JoeLewisMotto = EntryPoint.Game.Content.Load<Texture2D>("Menu\\JoeLewis");
            this.ControlsButton = EntryPoint.Game.Content.Load<Texture2D>("Menu\\Controls");
            this.ControlsButtonOnScroll = EntryPoint.Game.Content.Load<Texture2D>("Menu\\ControlsOnScroll");
            this.ControlsScreen = EntryPoint.Game.Content.Load<Texture2D>("Menu\\ControlsScreen");
            this.DonationScreen = EntryPoint.Game.Content.Load<Texture2D>("Menu\\DonationScreen");
            this.SelectedMotto = this.rng.Next(0, 3);
            this.ActiveButtonIndex = 0;
            this.ButtonsCount = TotalButtonsCount;
            this.ControlsScreenDisplayed = false;
            this.DonationScreenDisplayed = false;
        }

        private Texture2D MenuBackground { get; set; }

        private Texture2D NewGameButton { get; set; }

        private Texture2D NewGameButtonOnScroll { get; set; }

        private Texture2D DonateMoneyButton { get; set; }

        private Texture2D DonateMoneyButtonOnScroll { get; set; }

        private Texture2D QuitGameButton { get; set; }

        private Texture2D QuitGameButtonOnScroll { get; set; }

        private Texture2D CaryCaffreyMotto { get; set; }

        private Texture2D EdParkerMotto { get; set; }

        private Texture2D JoeLewisMotto { get; set; }

        private Texture2D ControlsButton { get; set; }

        private Texture2D ControlsButtonOnScroll { get; set; }

        private Texture2D ControlsScreen { get; set; }

        private Texture2D DonationScreen { get; set; }

        private int SelectedMotto { get; set; }

        private int ActiveButtonIndex { get; set; }

        private int ButtonsCount { get; set; }

        private bool ControlsScreenDisplayed { get; set; }

        private bool DonationScreenDisplayed { get; set; }

        public override void Execute()
        {
            this.HandleUserInput();
        }

        public override void Draw()
        {
            AudioController.PlaySound(AudioController.MenuMusicInstance);

            if (this.ControlsScreenDisplayed)
            {
                EntryPoint.Game.SpriteBatch.Draw(this.ControlsScreen, new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight), Color.White);
            }
            else if (this.DonationScreenDisplayed)
            {
                EntryPoint.Game.SpriteBatch.Draw(this.DonationScreen, new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight), Color.White);
            }
            else
            {
                EntryPoint.Game.SpriteBatch.Draw(this.MenuBackground, new Rectangle(0, 0, PlazaSmashGame.WindowWidth, PlazaSmashGame.WindowHeight), Color.White);

                this.PrintMenuButtons();

                this.PrintMotto();
            }
        }
        
        private void PrintMotto()
        {
            if (this.SelectedMotto == 0)
            {
                EntryPoint.Game.SpriteBatch.Draw(this.CaryCaffreyMotto, new Rectangle(170, 380, 818, 100), Color.White);
            }
            else if (this.SelectedMotto == 1)
            {
                EntryPoint.Game.SpriteBatch.Draw(this.EdParkerMotto, new Rectangle(70, 400, 1076, 80), Color.White);
            }
            else if (this.SelectedMotto == 2)
            {
                EntryPoint.Game.SpriteBatch.Draw(this.JoeLewisMotto, new Rectangle(150, 400, 916, 80), Color.White);
            }
        }

        private void HandleUserInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && !this.previousKeyboardState.IsKeyDown(Keys.Up) &&
                !this.DonationScreenDisplayed && !this.ControlsScreenDisplayed)
            {
                this.ActiveButtonIndex--;

                if (this.ActiveButtonIndex >= 0)
                {
                    AudioController.PlaySound(AudioController.MenuClickInstance);
                }

                if (this.ActiveButtonIndex < 0)
                {
                    this.ActiveButtonIndex = 0;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Down) && !this.previousKeyboardState.IsKeyDown(Keys.Down) &&
                !this.DonationScreenDisplayed && !this.ControlsScreenDisplayed)
            {
                this.ActiveButtonIndex++;

                if (this.ActiveButtonIndex <= TotalButtonsCount - 1)
                {
                    AudioController.PlaySound(AudioController.MenuClickInstance);
                }

                if (this.ActiveButtonIndex > TotalButtonsCount - 1)
                {
                    this.ActiveButtonIndex = TotalButtonsCount - 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Enter) && !this.previousKeyboardState.IsKeyDown(Keys.Enter))
            {
                if (this.ActiveButtonIndex == 0)
                {
                    BattlegroundController.Initialize();

                    InputController.Initialize();

                    PlazaSmashGame.SM.ChangeState();
                    
                    AudioController.StopSound(AudioController.MenuMusicInstance);
                }
                else if (this.ActiveButtonIndex == 1)
                {
                    if (!this.DonationScreenDisplayed)
                    {
                        AudioController.PlaySound(AudioController.MenuClickInstance);
                        this.DonationScreenDisplayed = true;
                    }
                    else
                    {
                        AudioController.PlaySound(AudioController.MenuClickInstance);
                        this.DonationScreenDisplayed = false;
                    }
                }
                else if (this.ActiveButtonIndex == 2)
                {
                    if (!this.ControlsScreenDisplayed)
                    {
                        AudioController.PlaySound(AudioController.MenuClickInstance);
                        this.ControlsScreenDisplayed = true;
                    }
                    else
                    {
                        AudioController.PlaySound(AudioController.MenuClickInstance);
                        this.ControlsScreenDisplayed = false;
                    }
                }
                else if (this.ActiveButtonIndex == 3)
                {
                    AudioController.PlaySound(AudioController.MenuClickInstance);
                    EntryPoint.Game.Exit();
                }
            }

            this.previousKeyboardState = keyboardState;
        }

        private void PrintMenuButtons()
        {
            for (int i = 0; i < TotalButtonsCount; i++)
            {
                if (i == 0)
                {
                    if (this.ActiveButtonIndex == 0)
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.NewGameButtonOnScroll, new Rectangle(370, 40, 450, 60), Color.White);
                    }
                    else
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.NewGameButton, new Rectangle(370, 40, 450, 60), Color.White);
                    }
                }

                if (i == 1)
                {
                    if (this.ActiveButtonIndex == 1)
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.DonateMoneyButtonOnScroll, new Rectangle(270, 120, 660, 60), Color.White);
                    }
                    else
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.DonateMoneyButton, new Rectangle(270, 120, 660, 60), Color.White);
                    }
                }

                if (i == 2)
                {
                    if (this.ActiveButtonIndex == 2)
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.ControlsButtonOnScroll, new Rectangle(370, 200, 450, 60), Color.White);
                    }
                    else
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.ControlsButton, new Rectangle(370, 200, 450, 60), Color.White);
                    }
                }

                if (i == 3)
                {
                    if (this.ActiveButtonIndex == 3)
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.QuitGameButtonOnScroll, new Rectangle(370, 280, 450, 60), Color.White);
                    }
                    else
                    {
                        EntryPoint.Game.SpriteBatch.Draw(this.QuitGameButton, new Rectangle(370, 280, 450, 60), Color.White);
                    }
                }
            }
        }
    }
}
