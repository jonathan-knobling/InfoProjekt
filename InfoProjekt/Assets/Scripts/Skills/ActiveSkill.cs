using IO;
using Skills.SkillStates;
using UnityEngine;

namespace Skills
{
    public abstract class ActiveSkill : ScriptableObject
    {

        [SerializeField] protected new string name;
        [SerializeField] protected float cooldown;
        [SerializeField] protected float activeTime;
        
        public SkillState State { get; private set; }
        public SkillStateReady ReadyState { get; private set; }
        public SkillStateActive ActiveState { get; private set; }
        public SkillStateCooldown CooldownState { get; private set; }

        //getter
        public string Name => name;
        public float Cooldown => cooldown;
        public float ActiveTime => activeTime;

        protected ActiveSkill()
        {
            ReadyState = new SkillStateReady();
            ActiveState = new SkillStateActive();
            CooldownState = new SkillStateCooldown();
            State = ReadyState;
        }

        public abstract void Update(InputChannelSO inputChannelSO, GameObject parent);

    }
}
