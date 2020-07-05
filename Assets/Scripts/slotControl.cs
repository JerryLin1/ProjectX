using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject tooltip;
    public string itemName;
    public string itemDesc;
    public int itemTier;
    GameObject slotImage;
    GameObject dragImage;

    void Start()
    {
        tooltip = transform.parent.parent.parent.parent.GetChild(2).gameObject;
        dragImage = transform.parent.parent.parent.parent.GetChild(3).gameObject;
        slotImage = transform.GetChild(0).gameObject;
    }
    public void setItemSprite(Sprite sprite)
    {
        slotImage.GetComponent<Image>().sprite = sprite;
    }
    public void setItemInfo(string newItemName, string newItemDesc, int newItemTier)
    {
        itemName = newItemName;
        itemDesc = newItemDesc;
        itemTier = newItemTier;
    }
    public void OnMouseOver()
    {
        if (itemName != "")
        {
            tooltip.transform.GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "<size=20>" + itemName + "</size>" + "\n" + itemDesc;
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
    public void OnBeginDrag(PointerEventData eventdata) {
        slotImage.SetActive(false);
        dragImage.SetActive(true);
        dragImage.GetComponent<Image>().sprite = slotImage.GetComponent<Image>().sprite;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        dragImage.transform.position = pz;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        slotImage.SetActive(true);
        dragImage.SetActive(false);
    }
}
