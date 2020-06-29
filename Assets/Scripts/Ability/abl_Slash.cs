using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Slash : Ability
{
    protected override float cooldown { get { return 0.5f; } }
    public GameObject crescentPrefab;
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        GameObject crescent = Instantiate(crescentPrefab, parent.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(crescent.GetComponent<PolygonCollider2D>(), parent.GetComponent<BoxCollider2D>());
        if (mousePos.x > parent.transform.position.x) crescent.transform.localScale = new Vector2(crescent.transform.localScale.x * -1, crescent.transform.localScale.y);
        crescent.GetComponent<Rigidbody2D>().AddForce(direction*500f);
        crescent.transform.up = direction;
        
        Destroy(crescent, 0.2f);

        animator.SetTrigger("shoot");
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        goOnCooldown();
        
    }
}