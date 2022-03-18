using IO;
using Skills.SkillStates;
using UnityEngine;

namespace Skills
{
    public abstract class ActiveSkill : ScriptableObject
    {

        [SerializeField] protected new string name;
        [SerializeField] protected float cooldownTime;
        [SerializeField] protected float activeTime;
        protected GameObject Parent;
        
        public SkillState State { get; internal set; }
        public SkillStateReady ReadyState { get; private set; }
        public SkillStateActive ActiveState { get; private set; }
        public SkillStateCooldown CooldownState { get; private set; }

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
        public abstract void OnSkillButtonPressed();

    }
}
