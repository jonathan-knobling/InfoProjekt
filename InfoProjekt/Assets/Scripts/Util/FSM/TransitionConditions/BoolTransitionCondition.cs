namespace Util.FSM.TransitionConditions
{
    public class BoolTransitionCondition: ITransitionCondition
    {
        private readonly Ref<bool> value;
        private readonly bool targetValue;

        public BoolTransitionCondition(ref bool value, bool targetValue)
        {
            this.value = new Ref<bool>
            {
                Value = value
            };
            this.targetValue = targetValue;
        }
        
        public bool IsMet()
        {
            return (value.Value && targetValue) || (!value.Value && !targetValue);
        }
    }
}