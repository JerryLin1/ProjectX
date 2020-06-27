using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Entity entityScript;
    Animator animator;
    Vector2 direction;
    Vector2 movement;
    Vector3 mousePos;

    void Start()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
        entityScript = gameObject.GetComponent<ent_player>();
        animator = gameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        checkInput();
        faceCursorWhileIdle();
    }

    void FixedUpdate()
    {
        entityScript.Move(movement);
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

    void faceCursorWhileIdle()
    {
        // Rotate player while idle
        if (movement.y == 0 && movement.x == 0) {
            animator.SetBool("idleForward", (direction.y < 0) ? true : false);
            transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        }
    }
}
