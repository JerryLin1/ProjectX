using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Entity
{
    ArrayList inventory = new ArrayList();
    Vector2 direction;
    Vector3 mousePos;
    public bool isAttacking;
    public Item nearbyItem;

    public override void customStart()
    {
        movementSpeed = 8f;
        maxHP = 100f;
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }
    public override void Update()
    {
        checkInput();
        faceCursorWhileIdle();
    }

    void FixedUpdate()
    {
        if (!isAttacking) Move(movement);
        else MeleeAttack();
    }
    public void checkInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();

        // Pick up item
        if (Input.GetKey(KeyCode.E) && nearbyItem != null)
        {
            inventoryPickup(nearbyItem);
            Destroy(nearbyItem.gameObject);
        }
    }

    void faceCursorWhileIdle()
    {
        // Rotate player while idle
        if (movement.y == 0 && movement.x == 0)
        {
            animator.SetBool("idleForward", (direction.y < 0) ? true : false);
            transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        }
    }

    public void inventoryPickup(Item item)
    {
        inventory.Add(item);
        item.onPickUpEffect(this);
    }
    public void inventoryTriggerPassiveItems()
    {
        // TODO: Constantly active items. I.E. Leave fire trail behind you
    }
    public void inventoryTriggerOnDamagedItems()
    {
        // TODO: Activated when player loses health. I.E. Create explosion
    }
    public void inventoryTriggerOnHitItems()
    {
        // TODO: Activated when player deals damage. I.E. Poison target
    }
    public void inventoryTriggerOnAbilityItems()
    {
        // TODO: Activated when player uses any ability. I.E. Send out bullets when dashing
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        nearbyItem = other.GetComponent<Item>();
    }
    
}
