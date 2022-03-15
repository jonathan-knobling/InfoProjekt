using UnityEngine;

namespace Skills
{
    public class ActiveSkillSO : ScriptableObject
    {

        public new string name;
        public float cooldown;
        public float activeTime;

        public enum Skillstate
        {
            Ready,
            Active,
            Cooldown
        }
        public Skillstate state = Skillstate.Ready;

        public virtual void Activate(GameObject parent) {}

    }
}
