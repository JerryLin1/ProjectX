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
    public bool spawned = false;
    private GameObject newRoom;

    private List<GameObject> topRooms, downRooms, leftRooms, rightRooms;

    void Start()
    {
        templates = GameObject.Find("RoomTemplates").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {

        if (templates.rooms.Count < 15) {
            topRooms = templates.topRooms.FindAll(room => room.transform.childCount >= 4);
            downRooms = templates.downRooms.FindAll(room => room.transform.childCount >= 4);
            leftRooms = templates.leftRooms.FindAll(room => room.transform.childCount >= 4);
            rightRooms = templates.rightRooms.FindAll(room => room.transform.childCount >= 4);
        } else {
            topRooms = templates.topRooms.FindAll(room => room.transform.childCount == 3);
            downRooms = templates.downRooms.FindAll(room => room.transform.childCount == 3);
            leftRooms = templates.leftRooms.FindAll(room => room.transform.childCount == 3);
            rightRooms = templates.rightRooms.FindAll(room => room.transform.childCount == 3);
        }

        
        


        if (!spawned) {
            spawned = true;
            if (openingDirection == 1) {
                rand = Random.Range(0, topRooms.Count);
                newRoom = Instantiate(topRooms[rand], transform.position, Quaternion.identity);
            } else if (openingDirection == 2) {
                rand = Random.Range(0, rightRooms.Count);
                newRoom = Instantiate(rightRooms[rand], transform.position, Quaternion.identity);
            } else if (openingDirection == 3) {
                rand = Random.Range(0, downRooms.Count);
                newRoom = Instantiate(downRooms[rand], transform.position, Quaternion.identity);
            } else if (openingDirection == 4) {
                rand = Random.Range(0, leftRooms.Count);
                newRoom = Instantiate(leftRooms[rand], transform.position, Quaternion.identity);
            }
            newRoom.transform.SetParent(GameObject.Find("Grid").transform);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Spawnpoint") || other.CompareTag("Room")) {

            // if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
            // }

            Destroy(gameObject);
        }
    }

}
