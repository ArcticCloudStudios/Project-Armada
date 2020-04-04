using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arctic.Keybinds
{ 
    public class Keybind : MonoBehaviour
    {
        public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

        public GameObject currentKey;

        public Color32 normal;
        public Color32 selected;

        [Header("MOVEMENT")]
        //MOVEMENT
        public Text WalkForward;
        public Text WalkBackward;
        public Text WalkRight;
        public Text WalkLeft;
        public Text JumpKey;
        public Text Crouch;
        public Text Sprint;
        [Header("WEAPONS & ABILITIES")]
        //WEAPONS & ABILITIES
        public Text PrimaryFire;
        public Text SecondaryFire;
        public Text Ability1;
        public Text Ability2;
        public Text EquipWeapon1;
        public Text EquipWeapon2;
        public Text Reload;
        public Text Interact;
        [Header("COMMUNICATION AND VOICE")]
        //COMMUNICATION
        public Text OpenChat;
        public Text TeamChat;
        public Text VCPushToTalk;
        public Text VCToggleMute;
        [Header("CUSTOM")]
        //CUSTOM
        public Text CharacterSelect;
        public Text Scoreboard;
        public Text Screenshot;
        public Text DisplayFPS;
        public Text HeroInfo;
        public Text PauseKey;
        public Text InventoryKey;
        public Text _DevMode;

        public void Awake()
        {
            setKey();
            setKeyText();
        }

        public void Start()
        {
           
           
        }

        public void setKey()
        {
            keys.Add("WalkForward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("WalkForward", "W")));
            keys.Add("WalkBackward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("WalkBackward", "S")));
            keys.Add("WalkRight", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("WalkRight", "D")));
            keys.Add("WalkLeft", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("WalkLeft", "A")));
            keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
            keys.Add("Crouch", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "C")));
            keys.Add("Ability", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability", "Q")));



        }
        public void setKeyText()
        {
            WalkForward.text = keys["WalkForward"].ToString();
            WalkBackward.text = keys["WalkBackward"].ToString();
            WalkRight.text = keys["WalkRight"].ToString();
            WalkLeft.text = keys["WalkLeft"].ToString();
            JumpKey.text = keys["Jump"].ToString();
            Crouch.text = keys["Crouch"].ToString();
            Ability1.text = keys["Ability"].ToString();

        }

        public void OnGUI()
        {
            if (currentKey != null)
            {
                Event e = Event.current;
                if (e.isKey)
                {
                    keys[currentKey.name] = e.keyCode;
                    currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                    currentKey.GetComponent<Image>().color = normal;
                    SaveKeys();
                    currentKey = null;
                }
            }
        }

        public void ChangeKey(GameObject clicked)
        {
            if (currentKey != null)
            {
                currentKey.GetComponent<Image>().color = normal;
            }
            currentKey = clicked;
            currentKey.GetComponent<Image>().color = selected;
        }
        public void SaveKeys()
        {
            foreach (var key in keys)
            {
                PlayerPrefs.SetString(key.Key, key.Value.ToString());
            }

            PlayerPrefs.Save();
            Debug.Log("Saved.");
        }
    }
}
