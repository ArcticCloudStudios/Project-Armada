using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arctic.Keybinds
{
    public class KeybindingManager : MonoBehaviour
    {
        private List<string> keys;
        public List<Dropdown> Dropdowns = new List<Dropdown>();
        public KeybindDropdowns KD;

        //Key Variables
        [Header("MOVEMENT")]
        //MOVEMENT
        public KeyCode WalkForward;
        public KeyCode WalkBackward;
        public KeyCode WalkRight;
        public KeyCode WalkLeft;
        public KeyCode JumpKey;
        public KeyCode Crouch;
        public KeyCode Sprint;
        [Header("WEAPONS & ABILITIES")]
        //WEAPONS & ABILITIES
        public KeyCode PrimaryFire;
        public KeyCode SecondaryFire;
        public KeyCode Ability1;
        public KeyCode Ability2;
        public KeyCode EquipWeapon1;
        public KeyCode EquipWeapon2;
        public KeyCode Reload;
        public KeyCode Interact;
        [Header("COMMUNICATION AND VOICE")]
        //COMMUNICATION
        public KeyCode OpenChat;
        public KeyCode TeamChat;
        public KeyCode VCPushToTalk;
        public KeyCode VCToggleMute;
        [Header("CUSTOM")]
        //CUSTOM
        public KeyCode CharacterSelect;
        public KeyCode Scoreboard;
        public KeyCode Screenshot;
        public KeyCode DisplayFPS;
        public KeyCode HeroInfo;
        public KeyCode PauseKey;
        public KeyCode InventoryKey;
        public KeyCode _DevMode;
       

        public void Start()
        {
            KD = GameObject.Find("KeyBinds").GetComponent<KeybindDropdowns>();
            keys = new List<string> { };
            foreach (string s in System.Enum.GetNames(typeof(KeyCode)))
            {
                //print(s);
                keys.Add(s);
            }

            for (int i = 0; i < Dropdowns.Count; i++)
            {
                Dropdowns[i].AddOptions(keys);
            }
            loadPrefabs();

        }

        private void loadPrefabs()
        {
            //MOVEMENT
            WalkForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkfPrefs", "W"));
            SelectKey(KD.WalkForward, WalkForward.ToString());

            WalkBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkbPrefs"));
            SelectKey(KD.WalkBackward, WalkBackward.ToString());

            WalkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walkrPrefs"));
            SelectKey(KD.WalkRight, WalkRight.ToString());

            WalkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("walklPrefs"));
            SelectKey(KD.WalkLeft, WalkLeft.ToString());

            JumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpPrefs"));
            SelectKey(KD.JumpKey, JumpKey.ToString());

            Crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchPrefs"));
            SelectKey(KD.Crouch, Crouch.ToString());

            Sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sprintPrefs", "Left Shift"));
            SelectKey(KD.Sprint, Sprint.ToString());

            //WEAPONS & ABILITIES
            PrimaryFire = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("firePrefs"));
            SelectKey(KD.PrimaryFire, PrimaryFire.ToString());

            SecondaryFire = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("aimPrefs"));
            SelectKey(KD.SecondaryFire, SecondaryFire.ToString());

            Ability1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability1Prefs"));
            SelectKey(KD.Ability1, Ability1.ToString());

            Ability2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ability2Prefs"));
            SelectKey(KD.Ability2, Ability2.ToString());

            EquipWeapon1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Weapon1Prefs"));
            SelectKey(KD.EquipWeapon1, EquipWeapon1.ToString());

            EquipWeapon2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Weapon2Prefs"));
            SelectKey(KD.EquipWeapon2, EquipWeapon2.ToString());

            Reload = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ReloadPrefs"));
            SelectKey(KD.Reload, Reload.ToString());

            Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactPrefs"));
            SelectKey(KD.Interact, Interact.ToString());

            //COMMUNICATION AND VOICE
            OpenChat = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("openchatPrefs"));
            SelectKey(KD.OpenChat, OpenChat.ToString());

            TeamChat = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("teamchatPrefs"));
            SelectKey(KD.TeamChat, TeamChat.ToString());

            VCPushToTalk = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pushtotalkPrefs"));
            SelectKey(KD.VCPushToTalk, VCPushToTalk.ToString());

            VCToggleMute = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("togglemutePrefs"));
            SelectKey(KD.VCToggleMute, VCToggleMute.ToString());

            //CUSTOM
            CharacterSelect = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("characterselectPrefs"));
            SelectKey(KD.CharacterSelect, CharacterSelect.ToString());

            Scoreboard = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("scoreboardPrefs"));
            SelectKey(KD.Scoreboard, Scoreboard.ToString());

            Screenshot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("screenshotPrefs"));
            SelectKey(KD.Screenshot, Screenshot.ToString());

            DisplayFPS = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("displayFPSPrefs"));
            SelectKey(KD.DisplayFPS, DisplayFPS.ToString());

            HeroInfo = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("HeroInfoPrefs"));
            SelectKey(KD.HeroInfo, HeroInfo.ToString());

            _DevMode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("devmodePrefs"));
            SelectKey(KD._DevMode, _DevMode.ToString());

            PauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pausePrefs"));
            SelectKey(KD.PauseKey, PauseKey.ToString());

            InventoryKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryPrefs"));
            SelectKey(KD.InventoryKey, InventoryKey.ToString());



        }

        private void SelectKey(Dropdown _dropDown, string _s)
        {
            for (int i = 0; i < keys.Count; i++) //Loops through the key list.
            {
                if (_s == keys[i])
                {
                    _dropDown.value = i;
                }
            }
        }

        public void ChangeKey(string b)
        {
            string[] variables = b.Split(',');
            string VariableName = variables[0];
            int id = System.Convert.ToInt32(variables[1]);
            string playerprefs = variables[2];
            this.GetType().GetProperty(VariableName).SetValue(this, (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]));
            PlayerPrefs.SetString(playerprefs, keys[id]);
        }

        //CHANGE KEYS
        public void ChangeJumpKey(int id)
        {
            JumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("jumpPrefs", keys[id]);
        }
        public void ChangeInteractKey(int id)
        {
            Interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("interactPrefs", keys[id]);
        }
        public void ChangeWalkFKey(int id)
        {
            WalkForward = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkfPrefs", keys[id]);
        }
        public void ChangeWalkBKey(int id)
        {
            WalkBackward = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkbPrefs", keys[id]);
        }
        public void ChangeWalkRKey(int id)
        {
            WalkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walkrPrefs", keys[id]);
        }
        public void ChangeWalkLKey(int id)
        {
            WalkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("walklPrefs", keys[id]);
        }
        public void ChangeCrouchKey(int id)
        {
            Crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("crouchPrefs", keys[id]);
        }
        public void ChangeSprintKey(int id)
        {
            Sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("sprintPrefs", keys[id]);
        }
        public void ChangeFireKey(int id)
        {
            PrimaryFire = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("firePrefs", keys[id]);
        }
        public void ChangeAimKey(int id)
        {
            SecondaryFire = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("aimPrefs", keys[id]);
        }
        public void ChangePauseKey(int id)
        {
            PauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("pausePrefs", keys[id]);
        }
        public void ChangeInventoryKey(int id)
        {
            InventoryKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("inventoryPrefs", keys[id]);
        }
        public void ChangeDevModeKey(int id)
        {
            _DevMode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keys[id]);
            PlayerPrefs.SetString("devmodePrefs", keys[id]);
        }
    }
}
