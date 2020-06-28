using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_pickUpItem : Ability
{
    protected override float cooldown {get { return 0f;}}
    public override void Cast(Vector3 mousePos, Vector2 direction) {
        Item item = parent.GetComponent<PlayerControl>().nearbyItem;
        if (item != null) parent.GetComponent<PlayerControl>().inventoryPickup(item);
    }
}
