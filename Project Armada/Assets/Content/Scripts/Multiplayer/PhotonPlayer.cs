using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    public PhotonView PV;
    public GameObject myAvatar;
    public Transform playerCam;

    private void Awake()
    {
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
           
            Debug.Log("I've Assigned the Avatar.");
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonAvatar"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
            playerCam = myAvatar.transform.Find("LeanAnimator/Cam_M").GetComponent<Camera>().transform;
            playerCam.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START!");
        PV = GetComponent<PhotonView>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
