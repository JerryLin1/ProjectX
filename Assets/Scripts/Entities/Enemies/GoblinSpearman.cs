using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpearman : Enemy
{
    protected override void enemyCustomStart() {
        // Physics2D.IgnoreLayerCollision(10,10);
        maxHP = 10000;
        cooldown = 1.1f;
        timer = 0f;
        range = 2f;

        attackPrefabs[1].transform.localScale = new Vector3(0.75f, 0.75f, 0);
        attackPrefabs[1].GetComponent<crescentControl>().createCrescent(gameObject, 5);
    }

    void Update()
    {
        // Code to set activation range for enemy
        // if (Vector2.Distance(transform.position, target.position) > 3f) {
        //     rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // } else {
        //     rb.constraints = RigidbodyConstraints2D.None;
        // }
        if (!isAttacking) {
            animator.SetBool("moving", (GetComponent<Pathfinding.IAstarAI>().velocity != Vector3.zero) ? true : false);
            transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        } else {
            animator.SetBool("moving", false);
        }
        meleeAttack();
    }
        
        
      
        
    
        
        
    
}
