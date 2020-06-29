using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_targetDummy : Entity
{
    protected override float maxHP { get { return 10000f; } }
    void Start() {
        movementSpeed = 0f;
    }
}
