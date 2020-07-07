using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : Entity
{
    Transform target;
    public override void customStart()
    {
        movementSpeed = 4f;
        maxHP = 15f;   
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    public override void Update()
    {
        transform.localRotation = (target.position.x - transform.position.x > 0) ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed*Time.deltaTime);
        
        
    }

}
