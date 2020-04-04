using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ability { Wallrun, UnlimitedAmmo, WallClimb, SuperSprint  }
[CreateAssetMenu(menuName = "Arctic/Character/NewAbilityLoadout")]
public class AbilityLoadout : ScriptableObject
{
    
    [Header("Player Abilities")]
    public Ability Ability01;
    public Ability Ability02;
   
}
