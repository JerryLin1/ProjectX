using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crescentControl : MonoBehaviour
{
    int damage;
    GameObject user;

    void Start() {
        StartCoroutine(attackMissed());
        Destroy(gameObject, 0.5f);
    }

    public void createCrescent(GameObject user, int damage) {
        this.user = user;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D enemy) {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        if (user != null) {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemies") && user.layer != LayerMask.NameToLayer("Enemies")) {
                enemy.GetComponent<Entity>().takeDamage(damage);

                enemy.GetComponent<Pathfinding.AIPath>().canMove = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * 4f;
                enemy.GetComponent<Enemy>().knockback(difference);
                StartCoroutine(KnockCoroutine(enemy.GetComponent<Rigidbody2D>()));
            }
        }
        
    }
    
    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(.2f);

        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(.1f);
        enemy.GetComponent<Pathfinding.AIPath>().canMove = true;
        Destroy(gameObject);
    }

    private IEnumerator attackMissed() {
        yield return new WaitForSeconds(transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
