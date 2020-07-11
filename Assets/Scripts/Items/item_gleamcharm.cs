using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_gleamcharm : Item
{
    public GameObject ghostEffectPrefab;
    public GameObject hasteStatusPrefab;
    float hasteCooldown = 1f;
    float hasteCooldownTimer = 0f;
    void Start()
    {
        itemTier = 2;
        itemName = "Gleam charm";
        itemDesc = "u make ghost!! :0";
        itemType = "passive";
    }
    private void Update()
    {
        if (hasteCooldownTimer > 0)
        {
            hasteCooldownTimer -= Time.deltaTime;
        }
    }
    public override void passiveEffect(Entity control)
    {
        GameObject ghostInstance = Instantiate(ghostEffectPrefab, control.transform.position, control.transform.localRotation);
        ghostInstance.GetComponent<ghostTrail>().setGhostLeaderSr(control.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>());
    }
    public override void onBasicAttack(Entity control)
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
