using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_watch : Item
{
    private float cooldownFactorReduction = 1f;

    public void Start() {
        tier = 3;
    }
    public override void onPickUpEffect(Entity control) {
        control.SetCooldownFactor(control.GetCooldownFactor() - cooldownFactorReduction);
    }
}
