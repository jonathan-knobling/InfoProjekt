namespace Util.FSM
{
    public interface IStateHandler
    {
        void ChangeState(State newState);
        State GetState();
    }
}