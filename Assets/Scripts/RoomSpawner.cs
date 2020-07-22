using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 : needs top opening
    // 2 : needs right opening
    // 3 : down
    // 4 : left

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (!spawned) {
            GameObject newRoom;
            spawned = true;
            if (openingDirection == 1) {
                rand = Random.Range(0, templates.topRooms.Length);
                newRoom = Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
            } else if (openingDirection == 2) {
                rand = Random.Range(0, templates.rightRooms.Length);
                newRoom = Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
            } else if (openingDirection == 3) {
                rand = Random.Range(0, templates.downRooms.Length);
                newRoom = Instantiate(templates.downRooms[rand], transform.position, Quaternion.identity);
            } else {
                rand = Random.Range(0, templates.leftRooms.Length);
                newRoom = Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            newRoom.transform.SetParent(GameObject.Find("Grid").transform);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Spawnpoint")) {
            Destroy(gameObject);
        }
    }

}
