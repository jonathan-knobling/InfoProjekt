using Util;

namespace Skills.Active.SkillStates
{
    public class SkillStateActive: SkillState
    {
        private Timer timer;
        private ActiveSkill parentSkill;
        
        public override void Update()
        {
            timer.Update();
        }

        public override void Activate(ActiveSkill skill)
        {
            timer = new Timer(skill.ActiveTime);
            parentSkill = skill;
            timer.OnElapsed += NextState;
        }

        private void NextState()
        {
            parentSkill.State = parentSkill.CooldownState;
            parentSkill.CooldownState.Activate(parentSkill);
        }
    }
}