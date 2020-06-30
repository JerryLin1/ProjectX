﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{

    public int tier;
    public string itemName;
    public string itemDesc;
    public virtual void onPickUpEffect(Entity control) {}
    public virtual void passiveEffect(Entity control) {}
    public virtual void onDamagedEffect(Entity control) {}
    public virtual void onHitEffect(Entity control) {}
}
