using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePosition;
    private Vector2 direction;

    void Update()
    {
        faceMouse();
        shoot();
    }
    void faceMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();

        transform.up = direction;
    }
    void shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;
        Destroy(bullet, 1f);

    }
}
