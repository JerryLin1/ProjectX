using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpearman : Enemy
{
    // Update is called once per frame

    protected override void enemyCustomStart() {
        // Physics2D.IgnoreLayerCollision(10,10);
        cooldown = 1f;
        timer = 0f;
        range = 3f;
    }

    void Update()
    {
        meleeAttack();
    }
}
