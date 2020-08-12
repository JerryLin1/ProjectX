using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_lobsterclaw : Item
{
    public GameObject hasteStatusPrefab;
    void Start()
    {
        itemTier = 2;
        itemName = "Lobster Claw";
        itemDesc = "Slows enemies that you damage.";
        itemType = "passive";
    }

    public override void onHitEffect(Entity control, Entity enemy)
    {
        GameObject hasteInstance = Instantiate(hasteStatusPrefab);
        Haste hasteScript = hasteInstance.GetComponent<Haste>();
        hasteScript.duration = 1f;
        hasteScript.movementSpeedBonus = -5f;
        hasteScript.target = enemy;
        hasteScript.onApply();
    }
}
