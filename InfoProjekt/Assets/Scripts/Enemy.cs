using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public override void die()
    {
        //play death animation
        Destroy(gameObject);
    }
}
