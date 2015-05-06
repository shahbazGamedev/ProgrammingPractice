using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    struct Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Snake
    {
        static Random RNG;

        static Queue<Position> snakeElements = new Queue<Position>();

        static Position snakeHead;

        static Position snakeNewHead;

        static Position[] directions = new Position[4];

        static byte directionIndex;
        static byte up;
        static byte down;
        static byte left;
        static byte right;

        static int lastFoodTime;
        static int foodDisappearTime;
        static Position food;

        static List<Position> obstacles = new List<Position>();
        static Position obstacle;

        static double sleepTime;
        static bool isGameOver;

        public static void Main()
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight = 25;
            Console.BufferWidth = Console.WindowWidth = 50;

            InitializeSnakeElements();

            while (!isGameOver)
            {
                InputHandler();

                MoveSnake();

                EatFoodLogic();

                GenerateFoodIfNotPickedUp();

                GameOverLogic();

                RedrawOldHead();

                DrawNewHead();

                snakeElements.Enqueue(snakeNewHead);

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        static void InitializeSnakeElements()
        {
            RNG = new Random();

            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            DrawSnakeBody();

            directions = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };

            directionIndex = 0;
            up = 3;
            down = 2;
            left = 1;
            right = 0;

            GenerateFood();
            lastFoodTime = Environment.TickCount;

            foodDisappearTime = 5000;
            DrawFood();

            for (int i = 0; i < 7; i++)
            { 
                GenerateNewObstacle();
            }

            DrawObstacles();

            sleepTime = 100;
            isGameOver = false;
        }
        
        static void InputHandler()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.RightArrow && directionIndex != left)
                {
                    directionIndex = right;
                }
                else if (userInput.Key == ConsoleKey.LeftArrow && directionIndex != right)
                {
                    directionIndex = left;
                }
                else if (userInput.Key == ConsoleKey.DownArrow && directionIndex != up)
                {
                    directionIndex = down;
                }
                else if (userInput.Key == ConsoleKey.UpArrow && directionIndex != down)
                {
                    directionIndex = up;
                }
            }    
        }
        
        static void MoveSnake()
        {
            snakeHead = snakeElements.Last();
            Position nextDirection = directions[directionIndex];
            snakeNewHead = new Position(snakeHead.row + nextDirection.row, 
                snakeHead.col + nextDirection.col);

            TeleportSnake();
        }
        
        static void EatFoodLogic()
        {
            if (food.row == snakeNewHead.row && food.col == snakeNewHead.col)
            {
                lastFoodTime = Environment.TickCount;
                GenerateFood();
                DrawFood();
                GenerateNewObstacle();
                DrawNewObstacle();
            }
            else
            {
                Position snakeTail = snakeElements.Dequeue();
                Console.SetCursorPosition(snakeTail.col, snakeTail.row);
                Console.Write(" ");
            }
        }
        
        static void GenerateFoodIfNotPickedUp()
        {
            if (Environment.TickCount - lastFoodTime >= foodDisappearTime)
            {
                Console.SetCursorPosition(food.col, food.row);
                Console.Write(" ");
                GenerateFood();
                DrawFood();
            }
        }

        static void GameOverLogic()
        {
            if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
            {
                isGameOver = true;
                Console.ReadKey();
            }
        }

        static void RedrawOldHead()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
            if (directionIndex == right)
            {
                Console.Write(">");
            }
            else if (directionIndex == left)
            {
                Console.Write("<");
            }
            else if (directionIndex == down)
            {
                Console.Write("v");
            }
            else
            {
                Console.Write("^");
            }
        }

        static void DrawNewHead()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(snakeHead.col, snakeHead.row);
            Console.Write('*');
        }

        static void GenerateNewObstacle()
        {
            do
            {
                obstacle = new Position(RNG.Next(0, Console.WindowHeight), 
                    RNG.Next(0, Console.WindowWidth));
            } while (snakeElements.Contains(obstacle) || obstacles.Contains(obstacle) || 
                food.row == obstacle.row && food.col == obstacle.col);

            obstacles.Add(obstacle);
        }

        static void DrawNewObstacle()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(obstacle.col, obstacle.row);
            Console.Write('$');
        }

        static void TeleportSnake()
        {
            if (snakeNewHead.col < 0)
            {
                snakeNewHead.col = Console.WindowWidth - 1;
            }
            else if (snakeNewHead.row < 0)
            {
                snakeNewHead.row = Console.WindowHeight - 1;
            }
            else if (snakeNewHead.col >= Console.WindowWidth)
            {
                snakeNewHead.col = 0;
            }
            else if (snakeNewHead.row >= Console.WindowHeight)
            {
                snakeNewHead.row = 0;
            }
        }

        static void DrawObstacles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (var obst in obstacles)
            {
                Console.SetCursorPosition(obst.col, obst.row);
                Console.Write('&');
            }
        }

        static void GenerateFood()
        {
            do
            {

                food = new Position(RNG.Next(0, Console.WindowHeight),
                    RNG.Next(0, Console.WindowWidth));

            } while (snakeElements.Contains(food) || obstacles.Contains(food));

            lastFoodTime = Environment.TickCount;
        }

        static void DrawFood()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(food.col, food.row);
            Console.Write('@');
        }

        static void DrawSnakeBody()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (Position element in snakeElements)
            {
                Console.SetCursorPosition(element.col, element.row);
                Console.Write('*');
            }
        }
    }
}
