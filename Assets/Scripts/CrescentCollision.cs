using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrescentCollision : MonoBehaviour
{    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            Debug.Log("gotem");
            // collider.gameObject.TakeDamage(10);
        } else {
            Destroy(gameObject);
        }
    }
}
