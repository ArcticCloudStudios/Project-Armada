using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorObject : MonoBehaviour
{
    public Armor Armor;

    public IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(15.0f);
        gameObject.SetActive(true);
    }
}
