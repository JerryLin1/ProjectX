using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    bool isAttacking = false;

    void Update() {
        checkInput();
    }

    void FixedUpdate() {
        Move();
    }
    void checkInput() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); 

        // If the player is basic attacking:
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            animator.SetBool("attacking", true);
            isAttacking = true;
            transform.localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0,0,0);
        }
    }

    void finishAttacking() {
        animator.SetBool("attacking", false);
        isAttacking = false;
    }

    void Move() {
        if (!isAttacking) {
            rb.velocity = movement * movementSpeed;
            animator.SetBool("horizontal", (movement.x != 0 && movement.y == 0) ? true : false);
            animator.SetInteger("idle", (movement.x != 0 && movement.y == 0) ? 0 : animator.GetInteger("idle"));
            animator.SetBool("up", (movement.y > 0) ? true : false);
            animator.SetInteger("idle", (movement.y > 0) ? 1 : animator.GetInteger("idle"));
            animator.SetBool("down", (movement.y < 0) ? true : false);
            animator.SetInteger("idle", (movement.y < 0) ? -1 : animator.GetInteger("idle"));
        } else {
            rb.velocity = new Vector2(0,0);
            animator.SetBool("up", false);
            animator.SetBool("horizontal", false);
            animator.SetBool("down", false);
        }
        
    

        if (movement.x != 0) transform.localRotation = (movement.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0,0,0);
    }
    
}
