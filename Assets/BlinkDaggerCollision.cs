using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDaggerCollision : MonoBehaviour
{
    public bool collided = false;
    public void OnCollisionEnter2D(Collision2D collision) {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        collided = true;
    }
}
