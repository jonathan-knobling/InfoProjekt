namespace Util.FSM
{
    public interface IStateHandler
    {
        void ChangeState(State state);
        State GetState();
    }
}