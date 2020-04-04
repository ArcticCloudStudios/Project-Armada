using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arctic/Character/AbilityList")]
public class AllAbilities : ScriptableObject
{
    public PassiveAbility[] PassiveAbilities;
    public NonPassiveAbility[] NonPassiveAbilities;
}
