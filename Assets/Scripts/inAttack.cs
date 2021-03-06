﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inAttack : MonoBehaviour
{
    // General methods for attacks
    public void onEnterAttack() {
        transform.root.GetComponent<Player>().isAttacking = true;
    }

    public void onExitAttack() {
        transform.root.GetComponent<Player>().isAttacking = false;
    }

    // Specific methods for rogue players

    public bool rogue_animationCancel;
    public void rogue_miniDash() {
        
        if (rogue_animationCancel == true) {
            GameObject.Find("Player/Abilities").GetComponent<abl_Slash>().createCrescent(1f);
            transform.root.GetComponent<Player>().isAttacking = false;
            rogue_animationCancel = false;
            transform.GetComponent<Animator>().Rebind();
        } else {
            GameObject.Find("Player/Abilities").GetComponent<abl_Slash>().createCrescent(1f);
        }
    }

}
