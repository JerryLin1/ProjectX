using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{

    void Update()
    {
        Physics2D.IgnoreLayerCollision(9,8);
    }

    
    void OnCollisionEnter2D(Collision2D collisionObject) {
       
        Destroy(gameObject);
        
    }
}
