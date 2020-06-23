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
        if (movement.x != 0 || movement.y != 0) {
            animator.SetBool("isMoving", true);
        }
        else {
            animator.SetBool("isMoving", false);
        }
        if (movement.x > 0) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.x < 0) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
