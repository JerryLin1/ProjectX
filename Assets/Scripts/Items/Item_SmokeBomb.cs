using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SmokeBomb : Item
{
    // Start is called before the first frame update
    void Start()
    {
        itemTier = 3;
        itemName = "Smoke bomb";
        itemDesc = "temporary stuff :>";
        itemType = "active";
    }
}
