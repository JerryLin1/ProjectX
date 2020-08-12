using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotControl : MonoBehaviour
{
    GameObject tooltip;
    public Item item;
    GameObject slotImage;
    GameObject mouseSlot;
    int slotIndex;

    void Start()
    {
        tooltip = transform.parent.parent.parent.GetChild(2).gameObject;
        slotImage = transform.GetChild(0).gameObject;
    }
    public void setItemSprite(Sprite sprite)
    {
        slotImage.GetComponent<Image>().sprite = sprite;
    }
    public void OnMouseOver()
    {
        if (item != null)
        {
            tooltip.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "<size=20>" + item.itemName + "</size>" + "\n" + item.itemDesc;
            tooltip.transform.GetChild(0).position = new Vector2(transform.position.x + 1, transform.position.y);
            tooltip.SetActive(true);
            tooltip.SetActive(false);
            tooltip.SetActive(true);
        }
    }
    public void OnMouseExit()
    {
        tooltip.SetActive(false);
    }
    public void OnDisable()
    {
        if (tooltip != null)
            tooltip.SetActive(false);
    }
}
