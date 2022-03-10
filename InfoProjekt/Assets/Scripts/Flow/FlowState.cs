namespace Flow
{
    public interface IFlowState
    {
        void EnterState();
        void Update();
        void LeaveState();
    }
}