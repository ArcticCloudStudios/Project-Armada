using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static PhotonRoom Room;
    private PhotonView PV;

    public bool isGameLoaded;
    public int currentScene;
    public int multiplayerScene;

    //Player Info
    Player[] photonPlayers;
    public int playersInRoom;
    public int myNumberInRoom;

    public int playersInGame;


    public void Awake()
    {
        //Set Up Singleton
        if (PhotonRoom.Room == null)
        {
            PhotonRoom.Room = this;
        }
        else
        {
            if (PhotonRoom.Room != this)
            {
                Destroy(PhotonRoom.Room.gameObject);
                PhotonRoom.Room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public void Start()
    {
        PV = GetComponent<PhotonView>();
    }
    
    void OnSceneFinishedLoading (Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if (currentScene == multiplayerScene)
        {
            CreatePlayer();
            GameObject.Find("JoinMessage").GetComponent<JoinMessage>().OnJoin();
            //PV.RPC("OnJoin", RpcTarget.AllBuffered);
        }
 
       
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("A Player Has Connected To The Match.");
        
        base.OnJoinedRoom();
        StartGame();
    }

    void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    private void CreatePlayer ()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    }
}
