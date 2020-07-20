using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Update is called once per frame
    public Transform leader;
    float xMaxDist = 1f;
    float yMaxDist = 1f;
    float interpolation = 4f;
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 leaderPos = leader.position;
        float x = (leaderPos.x + mousePos.x) / 2;
        if (x > leaderPos.x + xMaxDist) x = leaderPos.x + xMaxDist;
        else if (x < leaderPos.x - xMaxDist) x = leaderPos.x - xMaxDist;
        float y = (leaderPos.y + mousePos.y) / 2;
        if (y > leaderPos.y + yMaxDist) y = leaderPos.y + yMaxDist;
        else if (y < leaderPos.y - yMaxDist) y = leaderPos.y - yMaxDist;
        Vector3 center = new Vector3(x, y, transform.position.z);

        if (leader != null)
        {
            Vector3 t = new Vector3(leaderPos.x, leaderPos.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, center, Time.deltaTime * interpolation);
        }
    }
    public void setTarget(Transform target)
    {
        leader = target;
    }
}
