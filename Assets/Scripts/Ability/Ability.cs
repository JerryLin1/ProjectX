using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected abstract float cooldown {get;}
    protected float currentCooldown = 0f;
    protected Transform parent;
    void Start()
    {
        parent = gameObject.transform.parent;
    }
    public abstract void Cast(Vector3 mousePos, Vector2 direction);
    public virtual void goOnCooldown()
    {
        currentCooldown = cooldown;
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
