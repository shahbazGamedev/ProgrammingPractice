namespace TwentyFortyEightGame.Libs
{
    using System;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Board
    {
        private const int BOARD_SIZE = 4;

        private Random rng;

        public Tile[,] Tiles { get; private set; }

        public Board()
        {
            this.rng = new Random();

            this.Tiles = new Tile[BOARD_SIZE, BOARD_SIZE];
            this.Tiles[0, 0] = new Tile(new Vector2(15, 7));
            this.Tiles[0, 1] = new Tile(new Vector2(134, 7));
            this.Tiles[0, 2] = new Tile(new Vector2(257, 7));
            this.Tiles[0, 3] = new Tile(new Vector2(377, 7));

            this.Tiles[1, 0] = new Tile(new Vector2(15, 126));
            this.Tiles[1, 1] = new Tile(new Vector2(134, 126));
            this.Tiles[1, 2] = new Tile(new Vector2(257, 126));
            this.Tiles[1, 3] = new Tile(new Vector2(377, 126));

            this.Tiles[2, 0] = new Tile(new Vector2(15, 249));
            this.Tiles[2, 1] = new Tile(new Vector2(134, 249));
            this.Tiles[2, 2] = new Tile(new Vector2(257, 249));
            this.Tiles[2, 3] = new Tile(new Vector2(377, 249));

            this.Tiles[3, 0] = new Tile(new Vector2(15, 369));
            this.Tiles[3, 1] = new Tile(new Vector2(134, 369));
            this.Tiles[3, 2] = new Tile(new Vector2(257, 369));
            this.Tiles[3, 3] = new Tile(new Vector2(377, 369));
        }

        public void SpawnRandomTileNumber()
        {
            int row = rng.Next(0, BOARD_SIZE);
            int col = rng.Next(0, BOARD_SIZE);
            if (!this.Tiles[row, col].IsVisible)
            {
                this.Tiles[row, col].IsVisible = true;
                this.Tiles[row, col].Number = 2;
            }
        }

        public void Update(int verticalMovement, int horizontalMovement)
        {
            bool isBoardChanged = false;

            Tile[,] tilesCopy = new Tile[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    tilesCopy[i, j] = new Tile();
                    tilesCopy[i, j].Number = this.Tiles[i, j].Number;
                    tilesCopy[i, j].IsVisible = this.Tiles[i, j].IsVisible;
                }
            }

            if (horizontalMovement != 0 || verticalMovement != 0)
            {
                int tilesMoveDirection = horizontalMovement != 0 ? horizontalMovement : verticalMovement;

                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    for (int j = (tilesMoveDirection > 0 ? BOARD_SIZE - 2 : 1); j != (tilesMoveDirection > 0 ? -1 : BOARD_SIZE); j -= tilesMoveDirection)
                    {
                        int currentY = horizontalMovement != 0 ? i : j;
                        int currentX = horizontalMovement != 0 ? j : i;

                        int targetY = currentY;
                        int targetX = currentX;

                        if (tilesCopy[currentY, currentX].Number == 0)
                        {
                            continue;
                        }

                        for (int rowMovement = (horizontalMovement != 0 ? currentX : currentY) + tilesMoveDirection;
                            rowMovement != (tilesMoveDirection > 0 ? BOARD_SIZE : -1); rowMovement += tilesMoveDirection)
                        {
                            int currentRowChange = horizontalMovement != 0 ? currentY : rowMovement;
                            int currentColChange = horizontalMovement != 0 ? rowMovement : currentX;

                            if (tilesCopy[currentRowChange, currentColChange].Number != 0 &&
                                tilesCopy[currentRowChange, currentColChange].Number != this.Tiles[currentRowChange, currentColChange].Number)
                            {
                                break;
                            }

                            if (horizontalMovement != 0)
                            {
                                targetX = rowMovement;
                            }
                            else
                            {
                                targetY = rowMovement;
                            }
                        }

                        if (horizontalMovement != 0 && targetX == currentX ||
                            verticalMovement != 0 && targetY == currentY)
                        {
                            continue;
                        }
                        else if (tilesCopy[targetY, targetX].Number == this.Tiles[currentY, currentX].Number)
                        {
                            tilesCopy[currentY, currentX].IsVisible = false;
                            tilesCopy[targetY, targetX].Number *= 2;
                            tilesCopy[targetY, targetX].IsVisible = true;
                            isBoardChanged = true;
                        }
                        else if (horizontalMovement != 0 && targetX != currentX ||
                            verticalMovement != 0 && targetY != currentY)
                        {
                            tilesCopy[currentY, currentX].IsVisible = false;
                            tilesCopy[targetY, targetX].Number = tilesCopy[currentY, currentX].Number;
                            tilesCopy[targetY, targetX].IsVisible = true;
                            isBoardChanged = true;
                        }

                        if (isBoardChanged)
                        {
                            tilesCopy[currentY, currentX].Number = 0;
                            tilesCopy[currentY, currentX].IsVisible = false;
                        }
                    }
                }
            }

            if (isBoardChanged)
            {
                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    for (int j = 0; j < BOARD_SIZE; j++)
                    {
                        this.Tiles[i, j].Number = tilesCopy[i, j].Number;
                        this.Tiles[i, j].IsVisible = tilesCopy[i, j].IsVisible;
                    }
                }
            }
        }
    }
}
