using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    public string statusName;
    public string statusType;
    // Default duration
    public float duration = 5f;
    
    // By default, there is no tickspeed. set this to something that will happen every x seconds (ie poison damage)
    public float tickSpeed;
    protected float tickTimer = 0;
    public bool stacks = false;
    public Entity target;
    public virtual void Start() {
        customStart();
    }
    public virtual void onApply(){}
    public virtual void Update() {
        duration -= Time.deltaTime;
        if (tickSpeed != 0) {
            tickTimer += Time.deltaTime;
            if (tickTimer >= tickSpeed) onTick();
        }
        if (duration <= 0) {
            onFinish();
            Destroy(gameObject);
        }
    }
    public virtual void onFinish(){}
    public virtual void onTick(){}
    public virtual void customStart() {}
}
