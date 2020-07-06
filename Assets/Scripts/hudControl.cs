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
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = inventoryUI.transform.GetChild(0).GetChild(0).GetChild(slot).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipPassiveItem(GameObject item, int slot) {
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = inventoryUI.transform.GetChild(1).GetChild(0).GetChild(slot).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipActiveItem(GameObject item, int slot) {
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = bottomUI.transform.GetChild(0).GetChild(0).GetChild(slot).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void equipConsumableItem(GameObject item, int slot) {
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = bottomUI.transform.GetChild(0).GetChild(0).GetChild(slot).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
        
    }
    public void openInventory() {inventoryUI.SetActive(true);}
    public void closeInventory() {inventoryUI.SetActive(false);}
    public bool isInventoryOpen() {return inventoryUI.activeSelf;}
}