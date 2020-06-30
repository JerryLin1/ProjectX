using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudControl : MonoBehaviour
{
    GameObject inventoryUI;
    Vector2 screenDimension;
    Vector2 slotOffset;
    int rows = 0;
    public GameObject slotPrefab;
    void Start()
    {
        inventoryUI = transform.GetChild(0).gameObject;
        screenDimension = GetComponent<CanvasScaler>().referenceResolution;
        slotOffset.x = screenDimension.x / -2;
        slotOffset.y = inventoryUI.GetComponent<RectTransform>().sizeDelta.y / -2;
    }
    public void addItem(GameObject item) {
        GameObject slot = Instantiate(slotPrefab);
        slot.GetComponent<slotControl>().setItemSprite(item.GetComponent<Item>().getItemSprite());
        slot.transform.SetParent(inventoryUI.transform);
        slot.GetComponent<RectTransform>().localPosition = slotOffset;
        slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (slotOffset.x == screenDimension.x / -2) {
            rows++;
            inventoryUI.GetComponent<RectTransform>().sizeDelta = new Vector2(0, rows * 50);
        }

        slotOffset.x += 50;
        if (slotOffset.x >= screenDimension.x/2) {
            slotOffset.y -= 50;
            slotOffset.x = -screenDimension.x/2;
        }
    }
    public void openInventory() {inventoryUI.SetActive(true);}
    public void closeInventory() {inventoryUI.SetActive(false);}
    public bool isInventoryOpen() {return inventoryUI.activeSelf;}
}
