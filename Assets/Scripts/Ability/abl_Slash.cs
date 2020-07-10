using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abl_Slash : Ability
{
    protected override float cooldown { get { return 0f; } }
    Vector3 mousePos;
    Vector2 direction;

    float dashTimer = 0f;
    float dashSpeed = 100f;
    Vector2 dashDirection;

    public GameObject crescentPrefab;
    public GameObject ghostTrail;

    public float knockbackThrust;
    void Update() {
        
        if (parent != null)
        {
            if (dashTimer > 0f)
            {
                parent.GetComponent<Rigidbody2D>().AddForce(dashDirection * dashSpeed * 5f);
                dashTimer -= Time.deltaTime;
                GameObject ghostInstance = Instantiate(ghostTrail, parent.position, parent.localRotation);
                ghostInstance.GetComponent<ghostTrail>().setDashOpacity(0);
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
        this.mousePos = mousePos;
        this.direction = direction;
        
        animator.SetTrigger("slashing");
    }

    public void miniDash(float dashTimer, float dashSpeed, float crescentScale) {
        // Set miniDash parameters
        dashDirection = direction;
        this.dashTimer = dashTimer;
        this.dashSpeed = dashSpeed;

        // Create crescent in direction of mouse click
        parent.GetComponent<Transform>().localRotation = (mousePos.x >= parent.transform.position.x) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        GameObject crescent = Instantiate(crescentPrefab, parent.GetComponent<Transform>().position, parent.GetComponent<Transform>().localRotation);
        crescent.transform.localScale = new Vector3(crescentScale, crescentScale, 0);
        crescent.transform.up = direction;
        crescent.GetComponent<Crescent>().setAttack(transform.root.gameObject, 8, 6f, 0.2f);        
    }
}