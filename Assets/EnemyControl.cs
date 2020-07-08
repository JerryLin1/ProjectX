using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Transform target;
    public Animator animator;

    float cooldown = 1f;
    float timer = 0f;

    void Start() {
        target = GameObject.Find("Player").transform;
    }
    
    void FixedUpdate()
    {

        transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        if (timer == 0f && Vector2.Distance(transform.position, target.transform.position) < 2f) {
            animator.SetTrigger("attack");
            timer += Time.deltaTime;
        } else {
            timer += Time.deltaTime;
            if (timer >= cooldown) timer = 0;
        } 
    }

}
