using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAttack : MonoBehaviour
{
    // General methods for attacks
    public void onEnterAttack() {
        transform.root.GetComponent<PlayerControl>().isAttacking = true;
        transform.root.GetComponent<PlayerControl>().MeleeAttack();
    }

    public void onExitAttack() {
        transform.root.GetComponent<PlayerControl>().isAttacking = false;
    }

    // Specific methods for rogue players
    public void rogue_miniDash() {
        transform.root.GetChild(1).GetComponent<abl_Slash>().miniDash();
    }

    // public void rogue_cancelAttack() {
        // if (!Input.GetMouseButton(0)) {
        //     transform.root.GetComponent<PlayerControl>().isAttacking = false;
        //     transform.GetComponent<Animator>().Rebind();
        // }
    // }

}
