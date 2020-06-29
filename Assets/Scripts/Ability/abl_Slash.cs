using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Slash : Ability
{
    protected override float cooldown { get { return 0.5f; } }
    public GameObject crescentPrefab;
    public bool miniDash = false;
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {

        if (miniDash) transform.GetComponent<abl_Dash>().miniDash(mousePos, direction);
        

        animator.SetTrigger("shoot");
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        goOnCooldown();
        
    }
}