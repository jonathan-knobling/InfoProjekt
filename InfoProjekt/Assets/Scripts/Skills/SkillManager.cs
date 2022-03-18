using IO;
using UnityEngine;

namespace Skills
{
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private ActiveSkill[] skills;
        [SerializeField] private InputChannelSO inputChannel;

        private void Start()
        {
            foreach (var skill in skills)
            {
                skill.Init(inputChannel, gameObject);
            }
        }

        void Update()
        {
            foreach (var skill in skills)
            {
                skill.Update();
            }
        }
    }
}
