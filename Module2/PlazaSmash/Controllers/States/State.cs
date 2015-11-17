namespace PlazaSmash.Controllers.States
{
    public abstract class State
    {
        public State(State nextState)
        {
            this.NextState = nextState;
        }

        public State NextState { get; set; }

        public abstract void Execute();

        public virtual void Draw()
        {
        }
    }
}
