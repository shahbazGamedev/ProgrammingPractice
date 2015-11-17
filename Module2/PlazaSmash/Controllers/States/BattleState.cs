namespace PlazaSmash.Controllers.States
{
    public class BattleState : State
    {
        public BattleState(State nextState)
            : base(nextState)
        {
        }

        public override void Execute()
        {
            if (!BattlegroundController.FightSoundPlayed)
            {
                AudioController.PlaySound(AudioController.NarratorFightSoundInstance);
                BattlegroundController.FightSoundPlayed = true;
            }

            AudioController.PlaySound(AudioController.BattleSongInstance);
            InputController.CheckPlayerInput();

            CollisionController.CheckForWindowCollisions(BattlegroundController.FirstFighter);
            CollisionController.CheckForWindowCollisions(BattlegroundController.SecondFighter);

            CollisionController.CheckForMovementCollision();

            CollisionController.CheckForAttackCollision(
                BattlegroundController.FirstFighter, 
                BattlegroundController.FirstFighterActions,
                BattlegroundController.SecondFighter, 
                BattlegroundController.SecondFighterActions);

            CollisionController.CheckForAttackCollision(
                BattlegroundController.SecondFighter, 
                BattlegroundController.SecondFighterActions,
                BattlegroundController.FirstFighter, 
                BattlegroundController.FirstFighterActions);

            if (!BattlegroundController.DeadFighter)
            {
                if (BattlegroundController.FirstFighter.IsDead() || BattlegroundController.SecondFighter.IsDead())
                {
                    BattlegroundController.DeadFighter = true;
                    InputController.BlockInput = true;

                    if (BattlegroundController.FirstFighter.IsDead())
                    {
                        BattlegroundController.FirstFighterActions["Die"].ToBeDrawn = true;
                        BattlegroundController.FirstFighterActions["Die"].Drawn = false;
                    }
                    else
                    {
                        BattlegroundController.SecondFighterActions["Die"].ToBeDrawn = true;
                        BattlegroundController.SecondFighterActions["Die"].Drawn = false;
                    }
                }
            }
        }

        public override void Draw()
        {
            BattlegroundController.BgView.Draw(BattlegroundController.BgModel.Bounds);

            BattlegroundController.FirstFighterHealth.Draw(BattlegroundController.FirstFighter.Health.ToString());
            BattlegroundController.SecondFighterHealth.Draw(BattlegroundController.SecondFighter.Health.ToString());

            BattlegroundController.DrawFighter(BattlegroundController.FirstFighterActions, BattlegroundController.FirstFighter, BattlegroundController.SecondFighter);
            BattlegroundController.DrawFighter(BattlegroundController.SecondFighterActions, BattlegroundController.SecondFighter, BattlegroundController.FirstFighter);
        }
    }
}
