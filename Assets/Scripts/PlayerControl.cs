using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update() {
        Move();
    }
    void Move() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical"); 
        //CHANGE THIS TO VELOCITY
        rb.velocity = movement * movementSpeed;
    }
}
