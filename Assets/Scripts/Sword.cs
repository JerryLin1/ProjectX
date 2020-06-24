using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 mousePosition;
    private Vector2 direction;
    public Animator animator;

    void Update()
    {
        // faceMouse();
        swing();
    }
    void faceMouse() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();

        transform.right = direction;
    }

    void swing() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetBool("mousePress", true);
        } else {
            animator.SetBool("mousePress",false);
        }
    }
}
