using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Ability[] abilities = new Ability[5];

    Vector3 mousePos;
    Vector2 direction;
    Player player;
    hudControl hudControl;
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
        hudControl = player.hudControl;
    }

    void Update()
    {
        checkInput();
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i] != null)
            {
                abilities[i].decreaseCooldown();
                if (abilities[i].getCooldown() > 0 && i != 0) 
                    hudControl.updateAbilityCooldown(i, abilities[i].getRemainingCooldown(), abilities[i].getCooldown()*player.GetCooldownFactor());
            }
        }
    }
    void checkInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        direction.Normalize();
        if (abilities[0] != null && Input.GetMouseButton(0) && !abilities[0].onCooldown())
        {
            abilities[0].Cast(mousePos, direction);
            player.triggerOnAbilityEffects();
        }

        if (abilities[1] != null && Input.GetMouseButton(1) && !abilities[1].onCooldown())
        {
            abilities[1].Cast(mousePos, direction);
            player.triggerOnAbilityEffects();
        }
        if (abilities[2] != null && Input.GetKeyDown(KeyCode.F) && !abilities[2].onCooldown())
        {
            abilities[2].Cast(mousePos, direction);
            player.triggerOnAbilityEffects();
        }
        if (abilities[3] != null && Input.GetKeyDown(KeyCode.Q) && !abilities[3].onCooldown())
        {
            abilities[3].Cast(mousePos, direction);
            player.triggerOnAbilityEffects();
        }
    }

}
