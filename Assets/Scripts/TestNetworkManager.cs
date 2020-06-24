using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestNetworkManager : NetworkManager
{
    public Transform spawnPlayer1;
    public Transform spawnPlayer2;
    public GameObject GladPlayer;
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform start = spawnPlayer1;
        if (spawnPlayer1 != null && spawnPlayer2 != null) {
        if (numPlayers == 0) 
            start = spawnPlayer1;
        else if (numPlayers == 1) 
            start = spawnPlayer2;
        }
        GameObject player = Instantiate(GladPlayer, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        // spawn ball if two players
        if (numPlayers == 2)
        {
            Debug.Log("TWO ARE HERE!");
        }
    }

}
