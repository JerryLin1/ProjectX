using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_blinkdagger : Item
{
    void Start()
    {
        itemTier = 2;
        itemName = "Blink Dagger";
        itemDesc = "Throw a dagger. If it hits something, you can reactivate it to teleport to its position.";
        itemType = "active";
    }
}
