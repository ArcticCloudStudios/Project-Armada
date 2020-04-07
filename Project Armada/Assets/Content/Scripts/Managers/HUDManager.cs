using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Arctic.Keybinds;


public class HUDManager : MonoBehaviour
{
    public Keybind key;
    [Header("Ability Section")]
    public TextMeshProUGUI Keybind;
    public Image NonPassiveIcon;
    public Image PassiveIcon;

    public Sprite NoIconError;

    [Header("Vitals Section")]
    public Slider HealthSlider;
    public Slider ArmorSlider;
    public TextMeshProUGUI HealthNum;
    public GameObject LowHealthIndicator;

    [Header("Character Section")]
    public TextMeshProUGUI CharacterName;

    [Header("Weapon Section")]
    public TextMeshProUGUI AmmoCounter;
    public TextMeshProUGUI WeaponName;

    PlayerController PC;

    public void Start()
    {
        key = GameObject.Find("InputManager").GetComponent<Keybind>();
        PC = gameObject.GetComponentInParent<PlayerController>();
        if (PC.Passive != null)
        {
            PassiveIcon.sprite = PC.Passive.Icon;
        } else
        {
            PassiveIcon.sprite = NoIconError;
        }
        if (PC.NonPassive != null)
        {
            NonPassiveIcon.sprite = PC.NonPassive.Icon;
        } else
        {
            NonPassiveIcon.sprite = NoIconError;
        }

        Keybind.text = key.keys["Ability"].ToString();
    }

    public void Update()
    {
        if (PC.Passive != null)
        {
            PassiveIcon.sprite = PC.Passive.Icon;
        }
        else
        {
            PassiveIcon.sprite = NoIconError;
        }
        if (PC.NonPassive != null)
        {
            NonPassiveIcon.sprite = PC.NonPassive.Icon;
        }
        else
        {
            NonPassiveIcon.sprite = NoIconError;
        }
        Keybind.text = key.keys["Ability"].ToString();
    }
}
