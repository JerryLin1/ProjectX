using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAbility : MonoBehaviour
{
    // General method for attacks
    public void onEnterAttack() {
        transform.root.GetComponent<Player>().isAttacking = true;        
    }

    public void onExitAttack() {
        transform.root.GetComponent<Player>().isAttacking = false;
    }

    
    
    // Specific methods for rogue players

    public bool rogue_animationCancel;
    float rogue_attackIndex = 1f;
    public void rogue_attack() {
        
        if (rogue_animationCancel == true) {
            if (rogue_attackIndex == 1f) {
                GameObject.Find("Player/Abilities").GetComponent<abl_Slash>().createCrescent(1f);
            }
            transform.root.GetComponent<Player>().isAttacking = false;
            rogue_animationCancel = false;
            transform.GetComponent<Animator>().Rebind();
            rogue_attackIndex = 1f;
        } else {
            GameObject.Find("Player/Abilities").GetComponent<abl_Slash>().createCrescent((rogue_attackIndex > 1) ? rogue_attackIndex/2 : rogue_attackIndex);
            rogue_attackIndex ++;
            if (rogue_attackIndex == 4f) {
                rogue_attackIndex = 1;
            }
        }
    }

}
