using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_targetDummy : Entity
{
    protected override float maxHP { get { return 10000f; } }
    protected override float movementSpeed { get { return 0f; } }
}
