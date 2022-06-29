namespace Util.FSM.TransitionConditions
{
    public class FloatTransitionCondition: ITransitionCondition
    {
        private readonly Ref<float> value;
        private readonly float targetValue;
        private readonly Condition condition;

        public FloatTransitionCondition(ref float value, Condition condition, float targetValue)
        {
            this.value = new Ref<float>()
            {
                Value = value
            };
            this.targetValue = targetValue;
            this.condition = condition;
        }
        
        public bool IsMet()
        {
            switch (condition)
            {
                case Condition.Equal:
                    return value.Value.Equals(targetValue);
                case Condition.NotEqual:
                    return !value.Value.Equals(targetValue);
                case Condition.Greater:
                    return value.Value > targetValue;
                case Condition.Less:
                    return value.Value < targetValue;
                case Condition.GreaterEqual:
                    return value.Value >= targetValue;
                case Condition.LessEqual:
                    return value.Value <= targetValue;
                default:
                    return false;
            }
        }
    }
}