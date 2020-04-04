using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arctic/Character/NewAbility")]
public class Abilitybase : ScriptableObject
{
    public string AbilityName;
    
   

    [Header("UI")]
    public Sprite Icon;
}
