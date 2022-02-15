using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    protected int level;

    public abstract void die();
    public int GetLevel()
    {
        return level;
    }

}
