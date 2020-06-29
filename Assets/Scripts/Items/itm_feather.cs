using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itm_feather : Item
{
    private float movementSpeedMultiplier = 1.2f;
    public void Start() {
        tier = 3;
    }
    public override void onPickUpEffect(Entity control) {
        control.SetMovementSpeed(control.GetMovementSpeed() * movementSpeedMultiplier);
    }
}
