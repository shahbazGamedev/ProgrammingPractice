namespace PlazaSmash.Controllers
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;
    using PlazaSmash.Models;
    using PlazaSmash.Views;

    public static class InputController
    {
        // FOR WHEN A FIGHER IS DYING
        public static bool BlockInput { get; set; }

        private static KeyboardState PreviousKeyboardState { get; set; }

        private static Keys[] FirstFighterKeys { get; set; }

        private static Keys[] SecondFighterKeys { get; set; }

        public static void CheckPlayerInput()
        {
            Keys[] currentPressedKeys = Keyboard.GetState().GetPressedKeys();

            DetermineInput(FirstFighterKeys, currentPressedKeys, BattlegroundController.FirstFighter, BattlegroundController.FirstFighterActions);

            DetermineInput(SecondFighterKeys, currentPressedKeys, BattlegroundController.SecondFighter, BattlegroundController.SecondFighterActions);

            PreviousKeyboardState = Keyboard.GetState();
        }

        public static void Initialize()
        {
            BlockInput = false;

            FirstFighterKeys = new Keys[] 
            {
                Keys.A,
                Keys.D,
                Keys.H,
                Keys.J,
                //// ADD KEY FOR BLOCKING
            };

            SecondFighterKeys = new Keys[] 
            {
                Keys.Left,
                Keys.Right,
                Keys.NumPad4,
                Keys.NumPad5,
                //// ADD KEY FOR BLOCKING
            };
        }

        private static void DetermineInput(Keys[] fighterKeys, Keys[] currentPressedKeys, FighterModel fighter, Dictionary<string, ViewObject> actions)
        {
            if (actions["Hit"].Drawn)
            {
                if (!BlockInput)
                {
                    foreach (Keys pressedKey in currentPressedKeys)
                    {
                        if (pressedKey == fighterKeys[0])
                        {
                            BattlegroundController.ResetViews(actions);

                            fighter.Move("left");

                            actions["Move"].ToBeDrawn = true;
                            actions["Move"].Drawn = false;

                            for (int i = 0; i < currentPressedKeys.Length; i++)
                            {
                                if (currentPressedKeys[i] == fighterKeys[1] || currentPressedKeys[i] == fighterKeys[2] ||
                                    currentPressedKeys[i] == fighterKeys[2])
                                {
                                    currentPressedKeys[i] = Keys.None;
                                }
                            }
                        }
                        else if (pressedKey == fighterKeys[1])
                        {
                            BattlegroundController.ResetViews(actions);

                            fighter.Move("right");

                            actions["ReversedMove"].ToBeDrawn = true;
                            actions["ReversedMove"].Drawn = false;

                            for (int i = 0; i < currentPressedKeys.Length; i++)
                            {
                                if (currentPressedKeys[i] == fighterKeys[0] || currentPressedKeys[i] == fighterKeys[2] ||
                                    currentPressedKeys[i] == fighterKeys[3])
                                {
                                    currentPressedKeys[i] = Keys.None;
                                }
                            }
                        }
                        else if (pressedKey == fighterKeys[2] && !PreviousKeyboardState.IsKeyDown(fighterKeys[2]))
                        {
                            fighter.Punch();

                            // TO REDUCE INPUT DELAY:
                            actions["Move"].Drawn = true;
                            actions["ReversedMove"].Drawn = true;

                            actions["Punch"].ToBeDrawn = true;
                            actions["Punch"].Drawn = false;

                            for (int i = 0; i < currentPressedKeys.Length; i++)
                            {
                                if (currentPressedKeys[i] == fighterKeys[0] || currentPressedKeys[i] == fighterKeys[1] ||
                                    currentPressedKeys[i] == fighterKeys[3])
                                {
                                    currentPressedKeys[i] = Keys.None;
                                }
                            }
                        }
                        else if (pressedKey == fighterKeys[3] && !PreviousKeyboardState.IsKeyDown(fighterKeys[3]))
                        {
                            fighter.Kick();

                            actions["Move"].Drawn = true;
                            actions["ReversedMove"].Drawn = true;

                            actions["Kick"].ToBeDrawn = true;
                            actions["Kick"].Drawn = false;

                            for (int i = 0; i < currentPressedKeys.Length; i++)
                            {
                                if (currentPressedKeys[i] == fighterKeys[0] || currentPressedKeys[i] == fighterKeys[1] ||
                                    currentPressedKeys[i] == fighterKeys[2])
                                {
                                    currentPressedKeys[i] = Keys.None;
                                }
                            }
                        }

                        // ADD BLOCKING FUNCTIONALITY HERE
                    }
                }
            }
        }
    }
}
