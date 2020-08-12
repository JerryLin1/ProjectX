using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MeleeAttack
{
    
    protected override void OnTriggerEnter2D(Collider2D enemy) {
        gameObject.GetComponent<Collider2D>().enabled = false;
        if (attacker != null) {

            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies") && attacker.layer == LayerMask.NameToLayer("Players") && enemy.isTrigger) {
                enemy.GetComponent<Entity>().takeDamage(damage, attacker.GetComponent<Entity>());

                enemy.GetComponent<Pathfinding.AIPath>().canMove = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockbackPower;
                enemy.GetComponent<Entity>().knockback(difference);
                StartCoroutine(KnockCoroutine(enemy.GetComponent<Rigidbody2D>()));
                
            } 

            if (enemy.gameObject.layer == LayerMask.NameToLayer("Players") && attacker.layer == LayerMask.NameToLayer("Enemies") && enemy.isTrigger) {
                enemy.GetComponent<Entity>().takeDamage(damage, attacker.GetComponent<Entity>());

                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockbackPower;
                enemy.GetComponent<Entity>().isBeingAttacked = true;
                enemy.GetComponent<Entity>().knockback(difference);
                StartCoroutine(KnockCoroutine(enemy.GetComponent<Rigidbody2D>()));
            }

        }
    }

}
