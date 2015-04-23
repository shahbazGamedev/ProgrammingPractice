using System;
using System.Threading;
using System.Text;
using System.IO;

namespace MemoryGame
{
    class Game
    {
        private static int currentXPos;
        private static int currentYPos;

        private static bool[] isTurned;

        private static ConsoleColor[] allColors;
        private static int[] squareColors;

        private static int spacebarsPressed;

        // for comparing squares:
        private static int xOfFirst;
        private static int yOfFirst;
        private static int xOfSecond;
        private static int yOfSecond;

        private static int countOfMoves;

        private static void InitializeConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WindowHeight = 25;
            Console.BufferHeight = Console.WindowHeight;
            Console.WindowWidth = 28;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

        private static void InitializeGameVars()
        {
            currentXPos = 1;
            currentYPos = 1;
            SetCursorOnSquare();

            spacebarsPressed = 0;

            isTurned = new bool[16];

            allColors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Magenta, 
                                         ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.DarkRed, ConsoleColor.DarkYellow,
                                         ConsoleColor.Gray, ConsoleColor.Black };

            squareColors = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };

            countOfMoves = 0;
        }

        private static void DrawASquare(int x, int y, int colorNumber)
        {
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 5; j++)
                {
                    Console.ForegroundColor = allColors[colorNumber];
                    Console.BackgroundColor = allColors[colorNumber];

                    Console.SetCursorPosition(j, i);
                    Console.Write('\u2588');
                }
            }
            Console.ForegroundColor = allColors[8]; // gray
            Console.BackgroundColor = allColors[9]; // black
        }

        private static void DrawAllSquares()
        {
            // move through flags:
            for (int currentXPos = 1; currentXPos < 20; currentXPos += 5)
            {
                for (int currentYPos = 1; currentYPos < 28; currentYPos += 7)
                {
                    DrawASquare(currentXPos, currentYPos, 8);
                }
            }
        }

        private static void ShuffleColors()
        {
            Random RNG = new Random();

            // shuffle algorithm for colors:
            for (int i = squareColors.Length; i > 0; i--)
            {
                int j = RNG.Next(i);
                int temp = squareColors[j];
                squareColors[j] = squareColors[i - 1];
                squareColors[i - 1] = temp;
            }
        }

        private static void InitializeScoreboard()
        {
            Console.SetCursorPosition(0, 20);
            Console.Write(new string('\u2500', 28));

            Console.SetCursorPosition(4, 22);
            Console.Write("Number of moves: ");

            Console.ForegroundColor = allColors[1]; // green
            Console.Write(countOfMoves);
            Console.ForegroundColor = allColors[8]; // gray
        }

        private static bool GameOverCondition()
        {
            bool isNotGameOver = true;

            for (int i = 0; i < isTurned.Length; i++)
            {
                if (!isTurned[i])
                {
                    isNotGameOver = false;
                }
            }
            return isNotGameOver;
        }

        private static void KeyHandler()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    RemoveCursorOnSquare();

                    currentXPos += 5;

                    if (currentXPos >= 20)
                    {
                        currentXPos -= 5;
                    }

                    SetCursorOnSquare();
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    RemoveCursorOnSquare();

                    currentXPos -= 5;
                    if (currentXPos <= 0)
                    {
                        currentXPos += 5;
                    }

                    SetCursorOnSquare();
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    RemoveCursorOnSquare();

                    currentYPos += 7;
                    if (currentYPos >= 28)
                    {
                        currentYPos -= 7;
                    }

                    SetCursorOnSquare();
                }
                else if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    RemoveCursorOnSquare();

                    currentYPos -= 7;
                    if (currentYPos <= 0)
                    {
                        currentYPos += 7;
                    }

                    SetCursorOnSquare();
                }
                else if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    ActionsAfterSpacebarPress();
                }
            }
        }

        private static void RemoveCursorOnSquare()
        {
            // top-left:
            Console.SetCursorPosition(currentYPos - 1, currentXPos - 1);
            Console.Write(' ');

            // top-right:
            Console.SetCursorPosition(currentYPos + 5, currentXPos - 1);
            Console.Write(' ');

            // bottom-left:
            Console.SetCursorPosition(currentYPos - 1, currentXPos + 3);
            Console.Write(' ');

            // bottom-right:
            Console.SetCursorPosition(currentYPos + 5, currentXPos + 3);
            Console.Write(' ');
        }

        private static void SetCursorOnSquare()
        {
            // top-left:
            Console.SetCursorPosition(currentYPos - 1, currentXPos - 1);
            Console.Write('\u250C');

            // top-right:
            Console.SetCursorPosition(currentYPos + 5, currentXPos - 1);
            Console.Write('\u2510');

            // bottom-left:
            Console.SetCursorPosition(currentYPos - 1, currentXPos + 3);
            Console.Write('\u2514');

            // bottom-right:
            Console.SetCursorPosition(currentYPos + 5, currentXPos + 3);
            Console.Write('\u2518');
        }

        private static int GetCurrentPositionOfSquare(int x, int y)
        {
            if (x == 1 && y == 1)
            {
                return 0;
            }
            else if (x == 1 && y == 8)
            {
                return 1;
            }
            else if (x == 1 && y == 15)
            {
                return 2;
            }
            else if (x == 1 && y == 22)
            {
                return 3;
            }
            else if (x == 6 && y == 1)
            {
                return 4;
            }
            else if (x == 6 && y == 8)
            {
                return 5;
            }
            else if (x == 6 && y == 15)
            {
                return 6;
            }
            else if (x == 6 && y == 22)
            {
                return 7;
            }
            else if (x == 11 && y == 1)
            {
                return 8;
            }
            else if (x == 11 && y == 8)
            {
                return 9;
            }
            else if (x == 11 && y == 15)
            {
                return 10;
            }
            else if (x == 11 && y == 22)
            {
                return 11;
            }
            else if (x == 16 && y == 1)
            {
                return 12;
            }
            else if (x == 16 && y == 8)
            {
                return 13;
            }
            else if (x == 16 && y == 15)
            {
                return 14;
            }
            else if (x == 16 && y == 22)
            {
                return 15;
            }
            else
            {
                // because it throws an error:
                return -1;
            }
        }

        private static void ActionsAfterSpacebarPress()
        {
            if (!isTurned[GetCurrentPositionOfSquare(currentXPos, currentYPos)])
            {
                DrawASquare(currentXPos, currentYPos, squareColors[GetCurrentPositionOfSquare(currentXPos, currentYPos)]);

                switch (spacebarsPressed)
                {
                    case 0:
                        xOfFirst = currentXPos;
                        yOfFirst = currentYPos;

                        spacebarsPressed = 1;
                        break;
                    case 1:
                        xOfSecond = currentXPos;
                        yOfSecond = currentYPos;

                        // if we haven't moved from the previous square:
                        if (xOfFirst == xOfSecond && yOfFirst == yOfSecond)
                        {
                            break;
                        }

                        Thread.Sleep(500);

                        CheckForColorMatch();

                        countOfMoves++;
                        DrawScoreboard();

                        spacebarsPressed = 0;
                        break;
                }
            }
        }

        private static void FadeOutEffect(int x, int y, int colorNumber, char symbol)
        {
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 5; j++)
                {
                    Console.ForegroundColor = allColors[colorNumber];
                    Console.BackgroundColor = allColors[9]; // black

                    Console.SetCursorPosition(j, i);
                    Console.Write(symbol);
                }
            }
        }

        private static void CheckForColorMatch()
        {
            int colorIndexOfFirst = GetCurrentPositionOfSquare(xOfFirst, yOfFirst);
            int colorIndexOfSecond = GetCurrentPositionOfSquare(xOfSecond, yOfSecond);

            if (squareColors[colorIndexOfFirst] == squareColors[colorIndexOfSecond])
            {
                // set these squares' colors to black:
                FadeOutEffect(xOfFirst, yOfFirst, squareColors[colorIndexOfFirst], '\u2593');
                Thread.Sleep(50);

                FadeOutEffect(xOfFirst, yOfFirst, squareColors[colorIndexOfFirst], '\u2592');
                Thread.Sleep(75);

                FadeOutEffect(xOfFirst, yOfFirst, squareColors[colorIndexOfFirst], '\u2591');
                Thread.Sleep(100);

                DrawASquare(xOfFirst, yOfFirst, 9);
                isTurned[GetCurrentPositionOfSquare(xOfFirst, yOfFirst)] = true;

                Thread.Sleep(25);

                FadeOutEffect(xOfSecond, yOfSecond, squareColors[colorIndexOfFirst], '\u2593');
                Thread.Sleep(50);
                FadeOutEffect(xOfSecond, yOfSecond, squareColors[colorIndexOfFirst], '\u2592');
                Thread.Sleep(75);
                FadeOutEffect(xOfSecond, yOfSecond, squareColors[colorIndexOfFirst], '\u2591');
                Thread.Sleep(100);
                DrawASquare(xOfSecond, yOfSecond, 9);
                isTurned[GetCurrentPositionOfSquare(xOfSecond, yOfSecond)] = true;
            }
            else
            {
                // set these squares' colors back to gray:
                DrawASquare(xOfFirst, yOfFirst, 8);
                DrawASquare(xOfSecond, yOfSecond, 8);
            }
        }

        private static void DrawScoreboard()
        {
            if (countOfMoves <= 8)
            {
                Console.ForegroundColor = allColors[1]; // green
            }
            else if (countOfMoves > 8 && countOfMoves < 16)
            {
                Console.ForegroundColor = allColors[5]; // yellow
            }
            else
            {
                Console.ForegroundColor = allColors[2]; // red
            }

            Console.SetCursorPosition(21, 22);
            Console.Write(countOfMoves);

            Console.ForegroundColor = allColors[8]; // gray
        }

        private static void AlterHighScores()
        {
            Console.Clear();
            Console.WindowHeight = 28;
            Console.WindowWidth = 31;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine(@"
  _____                       
 / ____|
| |  __  __ _ _ __ ___   ___  
| | |_ |/ _` | '_ ` _ \ / _ \
| |__| | (_| | | | | | |  __/
 \_____|\__,_|_| |_| |_|\___|
       / __ \
      | |  | \__   _____ _ __
      | |  | \ \ / / _ | '___|
      | |__| |\ V |  __| |
       \____/  \_/ \___|_|");
     
            Thread.Sleep(2000);

            Console.Clear();
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write("Enter your name: ");
            
            string name = Console.ReadLine();

            Console.CursorVisible = false;

            using (StreamWriter writer = File.AppendText("highscores.txt"))
            {
                writer.WriteLine(name + ": " + countOfMoves + " moves");
            }
        }

        public static void Start()
        {
            InitializeConsole();

            InitializeGameVars();

            DrawAllSquares();

            ShuffleColors();

            InitializeScoreboard();

            bool isGameOver = false;

            while (!isGameOver)
            {
                KeyHandler();

                isGameOver = GameOverCondition();
            }

            AlterHighScores();
        }
    }
}
