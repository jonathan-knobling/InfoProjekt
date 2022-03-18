using IO;
using UnityEngine;

namespace Skills
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private ActiveSkill[] skills;
        [SerializeField] private InputChannelSO inputChannel;

        void Update()
        {
            foreach (var skill in skills)
            {
                skill.Update(inputChannel, gameObject);
            }
        }
    }
}
