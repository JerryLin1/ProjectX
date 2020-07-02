using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudControl : MonoBehaviour
{
    GameObject inventoryUI;
    GameObject bottomUI;
    Vector2 screenDimension;
    public GameObject slotPrefab;
    public PlayerControl pc;
    void Start()
    {
        inventoryUI = transform.GetChild(0).gameObject;
        bottomUI = transform.GetChild(1).gameObject;
        screenDimension = GetComponent<CanvasScaler>().referenceResolution;
    }
    public void addStorageItem(GameObject item, int slot) {
        inventoryUI.transform.GetChild(0).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        inventoryUI.transform.GetChild(0).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipPassiveItem(GameObject item, int slot) {
        Debug.Log(slot);
        inventoryUI.transform.GetChild(1).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        inventoryUI.transform.GetChild(1).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipActiveItem(GameObject item, int slot) {
        bottomUI.transform.GetChild(0).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        bottomUI.transform.GetChild(0).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipConsumableItem(GameObject item, int slot) {
        bottomUI.transform.GetChild(1).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        bottomUI.transform.GetChild(1).GetChild(0).GetChild(slot).GetChild(0).GetComponent<Image>().enabled = true;
        
    }
    public void openInventory() {inventoryUI.SetActive(true);}
    public void closeInventory() {inventoryUI.SetActive(false);}
    public bool isInventoryOpen() {return inventoryUI.activeSelf;}
}