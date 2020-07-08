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
    public virtual void Start()
    {
        customStart();
        currentHP = maxHP;
        animator = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    public virtual void customStart(){}

    
    public virtual float GetMovementSpeed() {return movementSpeed;}
    public virtual void SetMovementSpeed(float newMovementSpeed) {movementSpeed = newMovementSpeed;}
    public virtual float GetCooldownFactor() {return cooldownFactor;}
    public virtual void SetCooldownFactor(float newCooldownFactor) {cooldownFactor = newCooldownFactor;}
}
