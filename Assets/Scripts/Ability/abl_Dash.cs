using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Dash : Ability
{
    protected override float cooldown { get { return 1f; } }
    float dashTime = 0.1f;
    float dashTimer = 0f;
    float dashSpeed = 100f;
    Vector2 dashDirection;
    public GameObject ghostTrail;


    void Update()
    {
        if (parent != null && !parent.GetComponent<Player>().isBeingAttacked)
        {
            if (dashTimer > 0f)
            {
                parent.GetComponent<Rigidbody2D>().AddForce(dashDirection * dashSpeed * 5f);
                parent.GetComponent<Transform>().localRotation = (dashDirection.x >= 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
                dashTimer -= Time.deltaTime;
                GameObject ghostInstance = Instantiate(ghostTrail, parent.position, parent.localRotation);
                ghostInstance.GetComponent<ghostTrail>().setGhostLeaderSr(parent.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>());
            }
            
        }
    }
    public override void Cast(Vector3 mousePos, Vector2 direction)
    {
        dashDirection = direction;
        dashTimer = dashTime;

        parent.GetComponent<Player>().kickupDust();
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= parent.transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        animator.SetTrigger("dash");
        StartCoroutine(Camera.main.GetComponent<CameraControl>().cameraShake(0.1f, 0.5f));
        goOnCooldown();
    }
}