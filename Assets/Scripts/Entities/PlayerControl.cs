﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : Entity
{
    ArrayList inventory = new ArrayList();
    Vector2 nextSlotPos = new Vector3(-400, -30, 0);
    Vector2 direction;
    Vector3 mousePos;
    public bool isAttacking;
    public GameObject nearbyItem;
    public hudControl hudControl;

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
        inventoryTriggerPassiveItems();
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
        }

        // Open inventory HUD
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (hudControl.isInventoryOpen())
                hudControl.closeInventory();
            else
                hudControl.openInventory();
        }
    }

    void faceCursorWhileIdle()
    {
        // Rotate player while idle
        if (movement.y == 0 && movement.x == 0 && !isAttacking)
        {
            animator.SetBool("idleForward", (direction.y < 0) ? true : false);
            transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        }
    }

    public void inventoryPickup(GameObject item)
    {
        hudControl.addItem(item);

        inventory.Add(item);
        item.GetComponent<Item>().onPickUpEffect(this);
        item.transform.position = new Vector3(-999999, -999999);
        item.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void inventoryTriggerPassiveItems()
    {
        foreach (GameObject item in inventory) {
            item.GetComponent<Item>().passiveEffect(this);
        }
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
        nearbyItem = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        nearbyItem = null;
    }
}
