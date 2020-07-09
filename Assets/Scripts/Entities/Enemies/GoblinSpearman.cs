using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpearman : Enemy
{
    protected override void enemyCustomStart() {
        // Physics2D.IgnoreLayerCollision(10,10);
        cooldown = 1.1f;
        timer = 0f;
        range = 2f;
    }

    void Update()
    {
        if (!isAttacking) {
            transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        } 
        meleeAttack();
    }
        
        
      
        
    
        
        
    
}
