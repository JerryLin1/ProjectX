using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    public Transform leader;
    void FixedUpdate()
    {
        if (leader != null)
        transform.position = new Vector3(leader.position.x, leader.position.y-1, transform.position.z);
    }
    public void setTarget(Transform target)
     {
         leader = target;
     }
}
