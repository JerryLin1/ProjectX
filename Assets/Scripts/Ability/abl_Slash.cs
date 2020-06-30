using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Slash : Ability
{
    protected override float cooldown { get { return 0f; } }
    Vector3 mousePos;
    Vector2 direction;
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        this.mousePos = mousePos;
        this.direction = direction;
        
        

        animator.SetTrigger("slashing");
    }

    public void miniDash() {
        transform.GetComponent<abl_Dash>().miniDash(mousePos, direction);
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
    }
}