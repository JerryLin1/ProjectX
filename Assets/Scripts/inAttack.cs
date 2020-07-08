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

    public bool rogue_animationCancel;
    public void rogue_miniDash() {
        
        if (rogue_animationCancel == true) {
            transform.root.GetComponent<PlayerControl>().isAttacking = false;
            rogue_animationCancel = false;
            transform.GetComponent<Animator>().Rebind();
        } else {
            GameObject.Find("Player/Abilities").GetComponent<abl_Slash>().miniDash(0.0125f, 50f, 1f);
        }
    }

}
