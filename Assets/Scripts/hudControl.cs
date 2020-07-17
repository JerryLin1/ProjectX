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
    public Player pc;
    void Start()
    {
        inventoryUI = transform.GetChild(0).gameObject;
        bottomUI = transform.GetChild(1).gameObject;
        screenDimension = GetComponent<CanvasScaler>().referenceResolution;
    }
    public void pickupPassiveItem(GameObject item) {
        GameObject slotInstance = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
        Item itemScript = item.GetComponent<Item>();
        slotInstance.transform.SetParent(inventoryUI.transform.GetChild(0));
        slotInstance.GetComponent<slotControl>().item = item.GetComponent<Item>();
        slotInstance.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        slotInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;
        slotInstance.transform.localScale = new Vector3(1, 1, 1);
        slotInstance.transform.localPosition = new Vector3(0, 0, 1);
    }
    public void pickupActiveItem(GameObject item) {
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = bottomUI.transform.GetChild(1).GetChild(0).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void setHealthBar(float currentHP, float maxHP) {
        float percentage = currentHP/maxHP;
        transform.GetChild(3).GetComponent<Slider>().value = percentage;
    }
    public void openInventory() {inventoryUI.SetActive(true);}
    public void closeInventory() {inventoryUI.SetActive(false);}
    public bool isInventoryOpen() {return inventoryUI.activeSelf;}
}