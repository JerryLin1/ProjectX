using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : StateMachineBehaviour {
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.transform.root.gameObject, stateInfo.length*stateInfo.speedMultiplier);
    }
}