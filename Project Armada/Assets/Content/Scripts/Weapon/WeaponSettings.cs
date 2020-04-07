using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arctic.Weapons
{
    public enum WeaponType { FullAuto, SemiAuto, Burst }
    public enum ScanType { Hitscan, Conescan }
    [System.Serializable]
    public class WeaponSettings
    {
        public WeaponType Type;
        public ScanType Scan;

        [Header("Ammo")]
        public int RoundsPerMag;
        public int TotalRounds;

        [Header("Stats")]
        public int RoundsPerMinute;
        public float damage;
        public float headshotMultiplier;

        [Header("Burst")]
        public float burstCooldown;
        public int burstAmount;

        [Header("Hitscan")]
        public float effectiveRange;

        [Header("Conescan")]
        public float maxSpread;
        public int pelletCount;

        [Header("Misc")]
        public Texture2D muzzleGradientMap;
    }
}
