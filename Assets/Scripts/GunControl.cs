using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 mousePosition;
    private Vector2 direction;

    void Update()
    {
        faceMouse();
        shoot();
    }
    void faceMouse() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();

        transform.up = direction;
    }
    void shoot() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 20f;
            Destroy(bullet, 1f);
        }
    }
}
