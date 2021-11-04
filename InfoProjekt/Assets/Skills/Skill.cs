using UnityEngine;

public class Skill : ScriptableObject
{

    public new string name;
    public float cooldown;
    public float activeTime;

    public enum Skillstate
    {
        ready,
        active,
        cooldown
    }
    public Skillstate state = Skillstate.ready;

    public virtual void Activate(GameObject parent) {}

}
