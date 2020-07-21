using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected Transform target;
    protected float cooldown;
    protected float timer;
    protected float range;
    public GameObject[] attackPrefabs;
    public bool isAttacking;
    int attackAnimationIndex = 0;
    Vector2 attackDirection;

    protected override void customStart() {
        enemyCustomStart();
        target = GameObject.Find("Player").transform;
    }
    protected virtual void enemyCustomStart(){}

    protected virtual void meleeAttack() {

        if (timer == 0f && Vector2.Distance(transform.position, target.transform.position) < range) {
            animator.SetTrigger("attack");
            attackDirection = target.position-transform.position;
            timer += Time.deltaTime;
        } else if (timer > 0f) {
            timer += Time.deltaTime;
            if (timer >= cooldown) timer = 0;
        } 
    }
    public virtual void createMeleeAttackAnimation() {
        audioManager.Play("MeleeAttack");
        GameObject attackAnimation = Instantiate(attackPrefabs[attackAnimationIndex], transform.position, transform.localRotation);
        attackAnimation.transform.up = attackDirection;
        attackAnimation.GetComponent<MeleeAttack>().setAttack(gameObject, 2, 10f, 0.2f);

        attackAnimationIndex ++;
        if (attackAnimationIndex == attackPrefabs.Length) {
            attackAnimationIndex = 0;
        }
    }

}
