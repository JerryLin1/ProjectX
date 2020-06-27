using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ent_player : Entity
{
    protected override float maxHP { get { return 100f; } }
    protected override float movementSpeed { get { return 8f; } }

}
