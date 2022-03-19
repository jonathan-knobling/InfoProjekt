using Util;

namespace Skills.SkillStates
{
    public class SkillStateCooldown: SkillState
    {
        private Timer timer;
        private ActiveSkill parentSkill;
        
        public override void Update()
        {
            timer.Update();
        }

        public override void Activate(ActiveSkill skill)
        {
            parentSkill = skill;
            timer = new Timer(skill.CooldownTime);
            timer.OnElapsed += NextState;
        }

        public void NextState()
        {
            parentSkill.State = parentSkill.ReadyState;
            parentSkill.ReadyState.Activate(parentSkill);
        }
    }
}