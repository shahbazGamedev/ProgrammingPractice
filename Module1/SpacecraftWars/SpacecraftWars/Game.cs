using System;
using System.Collections.Generic;
using System.Threading;

class Game
{
    struct Characters
    {
        public List<char> topWings;
        public List<char> body;
        public List<char> bottomWings;

        public int topWingsPosition;
        public int bodyPosition;
        public int bottomWingsPosition;
    }

    struct Bullets
    {
        public int positionX;
        public int positionY;

        public bool isFired;
        public int count;
        public char symbol;
        public ConsoleColor color;
    }

    struct PowerUp
    {
        public int positionX;
        public int positionY;

        public int chanceToAppear;
        public bool hasAppeared;
        public char symbol;
        public ConsoleColor color;
    }

    private static Characters spacecraft = new Characters();

    private static Bullets bullet = new Bullets();

    private static PowerUp greenBullet = new PowerUp();

    private static PowerUp goldBullet = new PowerUp();

    private static Random RNG = new Random();

    private static bool isGameOver;

    public static void Main()
    {
        InitializeConsole();

        InitializeVars();

        DrawTopUI();
        DrawBottomUI();

        while (!isGameOver)
        {
            DrawShip();

            KeyHandler();

            DrawTopUI();

            Console.SetCursorPosition(0, 0);
            Console.Write("Bullets: " + bullet.count);
            if (bullet.isFired)
            {
                BulletLogic();
            }

            if (!greenBullet.hasAppeared)
            {
                greenBullet.hasAppeared = TryToCreateGreenBullet();
            }
            else
            {
                MoveGreenBullet();
            }

            if (!goldBullet.hasAppeared)
            {
                goldBullet.hasAppeared = TryToCreateGoldBullet();
            }
            else
            {
                MoveGoldBullet();
            }

            Console.SetCursorPosition(Console.WindowWidth - 31, Console.WindowHeight - 1);
            Console.Write("Score\\Difficulty: PRE-ALPHA :(");

            Thread.Sleep(50);
        }
    }

    private static void InitializeConsole()
    {
        Console.Title = "Spacecraft Wars";
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.CursorVisible = false;
    }

    private static void InitializeVars()
    {
        spacecraft.topWings = new List<char>();
        spacecraft.body = new List<char>();
        spacecraft.bottomWings = new List<char>();

        spacecraft.topWings.Add(' ');
        spacecraft.topWings.Add('\\');
        spacecraft.topWings.Add('\\');
        spacecraft.topWings.Add('\\');

        spacecraft.body.Add('=');
        spacecraft.body.Add('>');
        spacecraft.body.Add('=');
        spacecraft.body.Add('=');
        spacecraft.body.Add('-');
        spacecraft.body.Add('>');
        spacecraft.body.Add('>');

        spacecraft.bottomWings.Add(' ');
        spacecraft.bottomWings.Add('/');
        spacecraft.bottomWings.Add('/');
        spacecraft.bottomWings.Add('/');

        spacecraft.bodyPosition = Console.WindowHeight / 2;
        spacecraft.topWingsPosition = spacecraft.bodyPosition - 1;
        spacecraft.bottomWingsPosition = spacecraft.bodyPosition + 1;

        bullet.isFired = false;
        bullet.count = 3;
        bullet.symbol = 'O';
        bullet.color = ConsoleColor.Cyan;

        greenBullet.chanceToAppear = 400;
        greenBullet.hasAppeared = false;
        greenBullet.symbol = 'O';
        greenBullet.color = ConsoleColor.Green;

        goldBullet.chanceToAppear = 800;
        goldBullet.hasAppeared = false;
        goldBullet.symbol = 'O';
        goldBullet.color = ConsoleColor.Yellow;

        isGameOver = false;
    }

    private static void EraseShip()
    {
        Console.SetCursorPosition(0, spacecraft.topWingsPosition);
        Console.Write(new string(' ', spacecraft.topWings.Count));

        Console.SetCursorPosition(0, spacecraft.bodyPosition);
        Console.Write(new string(' ', spacecraft.body.Count));

        Console.SetCursorPosition(0, spacecraft.bottomWingsPosition);
        Console.Write(new string(' ', spacecraft.bottomWings.Count));
    }

