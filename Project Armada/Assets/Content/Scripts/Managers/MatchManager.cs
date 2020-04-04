using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamemode { MP_Domination, MP_Capture }

public class MatchManager : MonoBehaviour
{
    public Gamemode Gamemode;
    [Header("Teams")]
    public GameObject PlayerPrefab;
    public GameObject[] Team01;
    public GameObject[] Team02;
    [Header("Spawnpoints")]
    Spawnpoints SP;

    public void Start()
    {
        SP = gameObject.GetComponent<Spawnpoints>();
        Instantiate(PlayerPrefab, SP.SpawnpointsList[0].transform.position, SP.SpawnpointsList[0].transform.rotation);
    }

}
