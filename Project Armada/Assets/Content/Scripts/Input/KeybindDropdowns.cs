using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindDropdowns : MonoBehaviour
{
    [Header("MOVEMENT")]
    //MOVEMENT
    public Dropdown WalkForward;
    public Dropdown WalkBackward;
    public Dropdown WalkRight;
    public Dropdown WalkLeft;
    public Dropdown JumpKey;
    public Dropdown Crouch;
    public Dropdown Sprint;
    [Header("WEAPONS & ABILITIES")]
    //WEAPONS & ABILITIES
    public Dropdown PrimaryFire;
    public Dropdown SecondaryFire;
    public Dropdown Ability1;
    public Dropdown Ability2;
    public Dropdown EquipWeapon1;
    public Dropdown EquipWeapon2;
    public Dropdown Reload;
    public Dropdown Interact;
    [Header("COMMUNICATION AND VOICE")]
    //COMMUNICATION
    public Dropdown OpenChat;
    public Dropdown TeamChat;
    public Dropdown VCPushToTalk;
    public Dropdown VCToggleMute;
    [Header("CUSTOM")]
    //CUSTOM
    public Dropdown CharacterSelect;
    public Dropdown Scoreboard;
    public Dropdown Screenshot;
    public Dropdown DisplayFPS;
    public Dropdown HeroInfo;
    public Dropdown PauseKey;
    public Dropdown InventoryKey;
    public Dropdown _DevMode;

    public void Start()
    {
        
    }
}
