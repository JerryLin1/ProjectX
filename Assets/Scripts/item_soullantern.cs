using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_soullantern : Item
{
    public float healAmount = 10;
    void Start()
    {
        itemTier = 2;
        itemName = "Soul Lantern";
        itemDesc = "Killing enemies heals you for a small amount.";
        itemType = "passive";
    }
    public override void onKillEffect(Entity control) {
        control.heal(healAmount);
    }
}
