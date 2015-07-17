namespace PlazaSmash.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using PlazaSmash.Models;
    using PlazaSmash.Views;

    // CACHES ALL MODELS AND VIEWS IN ONE PLACE
    public static class BattlegroundController
    {
        private static Random rng;

        public static FighterModel FirstFighter { get; private set; }
        
        public static FighterModel SecondFighter { get; private set; }
        
        public static BackgroundView BgView { get; private set; }

        public static Dictionary<string, ViewObject> FirstFighterActions { get; private set; }
        
        public static Dictionary<string, ViewObject> SecondFighterActions { get; private set; }
        
        public static BackgroundModel BgModel { get; set; }
        
        public static HealthView FirstFighterHealth { get; set; }
        
        public static HealthView SecondFighterHealth { get; set; }

        public static bool DeadFighter { get; set; }

        public static bool FightSoundPlayed { get; set; }

        public static void DrawFighter(Dictionary<string, ViewObject> actions, FighterModel thisFighter, FighterModel otherFighter)
        {
            bool fighterIsIdle = true;

            foreach (var action in actions)
            {
                if (action.Value.ToBeDrawn)
                {
                    if (!action.Value.Drawn)
                    {
                        fighterIsIdle = false;

                        if (action.Key == "Hit")
                        {
                            thisFighter.GotHit(otherFighter.Damage);
                            thisFighter.HasBeenHit = false;
                        }

                        action.Value.Draw(thisFighter.Bounds);
                        break;
                    }
                    else
                    {
                        if (action.Key == "Die")
                        {
                            PlazaSmashGame.SM.ChangeState();
                        }

                        action.Value.ToBeDrawn = false;
                    }
                }
            }

            if (fighterIsIdle)
            {
                actions["Stand"].Draw(thisFighter.Bounds);
            }
        }
        
        public static void Initialize()
        {
            FightSoundPlayed = false;

            DeadFighter = false;

            rng = new Random();

            BgModel = new BackgroundModel(PickRandomBackground());

            FirstFighter = new FighterModel("Clark");
            SecondFighter = new FighterModel("Yuri");

            FirstFighterHealth = new HealthView(new Vector2(20, 20));
            SecondFighterHealth = new HealthView(new Vector2(PlazaSmashGame.WindowWidth - 100, 20));

            BgView = new BackgroundView(BgModel.Name);

            FirstFighterActions = new Dictionary<string, ViewObject>();
            FirstFighterActions.Add("Stand", new StandView(FirstFighter.Name));
            FirstFighterActions.Add("Move", new MoveView(FirstFighter.Name));
            FirstFighterActions.Add("ReversedMove", new ReversedMoveView(FirstFighter.Name));
            FirstFighterActions.Add("Punch", new PunchView(FirstFighter.Name));
            FirstFighterActions.Add("Kick", new KickView(FirstFighter.Name));
            FirstFighterActions.Add("Block", new BlockView(FirstFighter.Name)); // IMPLEMENT
            FirstFighterActions.Add("Hit", new HitView(FirstFighter.Name));
            FirstFighterActions.Add("Die", new DieView(FirstFighter.Name));

            SecondFighterActions = new Dictionary<string, ViewObject>();
            SecondFighterActions.Add("Stand", new StandView(SecondFighter.Name));
            SecondFighterActions.Add("Move", new MoveView(SecondFighter.Name));
            SecondFighterActions.Add("ReversedMove", new ReversedMoveView(SecondFighter.Name));
            SecondFighterActions.Add("Punch", new PunchView(SecondFighter.Name));
            SecondFighterActions.Add("Kick", new KickView(SecondFighter.Name));
            SecondFighterActions.Add("Block", new BlockView(SecondFighter.Name)); // IMPLEMENT
            SecondFighterActions.Add("Hit", new HitView(SecondFighter.Name));
            SecondFighterActions.Add("Die", new DieView(SecondFighter.Name));
        }

        public static void ResetViews(Dictionary<string, ViewObject> actions)
        {
            foreach (var action in actions)
            {
                if (action.Key != "Move" && action.Key != "ReversedMove")
                {
                    action.Value.ToBeDrawn = false;
                    action.Value.Drawn = true;
                    action.Value.CurrentImageIndex = 0;
                }
            }
        }

        private static string PickRandomBackground()
        {
            string[] backgrounds = { "Plaza", "PlazaNight" }; // CURRENTLY INSTALLED, DLC COMING SOON ;)

            return backgrounds[rng.Next(0, backgrounds.Length)];
        }
    }
}
