using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotControl : MonoBehaviour
{
    public GameObject tooltip;
    public string itemName;
    public string itemDesc;
    public int itemTier;

    void Start()
    {
        tooltip = transform.parent.GetChild(0).gameObject;
    }
    public void setItemSprite(Sprite sprite)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }
    public void setItemName(string newItemName) { itemName = newItemName; }
    public void setItemDesc(string newItemDesc) { itemDesc = newItemDesc; }
    public void setItemTier(int newItemTier) { itemTier = newItemTier; }
    public void OnMouseOver()
    {
        tooltip.SetActive(true);
        tooltip.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "<size=20>" + itemName + "</size>" + "\n" + itemDesc;
        tooltip.transform.GetChild(0).position = new Vector2(transform.position.x+1, transform.position.y);
    }
    public void OnMouseExit()
    {
        tooltip.SetActive(false);
    }
    public void OnDisable() {
        if (tooltip != null)
            tooltip.SetActive(false);
    }
}
