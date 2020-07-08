using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : Entity
{
    GameObject activeItem;
    List<GameObject> items = new List<GameObject>();
    Vector2 direction;
    Vector3 mousePos;
    PlayerAbilities playerAbilities;
    public bool isAttacking;
    List<GameObject> nearbyItems = new List<GameObject>();
    public hudControl hudControl;

    public override void customStart()
    {
        movementSpeed = 8f;
        maxHP = 100f;
        playerAbilities = transform.GetChild(1).GetComponent<PlayerAbilities>();
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

    void faceCursorWhileIdle()
    {
        // Rotate player while idle
        if (movement.y == 0 && movement.x == 0 && !isAttacking)
        {
            animator.SetBool("idleForward", (direction.y < 0) ? true : false);
            transform.localRotation = (direction.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        }
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
        // TODO: Passive effects that are always active. would use item class's passiveEffect() method
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
