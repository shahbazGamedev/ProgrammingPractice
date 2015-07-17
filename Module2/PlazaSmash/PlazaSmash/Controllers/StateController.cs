namespace PlazaSmash.Controllers
{
    using System.Collections.Generic;
    using States;

    public class StateController
    {
        public State CurrentState { get; set; }

        public Dictionary<string, State> States { get; private set; }

        private IntroState IntroState { get; set; }
        
        private MenuState MenuState { get; set; }
        
        private BattleState BattleState { get; set; }

        public void Initialize()
        {
            this.States = new Dictionary<string, State>();

            this.BattleState = new BattleState(this.MenuState);
            this.MenuState = new MenuState(this.BattleState);
            this.IntroState = new IntroState(this.MenuState);
            this.BattleState.NextState = this.MenuState;

            this.States.Add("IntroState", this.IntroState);
            this.States.Add("MenuState", this.MenuState);
            this.States.Add("BattleState", this.BattleState);
        }

        public void ChangeState()
        {
            this.CurrentState = this.CurrentState.NextState;
        }
    }
}
