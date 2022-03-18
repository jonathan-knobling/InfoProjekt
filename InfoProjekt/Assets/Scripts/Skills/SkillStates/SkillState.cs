namespace Skills.SkillStates
{
    public abstract class SkillState
    {
        public abstract void Update();
        public abstract void Activate(ActiveSkill skill);
    }
}