using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected Transform target;
    protected float cooldown;
    protected float timer;
    protected float range;
    public GameObject attackPrefab;

    protected override void customStart() {
        enemyCustomStart();
        target = GameObject.Find("Player").transform;
    }
    protected virtual void enemyCustomStart(){}
    protected virtual void meleeAttack() {
        transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        if (timer == 0f && Vector2.Distance(transform.position, target.transform.position) < range) {
            animator.SetTrigger("attack");
            GameObject attack = Instantiate(attackPrefab, transform.position, transform.localRotation);
            attack.transform.up = target.position - transform.position;
            timer += Time.deltaTime;
        } else {
            timer += Time.deltaTime;
            if (timer >= cooldown) timer = 0;
        } 
    }

}
