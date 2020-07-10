using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{
    protected float knockbackPower;
    protected float knockbackDuration;
    protected float animationDuration;
    protected float recoveryDuration = 0.2f;
    protected float extraDuration = 0.25f;
    protected int damage;
    protected GameObject attacker;

    void Start()
    {
        // Destroy and disable collider after specific duration
        animationDuration = transform.Find("Sprite").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, knockbackDuration+recoveryDuration+animationDuration+extraDuration);
        StartCoroutine(attackMissed());
    }

    // Should be called immediately after crescent creation
    public virtual void setAttack(GameObject attacker, int damage, float knockbackPower, float knockbackDuration) {
        this.attacker = attacker;
        this.damage = damage;

        this.knockbackDuration = knockbackDuration;
        this.knockbackPower = knockbackPower;
    }

    protected abstract void OnTriggerEnter2D(Collider2D enemy);

    protected virtual IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        // Knockback and prevent movement
        yield return new WaitForSeconds(knockbackDuration);
        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Allow movement and destroy attack projectile
        yield return new WaitForSeconds(recoveryDuration);
        enemy.GetComponent<Pathfinding.AIPath>().canMove = true;
        Destroy(gameObject);
    }

    protected virtual IEnumerator attackMissed() {

        // Disable collider at the end of animation
        yield return new WaitForSeconds(animationDuration);
        GetComponent<Collider2D>().enabled = false;
    }
}
