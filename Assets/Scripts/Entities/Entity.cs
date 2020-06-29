using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float maxHP;
    protected float currentHP;
    protected float movementSpeed;
    public Rigidbody2D rb;

    protected Animator animator;
    public Vector2 movement;
    protected float cooldownFactor = 1f;
    protected float lastVelocity = 0;
    public virtual void Start()
    {
        customStart();
        currentHP = maxHP;
        animator = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public virtual void customStart(){}
    public virtual void Update(){}
    public virtual void Move(Vector2 movement)
    {
        if (movement.y != 0) lastVelocity = movement.y;
        rb.velocity = movement * movementSpeed;
        animator.SetBool("up", (movement.y > 0) ? true : false);
        animator.SetBool("down", (movement.y < 0 || (movement.y == 0 && movement.x != 0)) ? true : false);
        animator.SetBool("idleForward", (lastVelocity < 0) ? true : false);

        // Rotate entity while moving
        if (rb.velocity.x != 0) transform.localRotation = (rb.velocity.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
    }

    public virtual void MeleeAttack() {
        animator.SetBool("up", false);
        animator.SetBool("down", false);
        animator.SetBool("idleForward", false);
        rb.velocity = Vector2.zero;
    }

    public virtual float GetMovementSpeed() {return movementSpeed;}
    public virtual void SetMovementSpeed(float newMovementSpeed) {movementSpeed = newMovementSpeed;}
    public virtual float GetCooldownFactor() {return cooldownFactor;}
    public virtual void SetCooldownFactor(float newCooldownFactor) {cooldownFactor = newCooldownFactor;}
}
