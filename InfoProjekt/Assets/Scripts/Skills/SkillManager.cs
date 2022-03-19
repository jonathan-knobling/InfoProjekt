using IO;
using Player;
using Skills.Active;
using Skills.Passive;
using UnityEngine;

namespace Skills
{
    [RequireComponent(typeof(Stats))]
    public class SkillManager : MonoBehaviour
    {
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private ActiveSkill[] activeSkills;
        [SerializeField] private PassiveSkill[] passiveSkills;

        private Stats stats;
        
        private void Start()
        {
            stats = GetComponent<Stats>();
            
            foreach (var skill in activeSkills)
            {
                skill.Init(inputChannel, gameObject);
            }

            foreach (var skill in passiveSkills)
            {
                skill.Init(inputChannel, gameObject, stats);
            }
        }

        void Update()
        {
            foreach (var skill in activeSkills)
            {
                skill.Update();
            }

            foreach (var skill in passiveSkills)
            {
                skill.Update();
            }
        }
    }
}
