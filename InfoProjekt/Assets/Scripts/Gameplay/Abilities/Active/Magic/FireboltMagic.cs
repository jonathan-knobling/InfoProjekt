using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Active.Magic
{
    public class FireboltMagic: MagicAbility
    {
        public override void Init(EventChannelSO eventChannel, GameObject parentObject)
        {
            Parent = parentObject;
        }

        public override void Update()
        {
            
        }
    }
}