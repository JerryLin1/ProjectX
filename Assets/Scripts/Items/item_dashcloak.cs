using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_dashcloak : Item
{
    // Start is called before the first frame update
    void Start()
    {
        itemTier = 3;
        itemName = "dash of cloak";
        itemDesc = "temporary stuff :>";
        itemType = "active";
    }
}
