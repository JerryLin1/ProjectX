using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_gleamcharm : Item
{
    public GameObject ghostEffectPrefab;
    void Start()
    {
        itemTier = 2;
        itemName = "Gleam charm";
        itemDesc = "u make ghost!! :0";
        itemType = "passive";
    }
    public override void passiveEffect(Entity control)
    {
        GameObject ghostInstance = Instantiate(ghostEffectPrefab, control.transform.position, control.transform.localRotation);
        ghostInstance.GetComponent<ghostTrail>().setGhostLeaderSr(control.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>());
    }
}
