using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_BlinkDagger : Ability
{
    // Start is called before the first frame update
    protected override float cooldown { get { return 3.5f; } }
    float reactivationWindow = 5f;
    float destroyTimer = 0;
    bool resetDagger = false;

    public GameObject daggersPrefab;
    public GameObject teleportParticlesPrefab;
    GameObject dagger;

    void Update() {
        if (dagger != null) {
            if (dagger.GetComponent<BlinkDaggerCollision>().collided == false) {
                if (destroyTimer > 0) {
                    destroyTimer -= Time.deltaTime;
                } else if (destroyTimer < 0) {
                    destroyTimer = 0;
                    Destroy(dagger);
                    goOnCooldown();
                }
            }
            else {
                reactivationWindow -= Time.deltaTime;
            }
        }
        
        if (reactivationWindow <= 0) {
            Destroy(dagger);
            reactivationWindow = 5f;
            goOnCooldown();
        } 

        if (resetDagger == true) {
            Vector3 newPos = dagger.transform.GetChild(0).transform.position;
            GameObject teleportParticles1 = Instantiate(teleportParticlesPrefab, parent.position, parent.localRotation);
            Destroy(teleportParticles1, 0.3333f);
            
            parent.position = new Vector3(newPos.x, newPos.y+transform.root.GetComponent<BoxCollider2D>().size.y, newPos.z);
            GameObject teleportParticles2 = Instantiate(teleportParticlesPrefab, parent.position, parent.localRotation);
            Destroy(teleportParticles2, 0.3333f);
            
            Destroy(dagger);
            reactivationWindow = 5f;
            resetDagger = false;
            goOnCooldown();
        }
    }
    public override void Cast(Vector3 mousePos, Vector2 direction) {
        if (reactivationWindow == 5f && dagger == null) {
            dagger = Instantiate(daggersPrefab, parent.position, parent.localRotation);
            dagger.GetComponent<Rigidbody2D>().velocity = direction*15f;
            dagger.transform.up = direction;
            Physics2D.IgnoreCollision(dagger.GetComponent<BoxCollider2D>(), parent.GetComponent<BoxCollider2D>());

            destroyTimer = 1f;
            animator.SetTrigger("throw");
            parent.GetComponent<Transform>().localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        } else if (dagger.GetComponent<BlinkDaggerCollision>().collided) {
            resetDagger = true;
        }
    }
}
