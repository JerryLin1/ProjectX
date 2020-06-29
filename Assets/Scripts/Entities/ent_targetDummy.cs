using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_targetDummy : Entity
{
    public override void customStart() {
        maxHP = 10000f;
        movementSpeed = 0f;
    }
}
