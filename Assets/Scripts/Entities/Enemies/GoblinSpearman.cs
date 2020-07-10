using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpearman : Enemy
{
    protected override void enemyCustomStart() {
        // Physics2D.IgnoreLayerCollision(10,10);
        maxHP = 50;
        cooldown = 1.1f;
        timer = 0f;
        range = 1f;

        attackPrefabs[1].transform.localScale = new Vector3(0.75f, 0.75f, 0);
        attackPrefabs[1].GetComponent<Crescent>().setCrescent(gameObject, 5, 2f, 0.2f);
    }

    void Update()
    {
        if (!isAttacking) {
            animator.SetBool("moving", (GetComponent<Pathfinding.IAstarAI>().velocity != Vector3.zero) ? true : false);
            transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        } else {
            animator.SetBool("moving", false);
        }
        meleeAttack();
    }
        
        
      
        
    
        
        
    
}
