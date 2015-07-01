namespace TwentyFortyEightGame
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System.Threading;
    using TwentyFortyEightGame.Libs;

    public class TwentyFortyEight : Game
    {
        private const int WINDOW_HEIGHT = 495;
        private const int WINDOW_WIDTH = 495;

        private Board board;
        private Background background;
        private SpriteFont basicFont;
        private KeyboardState oldState;

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public TwentyFortyEight()
        {
            this.Window.Title = "2048";
            this.IsMouseVisible = true;

            this.Content.RootDirectory = "Content";

            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            this.graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        }

        protected override void Initialize()
        {
            base.Initialize();

            board = new Board();
            board.SpawnRandomTileNumber();
            oldState = Keyboard.GetState();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new Background(new Vector2(0, 0), Content.Load<Texture2D>("board"));
            basicFont = Content.Load<SpriteFont>("Font");
        }

        protected override void UnloadContent()
        {
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState != oldState)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    this.board.Update(-1, 0);
                    board.SpawnRandomTileNumber();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    this.board.Update(1, 0);
                    board.SpawnRandomTileNumber();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    this.board.Update(0, -1);
                    board.SpawnRandomTileNumber();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    this.board.Update(0, 1);
                    board.SpawnRandomTileNumber();
                }

                oldState = newState;
            }
        }

        protected bool IsGameOver()
        {
            bool isGameOver = true;

            for (int i = 0; i < this.board.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.Tiles.GetLength(1); j++)
                {
                    if(this.board.Tiles[i, j].Number == 0)
                    {
                        isGameOver = false;
                    }
                }
            }

            return isGameOver;
        }
        
        protected override void Update(GameTime gameTime)
        {
            this.UpdateInput();
            if (this.IsGameOver())
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            this.spriteBatch.Begin();

            this.background.Draw(spriteBatch);

            for (int i = 0; i < this.board.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.Tiles.GetLength(1); j++)
                {
                    this.board.Tiles[i, j].Draw(spriteBatch, basicFont);
                }
            }

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
