using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_daggers : Item
{
    void Start()
    {
        itemTier = 3;
        itemName = "Daggers";
        itemDesc = "Unleashes a flurry of quick attacks.";
        itemType = "active";
    }

}
