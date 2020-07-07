using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseSlotControl : MonoBehaviour
{
    public Item item;
    public GameObject slotHovered;
    [SerializeField] GameObject homeSlot;
    public PlayerControl pc;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (item == null)
            {
                if (slotHovered != null && slotHovered.GetComponent<slotControl>().item != null)
                {
                    item = slotHovered.GetComponent<slotControl>().item;
                    GetComponent<Image>().sprite = slotHovered.transform.GetChild(0).GetComponent<Image>().sprite;
                    GetComponent<Image>().enabled = true;
                    slotHovered.transform.GetChild(0).GetComponent<Image>().enabled = false;
                    homeSlot = slotHovered;
                }
            }
            else if (item != null)
            {
                GetComponent<Image>().enabled = false;
                homeSlot.transform.GetChild(0).GetComponent<Image>().enabled = true;
                if (slotHovered == null || slotHovered == homeSlot)
                {
                    item = null;
                }
                else
                {
                    if (slotHovered.GetComponent<slotControl>().item == null)
                    {
                        if (string.Equals(item.itemType, slotHovered.GetComponent<slotControl>().slotType) || string.Equals(slotHovered.GetComponent<slotControl>().slotType, "storage"))
                        {
                            slotHovered.transform.GetChild(0).GetComponent<Image>().enabled = true;
                            slotHovered.transform.GetChild(0).GetComponent<Image>().sprite = homeSlot.transform.GetChild(0).GetComponent<Image>().sprite;
                            
                        }
                    }
                }
                item = null;
            }
        }
        if (item != null)
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            transform.position = pz;
        }
    }
}
