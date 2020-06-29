using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_BlinkDagger : Ability
{
    // Start is called before the first frame update
    protected override float cooldown { get { return 1.5f; } }
    float reactivationWindow = 5f;
    public GameObject daggersPrefab;
    GameObject dagger;

    void Update() {
        if (dagger != null && dagger.GetComponent<BlinkDaggerCollision>().collided == true) {
            reactivationWindow -= Time.deltaTime;
        }

        if (reactivationWindow <= 0) {
            Destroy(dagger);
            reactivationWindow = 5f;
            goOnCooldown();
        } 
    }
    public override void Cast(Vector3 mousePos, Vector2 direction) {

        if (reactivationWindow == 5f) {
            if (dagger != null) Destroy(dagger);
            dagger = Instantiate(daggersPrefab, parent.position, parent.localRotation);
            dagger.GetComponent<Rigidbody2D>().AddForce(direction * 500f);
            dagger.transform.up = direction;
            Physics2D.IgnoreCollision(dagger.GetComponent<BoxCollider2D>(), parent.GetComponent<BoxCollider2D>());

            animator.SetTrigger("throw");
            parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        } else {
            parent.position = dagger.transform.position;
            Destroy(dagger);
            reactivationWindow = 5f;
            goOnCooldown();
        }
        
        

    }

}
