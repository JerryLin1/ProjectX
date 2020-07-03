using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : Entity
{
    GameObject[] storage = new GameObject[6];
    GameObject[] activeEquipped = new GameObject[4];
    GameObject[] passiveEquipped = new GameObject[4];
    GameObject[] consumableEquipped = new GameObject[2];
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
        bool normalSlotsFull = true;
        if (itemScript.itemType == "passive")
        {
            for (int i = 0; i < passiveEquipped.Length; i++)
            {
                if (passiveEquipped[i] == null)
                {
                    normalSlotsFull = false;
                    passiveEquipped[i] = item;
                    hudControl.equipPassiveItem(item, i);
                    item.transform.position = new Vector3(-999999, -999999);
                    item.GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            }
        }
        else if (itemScript.itemType == "active")
        {
            for (int i = 0; i < activeEquipped.Length; i++)
            {
                if (activeEquipped[i] == null)
                {
                    normalSlotsFull = false;
                    activeEquipped[i] = item;
                    setAbility(itemScript.itemAbility, i);
                    hudControl.equipActiveItem(item, i);
                    item.transform.position = new Vector3(-999999, -999999);
                    item.GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            }
        }
        else if (itemScript.itemType == "consumable")
        {
            for (int i = 0; i < consumableEquipped.Length; i++)
            {
                if (consumableEquipped[i] == null)
                {
                    normalSlotsFull = false;
                    consumableEquipped[i] = item;
                    hudControl.equipConsumableItem(item, i);
                    item.transform.position = new Vector3(-999999, -999999);
                    item.GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            }
        }
        if (normalSlotsFull)
        {
            for (int i = 0; i < storage.Length; i++)
            {
                if (storage[i] == null)
                {
                    normalSlotsFull = false;
                    storage[i] = item;
                    hudControl.addStorageItem(item, i);
                    item.transform.position = new Vector3(-999999, -999999);
                    item.GetComponent<BoxCollider2D>().enabled = false;
                    break;
                }
            }
        }
        if (normalSlotsFull) Debug.Log("You have no room for that item");
    }
    public void setAbility(Ability ability, int slot) {
        playerAbilities.abilities[slot] = ability;
        playerAbilities.abilities[slot].onEquip();
    }
    public void inventoryTriggerPassiveItems()
    {
        foreach (GameObject item in passiveEquipped)
        {
            if (item != null)
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
