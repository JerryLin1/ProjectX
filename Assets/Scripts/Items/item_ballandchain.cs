using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_ballandchain : Item
{
    private float movementSpeedMultiplier = 0.5f;
    void Start()
    {
        itemTier = -1;
        itemName = "Ball and chain";
        itemDesc = "Decreases your movement speed and might do smthing l8r idk";
        itemType = "passive";
    }
    public override void onPickUpEffect(Entity control) {
        control.SetMovementSpeed(control.GetMovementSpeed() * movementSpeedMultiplier);
        // TODO: Increase damage maybe? Or defence?
    }
}
