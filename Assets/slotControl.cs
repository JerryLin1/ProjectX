using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotControl : MonoBehaviour
{
    public void setItemSprite(Sprite sprite) {
        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
    }
}
