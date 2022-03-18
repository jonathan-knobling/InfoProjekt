using Util;

namespace Skills.SkillStates
{
    public class SkillStateActive: SkillState
    {
        private Timer timer;
        
        public override void Update(ActiveSkill skill)
        {
            timer.Update();
        }

        public override void Activate(ActiveSkill skill)
        {
            timer = new Timer(skill.ActiveTime);
        }
    }
}