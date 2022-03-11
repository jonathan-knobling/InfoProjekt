using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private ActiveSkill[] skills;
    private float cooldownTime;
    private float activeTime;

    void Update()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            switch (skills[i].state)
            {
                case ActiveSkill.Skillstate.ready:
                    if (Input.GetButtonDown($"Skill1"))
                    {
                        skills[i].Activate(gameObject);
                        skills[i].state = ActiveSkill.Skillstate.active;
                        activeTime = skills[i].activeTime;
                    }
                    break;

                case ActiveSkill.Skillstate.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        skills[i].state = ActiveSkill.Skillstate.cooldown;
                        cooldownTime = skills[i].cooldown;
                    }
                    break;

                case ActiveSkill.Skillstate.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        skills[i].state = ActiveSkill.Skillstate.ready;
                    }
                    break;
            }
        }
    }
}
