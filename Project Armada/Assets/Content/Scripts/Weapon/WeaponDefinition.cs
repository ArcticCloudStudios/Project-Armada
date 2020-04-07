using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arctic.Weapons
{
    [CreateAssetMenu(menuName = "Arctic/Weapons/NewWeapon")]
    public class WeaponDefinition : ScriptableObject
    {
        [Header("General")]
        public string WeaponName;

        [Header("Prefabs")]
        public GameObject inHand;
        public GameObject onGround;

        [Header("Audio")]
        public AudioClip[] fireSounds;
        public AudioClip[] equipSounds;
        public AudioClip[] reloadSounds;

        [Header("UI")]
        public Sprite reticle;
        public float reticleScale = 1.0f;

        [Header("Class")]
        public WeaponSettings weaponSettings;
    }
}
