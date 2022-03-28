using System.Collections;
using System.Collections.Generic;
using Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

public class CollectableDisplay : MonoBehaviour
{
    
    public Collectable ore;

    public Image artwork;
    
    void Start()
    {
        artwork.sprite = ore.image;
      
    }

    
}
