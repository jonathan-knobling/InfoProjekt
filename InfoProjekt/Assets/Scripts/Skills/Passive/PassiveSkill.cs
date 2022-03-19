using IO;
using Player;
using UnityEngine;

namespace Skills.Passive
{
    public abstract class PassiveSkill: ScriptableObject
    {

        protected new string name;
        protected GameObject parent;
        protected Stats stats;
        
        //getter
        public string Name => name;

        public abstract void Init(InputChannelSO inputChannel, GameObject parentObject, Stats playerStats);
        public abstract void Update();
    }
}