using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_SmokeBomb : Ability
{
    protected override float cooldown {get {return 4f;} }
    public GameObject smokeBombPrefab;
    public GameObject hasteStatusPrefab;
   
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Cast(Vector3 mousePos, Vector2 direction) {
        GameObject smokeBomb = Instantiate(smokeBombPrefab, parent.transform.position, parent.transform.localRotation);
        
        GameObject hasteInstance = Instantiate(hasteStatusPrefab);
        Haste hasteScript = hasteInstance.GetComponent<Haste>();
        hasteScript.duration = 3f;
        hasteScript.movementSpeedBonus = 15f;
        hasteScript.target = parent.GetComponent<Entity>();
        hasteScript.onApply();

        Destroy(smokeBomb, 0.475f);
        goOnCooldown();
    }
}
