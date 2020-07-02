using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudControl : MonoBehaviour
{
    GameObject inventoryUI;
    Vector2 screenDimension;
    public GameObject slotPrefab;
    public PlayerControl pc;
    void Start()
    {
        inventoryUI = transform.GetChild(0).gameObject;
        screenDimension = GetComponent<CanvasScaler>().referenceResolution;
    }
    public void addItem(GameObject item) {
        // TODO: ADD ITEM TO INVENTORY
    }
    public void openInventory() {inventoryUI.SetActive(true);}
    public void closeInventory() {inventoryUI.SetActive(false);}
    public bool isInventoryOpen() {return inventoryUI.activeSelf;}
}