using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private Skill[] skills;
    private float cooldownTime;
    private float activeTime;

    void Update()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            switch (skills[i].state)
            {
                case Skill.Skillstate.ready:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        skills[i].Activate(gameObject);
                        skills[i].state = Skill.Skillstate.active;
                        activeTime = skills[i].activeTime;
                    }
                    break;

                case Skill.Skillstate.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        skills[i].state = Skill.Skillstate.cooldown;
                        cooldownTime = skills[i].cooldown;
                    }
                    break;

                case Skill.Skillstate.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        skills[i].state = Skill.Skillstate.ready;
                    }
                    break;
            }
        }
    }
}
