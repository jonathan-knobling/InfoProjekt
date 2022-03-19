using IO;
using Skills.Active.SkillStates;
using UnityEngine;

namespace Skills.Active
{
    public abstract class ActiveSkill: ScriptableObject
    {

        protected new string name;
        protected float cooldownTime;
        protected float activeTime;
        protected GameObject Parent;
        
        protected internal SkillState State { get; set; }
        protected internal SkillStateReady ReadyState { get; }
        protected internal SkillStateCooldown CooldownState { get; }
        protected SkillStateActive ActiveState { get; }

        //getter
        public string Name => name;
        public float CooldownTime => cooldownTime;
        public float ActiveTime => activeTime;

        protected ActiveSkill()
        {
            ReadyState = new SkillStateReady();
            ActiveState = new SkillStateActive();
            CooldownState = new SkillStateCooldown();
            State = ReadyState;
            ReadyState.Activate(this);
        }

        public abstract void Init(InputChannelSO inputChannel, GameObject parent);
        public abstract void Update();
    }
}
