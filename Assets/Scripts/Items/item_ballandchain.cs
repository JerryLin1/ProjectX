using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_ballandchain : Item
{
    private float movementSpeedMultiplier = 0.5f;
    void Start()
    {
        tier = -1;
    }
    public override void onPickUpEffect(Entity control) {
        control.SetMovementSpeed(control.GetMovementSpeed() * movementSpeedMultiplier);
        // TODO: Increase damage maybe? Or defence?
    }
}
