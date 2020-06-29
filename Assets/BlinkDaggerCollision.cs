using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDaggerCollision : MonoBehaviour
{

    float destroyTimer = 0f;
    public bool collided = false;
    void Update() {
        destroyTimer += Time.deltaTime;
        if (!collided && destroyTimer > 1f) {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        collided = true;
    }
}
