using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    void Update() {
        checkInput();
    }

    void FixedUpdate() {
        Move();
    }
    void checkInput() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); 
    }
    
    void Move() {
        rb.velocity = movement * movementSpeed;
        animator.SetBool("horizontal", (movement.x != 0 && movement.y == 0) ? true : false);
        animator.SetBool("up", (movement.y > 0) ? true : false);
        animator.SetBool("down", (movement.y < 0) ? true : false);

        if (movement.x != 0) transform.localRotation = (movement.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0,0,0);
        
        
    }
}
