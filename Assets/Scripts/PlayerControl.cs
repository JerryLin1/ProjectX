using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update() {
        Move();
        faceMouse();
    }
    void Move() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); 
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    void faceMouse() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
