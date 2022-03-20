using IO;
using UnityEngine;

namespace Abilities.Active.Magic
{
    public class FireboltMagic: MagicAbility
    {
        public override void Init(InputChannelSO inputChannel, GameObject parentObject)
        {
            parent = parentObject;
        }

        public override void Update()
        {
            
        }
    }
}