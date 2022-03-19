using IO;
using Player;
using UnityEngine;

namespace Skills
{
    [RequireComponent(typeof(Stats))]
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private ActiveSkill[] activeSkills;
        [SerializeField] private InputChannelSO inputChannel;

        private void Start()
        {
            foreach (var skill in activeSkills)
            {
                skill.Init(inputChannel, gameObject);
            }
        }

        void Update()
        {
            foreach (var skill in activeSkills)
            {
                skill.Update();
            }
        }
    }
}
