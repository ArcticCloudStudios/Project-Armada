using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killfeed : MonoBehaviour
{
   [SerializeField]
   GameObject killfeedItemPrefab;
   GameObject go;

  

   public void OnKill (string player, string source) 
   {
       go = (GameObject)Instantiate(killfeedItemPrefab, this.transform);
       go.transform.SetAsFirstSibling();
       go.GetComponent<killfeeditem>().Setup(player,source);

        
        Destroy(go, 3f);
      
   }

   public IEnumerator FadeAway () 
   {
       yield return new WaitForSeconds(1f);
       Text text = go.GetComponent<killfeeditem>().text;
       text.CrossFadeAlpha(0, 2f, true);
       Destroy(go, 2f);
       
   }
}
