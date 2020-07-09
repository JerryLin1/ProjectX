using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpearman : Enemy
{
    // Update is called once per frame

    protected override void enemyCustomStart() {
        cooldown = 1f;
        timer = 0f;
        range = 3f;
    }

    void Update()
    {
        meleeAttack();
    }
}
