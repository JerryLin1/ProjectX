using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Ability[] abilities;

    Vector3 mousePos;
    Vector2 direction;
    void Start()
    {

    }
    void Update()
    {
        checkInput();
        for (int i = 0; i < abilities.Length; i++) {
            abilities[i].decreaseCooldown();
        }
    }
    void checkInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();
        if (Input.GetMouseButton(0) && !abilities[0].onCooldown())
        {
            abilities[0].Cast(mousePos, direction);
        }
    }
    
}
