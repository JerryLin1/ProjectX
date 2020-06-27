using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Entity
{
    protected override float maxHP { get { return 100f; } }
    protected override float movementSpeed { get { return 8f; } }
    Vector2 direction;
    Vector3 mousePos;

    public override void customStart()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }
    public override void Update()
    {
        checkInput();
        faceCursorWhileIdle();
    }

    void FixedUpdate()
    {
        Move(movement);
    }
    public void checkInput()
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
