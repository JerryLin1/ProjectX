using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Slash : Ability
{
    protected override float cooldown { get { return 0.5f; } }
    Vector3 mousePos;
    Vector2 direction;

    public GameObject crescentPrefab;

    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        this.mousePos = mousePos;
        this.direction = direction;
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= parent.transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        animator.SetTrigger("slashing");
        goOnCooldown();
    }

    public void createCrescent(float crescentScale) {
        // Create crescent in direction of mouse click
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= parent.transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        GameObject crescent = Instantiate(crescentPrefab, parent.GetComponent<Transform>().position, parent.GetComponent<Transform>().localRotation);
        crescent.transform.localScale = new Vector3(crescentScale, crescentScale, 0);
        crescent.transform.up = direction;
        crescent.GetComponent<Crescent>().setAttack(transform.root.gameObject, 8, 6f, 0.2f);        
    }
}