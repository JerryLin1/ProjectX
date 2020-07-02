using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    public int itemTier;
    public string itemName;
    public string itemDesc;
    public string itemType;
    public virtual void onPickUpEffect(Entity control) {}
    public virtual void passiveEffect(Entity control) {}
    public virtual void onDamagedEffect(Entity control) {}
    public virtual void onHitEffect(Entity control) {}

    public Sprite getItemSprite() {
        return transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }
}
