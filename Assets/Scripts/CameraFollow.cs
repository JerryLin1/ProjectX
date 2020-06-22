using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    public Transform leader;
    void FixedUpdate()
    {
        transform.position = new Vector3(leader.position.x, leader.position.y, transform.position.z);
    }
}
