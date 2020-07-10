using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crescent : MeleeAttack
{

    protected override void OnTriggerEnter2D(Collider2D enemy) {
        Debug.Log(attacker.name);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if (attacker != null) {

            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies") && attacker.layer != LayerMask.NameToLayer("Enemies")) {
                enemy.GetComponent<Entity>().takeDamage(damage);

                
                enemy.GetComponent<Pathfinding.AIPath>().canMove = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockbackPower;
                enemy.GetComponent<Enemy>().knockback(difference);
                StartCoroutine(KnockCoroutine(enemy.GetComponent<Rigidbody2D>()));
                
            } 

        }
        
    }
}
