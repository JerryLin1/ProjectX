using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : Entity
{
    ArrayList inventory = new ArrayList();
    Vector2 direction;
    Vector3 mousePos;
    public bool isAttacking;
    public GameObject nearbyItem;
    public GameObject HUD;
    public GameObject slotPrefab;

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

        // Open inventory HUD
        if (Input.GetKey(KeyCode.Tab)) {
            HUD.transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            HUD.transform.GetChild(0).gameObject.SetActive(false);
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
        GameObject slot = Instantiate(slotPrefab);
        slot.transform.GetChild(0).GetComponent<Image>().sprite = item.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite; 
        slot.transform.SetParent(HUD.transform.GetChild(0));
        slot.GetComponent<RectTransform>().localPosition = new Vector3(inventory.Count * 60 - 400, -30, 0);
        slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        inventory.Add(item);
        item.GetComponent<Item>().onPickUpEffect(this);
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
        nearbyItem = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        nearbyItem = null;
    }
}
