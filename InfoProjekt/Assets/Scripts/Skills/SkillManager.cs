using UnityEngine;

namespace Skills
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private ActiveSkillSO[] skills;
        private float cooldownTime;
        private float activeTime;

        void Update()
        {
            for (int i = 0; i < skills.Length; i++)
            {
                switch (skills[i].state)
                {
                    case ActiveSkillSO.Skillstate.Ready:
                        if (Input.GetButtonDown($"Skill1"))
                        {
                            skills[i].Activate(gameObject);
                            skills[i].state = ActiveSkillSO.Skillstate.Active;
                            activeTime = skills[i].activeTime;
                        }
                        break;

                    case ActiveSkillSO.Skillstate.Active:
                        if (activeTime > 0)
                        {
                            activeTime -= Time.deltaTime;
                        }
                        else
                        {
                            skills[i].state = ActiveSkillSO.Skillstate.Cooldown;
                            cooldownTime = skills[i].cooldown;
                        }
                        break;

                    case ActiveSkillSO.Skillstate.Cooldown:
                        if (cooldownTime > 0)
                        {
                            cooldownTime -= Time.deltaTime;
                        }
                        else
                        {
                            skills[i].state = ActiveSkillSO.Skillstate.Ready;
                        }
                        break;
                }
            }
        }
    }
}
