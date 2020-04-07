using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Character { Attacker, Defender, Heavy, Specialist }
[CreateAssetMenu(menuName = "Arctic/Character/NewCharacterType")]
public class CharacterType : ScriptableObject
{
    public Character Character;
    public float health;
    public float speed;
 
}
