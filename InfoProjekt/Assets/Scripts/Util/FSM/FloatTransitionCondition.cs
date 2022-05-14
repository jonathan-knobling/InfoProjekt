namespace Util.FSM
{
    public class FloatTransitionCondition: ITransitionCondition
    {
        private readonly float value;
        private readonly float targetValue;
        private readonly Condition condition;

        public FloatTransitionCondition(float value, Condition condition, float targetValue)
        {
            this.value = value;
            this.targetValue = targetValue;
            this.condition = condition;
        }
        
        public bool IsMet()
        {
            switch (condition)
            {
                case Condition.Equal:
                    return value.Equals(targetValue);
                case Condition.NotEqual:
                    return !value.Equals(targetValue);
                case Condition.Greater:
                    return value > targetValue;
                case Condition.Less:
                    return value < targetValue;
                case Condition.GreaterEqual:
                    return value >= targetValue;
                case Condition.LessEqual:
                    return value <= targetValue;
                default:
                    return false;
            }
        }
    }
}