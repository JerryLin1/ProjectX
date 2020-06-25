using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviour
{
    public Transform[] playerSpawns;
    public GameObject playerPrefab;
    private int spawnIndex = 0;
    void Start()
    {
        
    }

    void SpawnPlayer() {
        PhotonNetwork.Instantiate(playerPrefab.name, playerSpawns[spawnIndex].position, playerPrefab.transform.rotation);
    }
}
