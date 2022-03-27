using System.Collections;
using System.Collections.Generic;
using Inventory.Items;
using IO;
using UnityEngine;
using UnityEngine.UI;

public class OreDisplay : MonoBehaviour
{
    
    public Ore ore;

    public Image artwork;
    
    void Start()
    {
        artwork.sprite = ore.image;
      
    }

    
}
