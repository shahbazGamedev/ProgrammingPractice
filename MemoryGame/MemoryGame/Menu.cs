using System;
using System.IO;
using System.Text;
using System.Threading;

namespace MemoryGame
{
    class Menu
    {
        private static string[] mainMenu;
        private static int currentPosition;
        private static bool isExitPressed;

        private static void ShowIntro()
        {
            Console.CursorVisible = false;

            Console.WindowHeight = 28;
            Console.WindowWidth = 44;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   __  __                                  
  |  \/  |                                 
  | \  / | ___ _ __ ___   ___  _ __ _   _  
  | |\/| |/ _ | '_ ` _ \ / _ \| '__| | | | 
  | |  | |  __| | | | | | (_) | |  | |_| | 
  |_|  |_|\___|_| |_| |_|\___/|_|   \__, | 
        / ____|                      __/ | 
       | |  __  __ _ _ __ ___   ___ |___/  
       | | |_ |/ _` | '_ ` _ \ / _ \       
       | |__| | (_| | | | | | |  __/       
        \_____|\__,_|_| |_| |_|\___|       ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                 ___           
                | _ )_  _ 
                | _ | || |
                |___/\_, |
                     |__/");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
    _____ _          _                  
   |_   _| |_  ___  | |   ___ _ _  __ _ 
     | | | ' \/ -_) | |__/ _ | ' \/ _` |
     |_| |_||_\___| |____\___|_||_\__, |
           |_   ____ __ _ _ __    |___/ 
             | |/ -_/ _` | '  \         
             |_|\___\__,_|_|_|_|   
     ");
            Thread.Sleep(3500);
        }

        private static void InitializeConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WindowHeight = 25;
            Console.BufferHeight = Console.WindowHeight;
            Console.WindowWidth = 28;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

        private static void InitializeVars()
        {
            mainMenu = new string[] { " PLAY", " HOW TO PLAY", " HIGH SCORES", " EXIT" };

            currentPosition = 0;

            mainMenu[currentPosition] = mainMenu[currentPosition].Insert(0, "\u2192");

            isExitPressed = false;
        }

        private static void DrawMenu()
        {
            Console.SetCursorPosition(11, 7);
            Console.Write(mainMenu[0]);

            Console.SetCursorPosition(8, 9);
            Console.Write(mainMenu[1]);

            Console.SetCursorPosition(8, 11);
            Console.Write(mainMenu[2]);

            Console.SetCursorPosition(11, 13);
            Console.Write(mainMenu[3]);
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

                if (pressedKey.Key == ConsoleKey.DownArrow && currentPosition != mainMenu.Length - 1)
                {
                    currentPosition++;

                    mainMenu[currentPosition] = mainMenu[currentPosition].Insert(0, "\u2192");

                    mainMenu[currentPosition - 1] = mainMenu[currentPosition - 1].TrimStart('\u2192');
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow && currentPosition != 0)
                {
                    currentPosition--;

                    mainMenu[currentPosition] = mainMenu[currentPosition].Insert(0, "\u2192");

                    mainMenu[currentPosition + 1] = mainMenu[currentPosition + 1].TrimStart('\u2192');
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    CheckPressedButton();
                }
            }
        }

        private static void DrawHowToPlay()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\tHOW TO PLAY\n\n");
            Console.WriteLine(@"Use the ARROW KEYS to move
the cursor over a different           square.


Press the SPACEBAR key to        select a square.


Match 2 with the same color   and they will disappear.


Match all 16 squares to win          the game!


Try doing as fewer moves as          possible!");

            Console.ReadKey();
        }

        private static void DrawHighScores()
        {
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\t HIGH SCORES\n\n");

            if (!File.Exists("highscores.txt"))
            {
                File.Create("highscores.txt");   
            }
            else if (new FileInfo("highscores.txt").Length == 0)
            {
                Console.WriteLine("No highscore data was found!");
            }
            else
            {
                StreamReader reader = new StreamReader("highscores.txt");

                string line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);

                    line = reader.ReadLine();
                }
                reader.Close();
            }

            Console.ReadKey();
        }

        private static void CheckPressedButton()
        {
            if (currentPosition == 0)
            {
                Console.Clear();
                Game.Start();
            }
            else if (currentPosition == 1)
            {
                DrawHowToPlay();
            }
            else if (currentPosition == 2)
            {
                DrawHighScores();
            }
            else if (currentPosition == 3)
            {
                isExitPressed = true;
            }
        }

        public static void Display()
        {
            Console.Title = "Memory Game";

            ShowIntro();

            InitializeConsole();

            InitializeVars();

            while (!isExitPressed)
            {
                Console.Clear();

                DrawMenu();

                KeyHandler();

                Thread.Sleep(100);
            }
        }
    }
}
