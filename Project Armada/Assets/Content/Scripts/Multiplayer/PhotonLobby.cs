using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    public GameObject PlayButton;
    public GameObject cancelButton;

    private void Awake()
    {
        lobby = this; //Create the singleton.
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master photon server.

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PlayButton.SetActive(true);
    }

    public void onPlayButtonClicked()
    {
        PlayButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a random game.");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

   

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create room but failed");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        PlayButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
