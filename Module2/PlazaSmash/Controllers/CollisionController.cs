namespace PlazaSmash.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using PlazaSmash.Models;
    using PlazaSmash.Views;

    public static class CollisionController
    {
        // WINDOW BORDERS:
        public static void CheckForWindowCollisions(FighterModel fighter)
        {
            if (fighter.Bounds.Left <= 0 - (fighter.Bounds.Width / 4))
            {
                fighter.Move("collisionLeft");
            }
            else if (fighter.Bounds.Right - (fighter.Bounds.Width / 4) >= PlazaSmashGame.WindowWidth)
            {
                fighter.Move("collisionRight");
            }
        }

        public static void CheckForMovementCollision()
        {
            ViewObject secondFighterAction = GetFighterCurrentAction(BattlegroundController.SecondFighterActions);

            if (BattlegroundController.FirstFighter.Bounds.Contains(BattlegroundController.SecondFighter.Bounds))
            {
                BattlegroundController.FirstFighter.Move("collisionRight");

                BattlegroundController.SecondFighter.Move("collisionLeft");
            }
        }

        public static void CheckForAttackCollision(
            FighterModel thisFighter, 
            Dictionary<string, ViewObject> thisFighterActions,
            FighterModel otherFighter, 
            Dictionary<string, ViewObject> otherFighterActions)
        {
            // NEEDED FOR GetData()
            ViewObject otherFighterCurrentAction = GetFighterCurrentAction(otherFighterActions);

            if (thisFighterActions["Punch"].ToBeDrawn)
            {
                if (IsThereCollision(
                    thisFighter, 
                    thisFighterActions["Punch"].GetColorData(),
                    otherFighter, 
                    otherFighterCurrentAction.GetColorData()))
                {
                    if (!otherFighter.IsBlocking)
                    {
                        BattlegroundController.ResetViews(otherFighterActions);

                        if (thisFighter.Name == "Clark")
                        {
                            AudioController.PlaySound(AudioController.ClarkPunchInstance);
                        }
                        else if (thisFighter.Name == "Yuri")
                        {
                            AudioController.PlaySound(AudioController.YuriPunchInstance);
                        }

                        otherFighterActions["Hit"].ToBeDrawn = true;
                        otherFighterActions["Hit"].Drawn = false;
                    }
                    else
                    {
                        // ADD BLOCKING FUNCTIONALITY HERE
                        // AudioController.PlaySound(AudioController.BlockSoundInstance);
                    }

                    otherFighter.HasBeenHit = true;
                }
            }
            else if (thisFighterActions["Kick"].ToBeDrawn)
            {
                if (IsThereCollision(
                    thisFighter, 
                    thisFighterActions["Kick"].GetColorData(),
                    otherFighter, 
                    otherFighterCurrentAction.GetColorData()))
                {
                    if (!otherFighter.IsBlocking)
                    {
                        if (thisFighter.Name == "Clark")
                        {
                            AudioController.PlaySound(AudioController.ClarkKickInstance);
                        }
                        else if (thisFighter.Name == "Yuri")
                        {
                            AudioController.PlaySound(AudioController.YuriKickInstance);
                        }

                        BattlegroundController.ResetViews(otherFighterActions);

                        otherFighterActions["Hit"].ToBeDrawn = true;
                        otherFighterActions["Hit"].Drawn = false;
                    }
                    else
                    {
                        // ADD BLOCKING FUNCTIONALITY HERE
                        // AudioController.PlaySound(AudioController.BlockSoundInstance);
                    }

                    otherFighter.HasBeenHit = true;
                }
            }
        }

        // PIXEL PERFECT:
        private static bool IsThereCollision(
            FighterModel thisFighter, 
            Color[] thisColorData,
            FighterModel otherFighter, 
            Color[] otherColorData)
        {
            bool isThereCollision = false;

            // UNCOMMENT IF YOU DONT HAVE A GAMING RIG :D
            // if (thisFighter.Bounds.Contains(otherFighter.Bounds))
            // {
            // AND COMMENT THIS LINE:
            if (thisFighter.HitBounds.Intersects(otherFighter.HitBounds))
            {
                int top = Math.Max(thisFighter.HitBounds.Top, otherFighter.HitBounds.Top);
                int bottom = Math.Min(thisFighter.HitBounds.Bottom, otherFighter.HitBounds.Bottom);
                int left = Math.Max(thisFighter.HitBounds.Left, otherFighter.HitBounds.Left);
                int right = Math.Min(thisFighter.HitBounds.Right, otherFighter.HitBounds.Right);

                for (int y = top; y < bottom; y++)
                {
                    if (isThereCollision)
                    {
                        break;
                    }

                    for (int x = left; x < right; x++)
                    {
                        Color firstPixel = thisColorData[(x - thisFighter.HitBounds.Left) +
                            (thisFighter.HitBounds.Width * (y - thisFighter.HitBounds.Top))];

                        Color secondPixel = otherColorData[(x - otherFighter.HitBounds.Left) +
                            (otherFighter.HitBounds.Width * (y - otherFighter.HitBounds.Top))];

                        if (firstPixel.A != 0 && secondPixel.A != 0)
                        {
                            isThereCollision = true;
                            break;
                        }
                    }
                }
            }
            
            // }
            return isThereCollision;
        }

        private static ViewObject GetFighterCurrentAction(Dictionary<string, ViewObject> actions)
        {
            ViewObject currentAction = actions["Stand"];

            foreach (var action in actions)
            {
                if (action.Value.ToBeDrawn == true)
                {
                    currentAction = action.Value;
                    break;
                }
            }

            return currentAction;
        }
    }
}
