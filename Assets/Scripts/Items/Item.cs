﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    public int itemTier;
    public string itemName;
    public string itemDesc;
    public string itemType;
    public Ability itemAbility;
    public virtual void onPickUpEffect(Entity control) {}
    public virtual void passiveEffect(Entity control) {}
    public virtual void onDamagedEffect(Entity control, Entity source) {}
    public virtual void onHealEffect(Entity control) {}
    public virtual void onAbility(Entity control) {}
    public virtual void onHitEffect(Entity control, Entity enemy) {}
    public virtual void onKillEffect (Entity control) {}
    public Sprite getItemSprite() {
        return transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}
