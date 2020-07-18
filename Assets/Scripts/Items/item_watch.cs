using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_watch : Item
{
    private float cooldownFactorReduction = 0.2f;

    public void Start() {
        itemTier = 2;
        itemName = "Pocketwatch";
        itemDesc = "You can use abilities more often.";
        itemType = "passive";
    }
    public override void onPickUpEffect(Entity control) {
        control.SetCooldownFactor(control.GetCooldownFactor() - cooldownFactorReduction);
    }
}
