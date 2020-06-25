using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class UIhandler : MonoBehaviourPunCallbacks
{
    public InputField createRoomTF;
    public InputField joinRoomTF;
    public void onClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text, null);
    }
    public void onClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text, new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnJoinedRoom() {
        print("Room Joined Sucess :D");
        PhotonNetwork.LoadLevel("MultiplayerLobby");
    }
    public override void OnJoinRoomFailed(short returnCode, string message) {
        print("RoomFailed "+returnCode+" Message "+message);
    }
}
