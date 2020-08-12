using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_gleamcharm : Item
{
    public GameObject hasteStatusPrefab;
    float hasteCooldown = 1f;
    float hasteCooldownTimer = 0f;
    void Start()
    {
        itemTier = 2;
        itemName = "Gleam charm";
        itemDesc = "Briefly increases movement speed when an ability is casted.";
        itemType = "passive";
    }
    private void Update()
    {
        if (hasteCooldownTimer > 0)
        {
            hasteCooldownTimer -= Time.deltaTime;
        }
    }
    public override void onAbility(Entity control)
    {
        if (hasteCooldownTimer <= 0)
        {
            hasteCooldownTimer = hasteCooldown;
            GameObject hasteInstance = Instantiate(hasteStatusPrefab);
            Haste hasteScript = hasteInstance.GetComponent<Haste>();
            hasteScript.duration = 1f;
            hasteScript.movementSpeedBonus = 5f;
            hasteScript.target = control;
            hasteScript.onApply();
        }
    }
}
