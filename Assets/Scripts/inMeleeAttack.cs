using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inMeleeAttack : MonoBehaviour
{
    public void onEnterAttack() {
        transform.root.GetComponent<PlayerControl>().isAttacking = true;
        transform.root.GetComponent<PlayerControl>().MeleeAttack();
    }

    public void onExitAttack() {
        transform.root.GetComponent<PlayerControl>().isAttacking = false;
    }
}
