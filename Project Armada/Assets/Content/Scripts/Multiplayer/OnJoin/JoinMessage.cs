using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JoinMessage : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    [SerializeField]
    GameObject JoinItemPrefab;
    GameObject go;

    public void Start()
    {
        PV = GetComponent<PhotonView>();
        //PV.RPC("OnJoin", RpcTarget.AllBuffered);
    }

    public void OnJoin()
    {
       
        go = (GameObject)Instantiate(JoinItemPrefab, this.transform);
        go.transform.SetAsFirstSibling();
        go.GetComponent<JoinMessageItem>().Setup();
       

        Destroy(go, 3f);

    }

    public void Update()
    {
        PV = GameObject.Find("RoomController").GetComponent<PhotonView>();
       
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("A Player Has Connected To The Matchs.");
        OnJoin();
        base.OnJoinedRoom();
        
    }
}
