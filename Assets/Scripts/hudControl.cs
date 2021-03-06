﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hudControl : MonoBehaviour
{
    GameObject inventoryUI;
    GameObject bottomUI;
    GameObject abilitySlots;
    Vector2 screenDimension;
    public GameObject slotPrefab;
    public Player pc;
    float hpEmphasizeTime = 0.1f;
    float hpEmphasizeTimer = 0;
    int hpEmphasizeAmount = 5;
    TextMeshProUGUI healthBarText;
    void Start()
    {
        inventoryUI = transform.GetChild(0).gameObject;
        bottomUI = transform.GetChild(1).gameObject;
        abilitySlots = bottomUI.transform.GetChild(0).gameObject;
        screenDimension = GetComponent<CanvasScaler>().referenceResolution;
        healthBarText = transform.Find("Health Bar").Find("Health text").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (hpEmphasizeTimer > 0)
        {
            hpEmphasizeTimer-=Time.deltaTime;
            if (hpEmphasizeTimer <= 0) healthBarText.fontSize -= hpEmphasizeAmount;
        }
    }
    public void pickupPassiveItem(GameObject item)
    {
        GameObject slotInstance = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity);
        Item itemScript = item.GetComponent<Item>();
        slotInstance.transform.SetParent(inventoryUI.transform.GetChild(0));
        slotInstance.GetComponent<slotControl>().item = item.GetComponent<Item>();
        slotInstance.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        slotInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;
        slotInstance.transform.localScale = new Vector3(1, 1, 1);
        slotInstance.transform.localPosition = new Vector3(0, 0, 1);
    }
    public void pickupActiveItem(GameObject item)
    {
        Item itemScript = item.GetComponent<Item>();
        GameObject stemp = bottomUI.transform.GetChild(1).GetChild(0).gameObject;
        stemp.GetComponent<slotControl>().item = item.GetComponent<Item>();
        stemp.transform.GetChild(0).GetComponent<Image>().sprite = item.GetComponent<Item>().getItemSprite();
        stemp.transform.GetChild(0).GetComponent<Image>().enabled = true;
    }
    public void setHealthBar(float currentHP, float maxHP)
    {
        float percentage = currentHP / maxHP;
        transform.GetChild(3).GetComponent<Slider>().value = percentage;
        healthBarText.text = currentHP + "/" + maxHP;
        healthBarText.fontSize += hpEmphasizeAmount;
        hpEmphasizeTimer = hpEmphasizeTime;
    }
    public void updateAbilityCooldown(int slot, float timer, float cooldown)
    {
        float fillAmount = timer / cooldown;
        abilitySlots.transform.GetChild(slot).GetChild(1).GetComponent<Image>().fillAmount = fillAmount;
    }
    public void openInventory() { inventoryUI.SetActive(true); }
    public void closeInventory() { inventoryUI.SetActive(false); }
    public bool isInventoryOpen() { return inventoryUI.activeSelf; }
}