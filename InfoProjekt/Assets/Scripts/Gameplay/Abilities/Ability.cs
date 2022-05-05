using UnityEngine;

namespace Gameplay.Abilities
{
    public abstract class Ability: ScriptableObject
    {
        public Sprite icon;
        
        public abstract void Update();
    }
}