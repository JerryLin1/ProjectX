using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float maxHP;
    protected float currentHP;
    protected float movementSpeed;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Vector2 movement;
    protected float cooldownFactor = 1f;
    protected float lastVelocity = 0;
    public bool isBeingAttacked;


    protected virtual void Start()
    {
        customStart();
        currentHP = maxHP;
        animator = transform.Find("Sprites/Body").GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    protected virtual void customStart(){}

    public virtual void knockback(Vector2 force) {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public virtual void takeDamage(float damage) {
        currentHP -= damage;
        if (currentHP <= 0) {
            Destroy(gameObject);
        }
    }
    public virtual float GetMovementSpeed() {return movementSpeed;}
    public virtual void SetMovementSpeed(float newMovementSpeed) {movementSpeed = newMovementSpeed;}
    public virtual float GetCooldownFactor() {return cooldownFactor;}
    public virtual void SetCooldownFactor(float newCooldownFactor) {cooldownFactor = newCooldownFactor;}
}
