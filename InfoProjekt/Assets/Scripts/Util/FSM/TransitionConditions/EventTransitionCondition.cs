using System;
using System.ComponentModel;

namespace Util.FSM.TransitionConditions
{
    public class EventTransitionCondition: ITransitionCondition
    {
        private readonly Func<bool> isMet;
        
        public EventTransitionCondition(Func<bool> isMet)
        {
            this.isMet = isMet;
        }
        
        public bool IsMet()
        {
            return isMet();
        }

        public static ITransitionCondition[] SingleCondition(Func<bool> isMet)
        {
            var arr = new ITransitionCondition[1];
            arr[0] = new EventTransitionCondition(isMet);
            return arr;
        }
    }
}