using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_BlinkDagger : Ability
{
    // Start is called before the first frame update
    protected override float cooldown { get { return 0.5f; } }
    float reactivationWindow = 5f;
    public GameObject daggersPrefab;

    public override void Cast(Vector3 mousePos, Vector2 direction) {

        

        animator.SetTrigger("throw");
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        goOnCooldown();

    }

}
