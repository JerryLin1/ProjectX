using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Dash : Ability
{
    protected override float cooldown { get { return 2f; } }
    float dashTime = 0.1f;
    float dashTimer = 0f;
    float dashSpeed = 100f;
    Vector2 dashDirection;
    public GameObject ghostTrail;

    private void Update()
    {
        if (parent != null)
        {
            if (dashTimer > 0f)
            {
                parent.GetComponent<Rigidbody2D>().AddForce(dashDirection * dashSpeed * 5f);
                dashTimer -= Time.deltaTime;
                GameObject ghostInstance = Instantiate(ghostTrail, parent.position, parent.localRotation);
                ghostInstance.GetComponent<ghostTrail>().setGhostLeaderSr(parent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>());
            }
            else
            {
                parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        dashDirection = direction;
        dashTimer = dashTime;
        dashSpeed = 100f;

        parent.GetComponent<Transform>().localRotation = (mousePos.x >= parent.transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        animator.SetTrigger("dash");
        goOnCooldown();
    }

    public void miniDash(Vector3 mousePos, Vector2 direction)
    {
        dashDirection = direction;
        dashTimer = 0.0125f;
        dashSpeed = 50f;
        // goOnCooldown();
    }
}