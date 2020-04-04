using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Arctic/Character/NewNonPassiveAbility")]
public class NonPassiveAbility : Abilitybase
{
    [Header("Non Passive Attributes")]
    public float TimeLimit;
    public float RechargeTime;
}
