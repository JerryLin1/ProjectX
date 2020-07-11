using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : StatusEffect
{
    // Default movespeed bonus
    public float movementSpeedBonus = 5f;
    public override void onApply() {
        target.SetMovementSpeed(target.GetMovementSpeed()+movementSpeedBonus);
    }
    public override void onFinish() {
        target.SetMovementSpeed(target.GetMovementSpeed()-movementSpeedBonus);
    }
}
