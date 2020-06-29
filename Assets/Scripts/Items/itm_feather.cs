using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itm_feather : Item
{
    public override int tier { get { return 3; } }
    private float movementSpeedMultiplier = 2f;
    public override void onPickUpEffect(Entity control) {
        control.SetMovementSpeed(control.GetMovementSpeed() * movementSpeedMultiplier);
        
    }
}
