using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killfeeditem : MonoBehaviour
{
  [SerializeField]
  public Text text;

  public void Setup (string player, string source) 
  {
      text.text = "<b>" + player + "</b>" + " Killed " + "<b>" + source + "</b>";
  }
}
