using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Bullet : Ability
{
    public GameObject bulletPrefab;
    protected override float cooldown { get { return 1.25f; } }
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(parent.GetComponent<BoxCollider2D>(), bullet.GetComponent<CapsuleCollider2D>());
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;
        Destroy(bullet, 1f);

        parent.GetComponent<Animator>().SetTrigger("shoot");
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        goOnCooldown();
    }
}