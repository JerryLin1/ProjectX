using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Rigidbody2D rb;
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collisionObject)
    {

        Destroy(gameObject);

    }
}
