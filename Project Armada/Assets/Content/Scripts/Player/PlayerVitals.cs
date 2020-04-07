using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{
    public CharacterType Character;
    HUDManager HUD;
    [Header("Health")]
    public float MaxHealth;
    public float curHealth;
    public float healthRegenSpeed;

    [Header("Armor")]
    public float MaxArmor;
    public float curArmor;
    

    public void Start()
    {
        HUD = gameObject.GetComponentInChildren<HUDManager>();
        MaxHealth = Character.health;
        curHealth = MaxHealth;
        HUD.HealthSlider.maxValue = MaxHealth;
        HUD.HealthSlider.value = curHealth;
    }
    public void Update()
    {
        MaxHealth = Character.health;
        HUD.HealthSlider.maxValue = MaxHealth;
        HUD.HealthSlider.value = curHealth;
        HUD.HealthNum.text = curHealth.ToString("F0") + "<color=yellow>/</color>" + MaxHealth.ToString();
        HUD.CharacterName.text = Character.Character.ToString();

        //Armor
        HUD.ArmorSlider.maxValue = MaxArmor;
        HUD.ArmorSlider.value = curArmor;

        if (curHealth < MaxHealth)
        {
            StartCoroutine("RegenHealth");
        }
        if (curHealth >= MaxHealth)
        {
            StopCoroutine("RegenHealth");
            curHealth = MaxHealth;
        }

        //Low Health
        if (curHealth < 25)
        {
            HUD.LowHealthIndicator.SetActive(true);
        } else
        {
            HUD.LowHealthIndicator.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Armor")
        {
            if (curArmor < MaxArmor)
            {
                ArmorObject AO = other.gameObject.GetComponent<ArmorObject>();
                curArmor += AO.Armor.ArmorInBox;
                if (curArmor >= MaxArmor)
                {
                    curArmor = MaxArmor;
                }
                other.gameObject.SetActive(false);
                StartCoroutine("RespawnTime");


            }
        }
    }

    public IEnumerator RegenHealth()
    {
        yield return new WaitForSeconds(5.0f);
        curHealth += healthRegenSpeed * Time.deltaTime;
    }
    public void die()
    {
        if (curHealth <= 0)
        {
            //Die.
            //Respawn.
        }
    }


}
