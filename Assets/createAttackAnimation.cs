using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAttackAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public void createMeleeAttackAnimation() {
        transform.root.GetComponent<Enemy>().createMeleeAttackAnimation();
    }

}
