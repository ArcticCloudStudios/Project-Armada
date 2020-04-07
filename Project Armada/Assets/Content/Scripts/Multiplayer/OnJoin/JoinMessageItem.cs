using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinMessageItem : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;

    public void Setup()
    {
        text.text = "Player has joined.";
    }
}
