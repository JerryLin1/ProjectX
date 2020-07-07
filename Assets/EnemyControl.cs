using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Transform target;
    public Animator animator;

 
    void Update()
    {
        transform.localRotation = (transform.position.x < target.position.x) ? Quaternion.Euler(0,180,0) : Quaternion.Euler(0,0,0); 
        if (Vector2.Distance(transform.position, target.transform.position) < 1f) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        } else {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

}
