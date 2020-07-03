﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected abstract float cooldown {get;}
    protected float currentCooldown = 0f;
    protected Transform parent;
    protected Animator animator;
    void Start()
    {
        
    }
    public virtual void onEquip() {
        parent = gameObject.transform.parent;
        animator = parent.transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
    }
    public abstract void Cast(Vector3 mousePos, Vector2 direction);

    // This method is for if the ability requires the mouse to be held down
    public virtual void Release() {}
    public virtual void goOnCooldown()
    {
        currentCooldown = cooldown * parent.GetComponent<Entity>().GetCooldownFactor();
    }
    public virtual void decreaseCooldown()
    {
        currentCooldown -= Time.deltaTime;
    }
    public bool onCooldown()
    {
        if (currentCooldown >= 0) return (true);
        else return (false);
    }
}