    private static void DrawShip()
    {
        Console.SetCursorPosition(0, spacecraft.topWingsPosition);
        foreach (var symbol in spacecraft.topWings)
        {
            Console.Write(symbol);
        }

        Console.SetCursorPosition(0, spacecraft.bodyPosition);
        foreach (var symbol in spacecraft.body)
        {
            Console.Write(symbol);
        }

        Console.SetCursorPosition(0, spacecraft.bottomWingsPosition);
        foreach (var symbol in spacecraft.bottomWings)
        {
            Console.Write(symbol);
        }
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

            if (pressedKey.Key == ConsoleKey.UpArrow && spacecraft.topWingsPosition != 2)
            {
                EraseShip();

                spacecraft.bodyPosition -= 1;
                spacecraft.topWingsPosition = spacecraft.bodyPosition - 1;
                spacecraft.bottomWingsPosition = spacecraft.bodyPosition + 1;

                DrawShip();
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow && spacecraft.bottomWingsPosition != Console.WindowHeight - 3)
            {
                EraseShip();

                spacecraft.bodyPosition += 1;
                spacecraft.topWingsPosition = spacecraft.bodyPosition - 1;
                spacecraft.bottomWingsPosition = spacecraft.bodyPosition + 1;

                DrawShip();
            }
            else if (pressedKey.Key == ConsoleKey.Spacebar)
            {
                if (!bullet.isFired && bullet.count != 0)
                {
                    bullet.positionX = spacecraft.body.Count;
                    bullet.positionY = spacecraft.bodyPosition;
                    bullet.count -= 1;
                }
                bullet.isFired = true;
            }
        }
    }

    private static void BulletLogic()
    {
        Console.SetCursorPosition(bullet.positionX, bullet.positionY);
        Console.Write(' ');

        if (bullet.positionX + 1 != Console.WindowWidth)
        {
            bullet.positionX++;
            Console.ForegroundColor = bullet.color;
            Console.SetCursorPosition(bullet.positionX, bullet.positionY);
            Console.Write(bullet.symbol);
        }
        else
        {
            Console.SetCursorPosition(bullet.positionX, bullet.positionY);
            Console.Write(' ');
            bullet.isFired = false;
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static bool TryToCreateGreenBullet()
    {
        if (RNG.Next(0, greenBullet.chanceToAppear) == greenBullet.chanceToAppear / 2)
        {
            greenBullet.positionX = Console.WindowWidth - 1;
            greenBullet.positionY = RNG.Next(3, Console.WindowHeight - 2);
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void MoveGreenBullet()
    {
        if (greenBullet.positionX != 0)
        {
            if (greenBullet.positionX == spacecraft.topWings.Count && greenBullet.positionY == spacecraft.topWingsPosition ||
                greenBullet.positionX == spacecraft.body.Count && greenBullet.positionY == spacecraft.bodyPosition ||
                greenBullet.positionX == spacecraft.bottomWings.Count && greenBullet.positionY == spacecraft.bottomWingsPosition)
            {
                bullet.count++;

                Console.SetCursorPosition(greenBullet.positionX, greenBullet.positionY);
                Console.Write(' ');

                greenBullet.hasAppeared = false;
            }
            else
            {
                Console.SetCursorPosition(greenBullet.positionX, greenBullet.positionY);
                Console.Write(' ');

                greenBullet.positionX--;

                Console.ForegroundColor = greenBullet.color;
                Console.SetCursorPosition(greenBullet.positionX, greenBullet.positionY);
                Console.Write(greenBullet.symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.SetCursorPosition(greenBullet.positionX, greenBullet.positionY);
            Console.Write(' ');

            greenBullet.hasAppeared = false;
        }
    }

    private static bool TryToCreateGoldBullet()
    {
        if (RNG.Next(0, goldBullet.chanceToAppear) == goldBullet.chanceToAppear / 2)
        {
            goldBullet.positionX = Console.WindowWidth - 1;
            goldBullet.positionY = RNG.Next(3, Console.WindowHeight - 2);
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void MoveGoldBullet()
    {
        if (goldBullet.positionX != 0)
        {
            if (goldBullet.positionX == spacecraft.topWings.Count && goldBullet.positionY == spacecraft.topWingsPosition ||
                goldBullet.positionX == spacecraft.body.Count && goldBullet.positionY == spacecraft.bodyPosition ||
                goldBullet.positionX == spacecraft.bottomWings.Count && goldBullet.positionY == spacecraft.bottomWingsPosition)
            {
                bullet.count += 5;

                Console.SetCursorPosition(goldBullet.positionX, goldBullet.positionY);
                Console.Write(' ');

                goldBullet.hasAppeared = false;
            }
            else
            {
                Console.SetCursorPosition(goldBullet.positionX, goldBullet.positionY);
                Console.Write(' ');

                goldBullet.positionX--;

                Console.ForegroundColor = goldBullet.color;
                Console.SetCursorPosition(goldBullet.positionX, goldBullet.positionY);
                Console.Write(goldBullet.symbol);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.SetCursorPosition(goldBullet.positionX, goldBullet.positionY);
            Console.Write(' ');

            goldBullet.hasAppeared = false;
        }
    }

    private static void DrawTopUI()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.SetCursorPosition(i, 1);
            Console.Write('\u2500');
        }
    }

    private static void DrawBottomUI()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            Console.SetCursorPosition(i, Console.WindowHeight - 2);
            Console.Write('\u2500');
        }
    }
}




