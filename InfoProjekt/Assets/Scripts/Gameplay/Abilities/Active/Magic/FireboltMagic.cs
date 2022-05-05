using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Active.Magic
{
    public class FireboltMagic: MagicAbility
    {
        public override void Init(EventChannelSO inputChannel, GameObject parentObject, AbilityManager abilityManager)
        {
            Parent = parentObject;
        }

        public override void Update()
        {
            
        }
    }
}