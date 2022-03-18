namespace Skills.SkillStates
{
    public abstract class SkillState
    {
        public abstract void Update(ActiveSkill skill);
        public abstract void Activate(ActiveSkill skill);
    }
}