using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject hoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        hoverPanel.SetActive(false);
    }
    public void OnMouseOver() {
        hoverPanel.SetActive(true);
    }

    public void OnMouseExit() {
        hoverPanel.SetActive(false);
    }

   
}
