﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    GameObject activeItem;
    public List<GameObject> items = new List<GameObject>();
    Vector2 direction;
    Vector3 mousePos;
    PlayerAbilities playerAbilities;
    public bool isAttacking;
    List<GameObject> nearbyItems = new List<GameObject>();
    public hudControl hudControl;

    protected override void customStart()
    {
        movementSpeed = 5.5f;
        maxHP = 100f;
        playerAbilities = transform.GetChild(1).GetComponent<PlayerAbilities>();
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }
    protected override void customUpdate()
    {
        checkInput();
        inventoryTriggerPassiveItems();
    }

    void FixedUpdate()
    {
        if (isAttacking) MeleeAttack();
        else if (isBeingAttacked) return;
        else Move(movement);
    }
    void checkInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();

        // Pick up item
        if (Input.GetKeyDown(KeyCode.E) && nearbyItems.Count > 0)
        {
            pickupItem(nearbyItems[0]);
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

    void Move(Vector2 movement)
    {
        if (movement.y != 0) lastVelocity = movement.y;
        rb.velocity = movement * movementSpeed;
        animator.SetBool("moving", (rb.velocity == Vector2.zero) ? false : true);

        // Rotate entity while moving
        if (rb.velocity.x != 0) transform.localRotation = (rb.velocity.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

        // Rotate entity while idle
        if (movement.y == 0 && movement.x == 0 && !isAttacking) transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);

    }
    public void MeleeAttack() {
        animator.SetBool("moving", false);
        rb.velocity = Vector2.zero;
    }

    public void pickupItem(GameObject item)
    {
        Item itemScript = item.GetComponent<Item>();
        if (itemScript.itemType == "passive")
        {
            itemScript.onPickUpEffect(this);
            items.Add(item);
            hudControl.pickupPassiveItem(item);
            item.GetComponent<BoxCollider2D>().enabled = false;
            item.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (itemScript.itemType == "active")
        {
            if (activeItem != null)
            {
                activeItem.transform.position = transform.position;
                activeItem.GetComponent<BoxCollider2D>().enabled = true;
                activeItem.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            activeItem = item;
            hudControl.pickupActiveItem(item);
            setAbility(item.GetComponent<Item>().itemAbility, 4);
            item.GetComponent<BoxCollider2D>().enabled = false;
            item.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public void setAbility(Ability ability, int slot)
    {
        playerAbilities.abilities[slot] = ability;
        playerAbilities.abilities[slot].onEquip();
    }
    public void inventoryTriggerPassiveItems()
    {
        foreach (GameObject item in items) {
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
        // Add nearby items to a list
        GameObject i = other.gameObject;
        if (i.GetComponent<Item>())
            nearbyItems.Add(i);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Remove items that are too far away from the list
        GameObject i = other.gameObject;
        if (i.GetComponent<Item>())
            nearbyItems.Remove(i);
    }
}
