using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 direction;
    Vector2 movement;
    Vector3 mousePos;
    float lastVelocity = 0;

    void Start()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }
    void Update()
    {
        checkInput();
    }

    void FixedUpdate()
    {
        Move();
    }
    void checkInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // If the player is basic attacking, set projectiles to travel to mouse location
    
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();
    }

    void Move()
    {
        if (movement.y != 0) lastVelocity = movement.y; 
        
        rb.velocity = movement * movementSpeed;
        animator.SetBool("up", (movement.y > 0) ? true : false);
        animator.SetBool("down", (movement.y < 0 || (movement.y == 0 && movement.x != 0)) ? true : false);
        animator.SetBool("idleForward", (lastVelocity < 0) ? true : false);

        // Rotate player while moving
        if (rb.velocity.x != 0) transform.localRotation = (rb.velocity.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

        // Rotate player while idle
        if (movement.y == 0 && movement.x == 0) {
            animator.SetBool("idleForward", (direction.y < 0) ? true : false);
            transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        }
    }
}
