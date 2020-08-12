using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAttackAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public void createMeleeAttackAnimation() {
        transform.root.GetComponent<Enemy>().createMeleeAttackAnimation();
    }

    public void inMeleeAttack() {
        transform.root.GetComponent<Enemy>().isAttacking = true;
    }

    public void exitMeleeAttack() {
        transform.root.GetComponent<Enemy>().isAttacking = false;
    }

}
