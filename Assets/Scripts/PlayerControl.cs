using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject bulletPrefab;
    Vector2 direction;
    Vector2 movement;
    Vector3 mousePos;
    bool isAttacking = false;
    float timer = 0f;
    float waitTime = 1.25f;

    void Start()
    {
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }
    void Update()
    {
        checkInput();
        Shoot();
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
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            direction.Normalize();
        }
    }

    // Method called on last frame of attack animation
    void finishAttacking()
    {
        animator.SetBool("attacking", false);
        isAttacking = false;
    }

    void Move()
    {

        // The player can move while they're not attacking
        // Otherwise, they're forced to stay in position
        if (!isAttacking)
        {
            rb.velocity = movement * movementSpeed;
            animator.SetBool("horizontal", (movement.x != 0 && movement.y == 0) ? true : false);
            animator.SetInteger("idle", (movement.x != 0 && movement.y == 0) ? 0 : animator.GetInteger("idle"));
            animator.SetBool("up", (movement.y > 0) ? true : false);
            animator.SetInteger("idle", (movement.y > 0) ? 1 : animator.GetInteger("idle"));
            animator.SetBool("down", (movement.y < 0) ? true : false);
            animator.SetInteger("idle", (movement.y < 0) ? -1 : animator.GetInteger("idle"));
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("up", false);
            animator.SetBool("horizontal", false);
            animator.SetBool("down", false);
        }

        if (rb.velocity.x != 0) transform.localRotation = (rb.velocity.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
    }
    void Shoot()
    {
        // If the player is basic attacking, a projectile is released but the attack cooldown starts
        if (timer == 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), bullet.GetComponent<CapsuleCollider2D>());
                bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;
                Destroy(bullet, 1f);

                animator.SetBool("attacking", true);
                isAttacking = true;
                transform.localRotation = (mousePos.x >= transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
                timer = 0.01f;
            }
        }
        else if (timer > waitTime)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
}
