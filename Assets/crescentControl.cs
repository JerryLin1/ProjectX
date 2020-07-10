using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crescentControl : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Vector2 attackOffset = new Vector2(0, 0.5f);
    public float hitboxRadius = 1;
    Collider2D[] hitEnemies;
    public Collider2D[] getHit() {
        Vector2 v = transform.position;
        hitEnemies = Physics2D.OverlapCircleAll(v+attackOffset, hitboxRadius, enemyLayers);
        return hitEnemies;
    }
    void OnDrawGizmosSelected() {
        Vector2 v = transform.position;
        Gizmos.DrawWireSphere(v + attackOffset, hitboxRadius);
    }
}
