using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Arctic.Weapons;

public class WeaponInHand : MonoBehaviour
{
    public WeaponDefinition Weapon;
    public int ammoCount;
    public Text AmmoCounter;
    public bool HasAmmoCounter;
    public Vector2Int AmmoResolution;
    public Camera AmmoCamera;
    public RectTransform Compass;
    public bool HasCompass = false;
    public Transform GunPoint;
    //public Player playerReference;
    public GameObject muzzleFlash;
    public bool HasMuzzleFlash = true;

    private Timer shotTimer;
    private Material muzzleMat = null;
    private Vector3 initialScale;
    private RenderTexture rt = null;

    void Start()
    {
        shotTimer = new Timer(0.075f);
        if (HasMuzzleFlash)
        {
            if (muzzleFlash != null) initialScale = muzzleFlash.transform.localScale;
            muzzleMat = muzzleFlash?.GetComponent<MeshRenderer>().material;
            // CHECK FOR ONLY GUNS LATER
            muzzleMat?.SetTexture("_GradientMap", Weapon.weaponSettings.muzzleGradientMap);
        }

        if (AmmoResolution.x > 0)
        {
            rt = new RenderTexture(AmmoResolution.x, AmmoResolution.y, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
            Material[] mats = GetComponent<MeshRenderer>().materials;
            for (int i = 0; i < mats.Length; i++)
            {
                if (mats[i].HasProperty("_ScreenTex"))
                {
                    mats[i].SetTexture("_ScreenTex", rt);
                    AmmoCamera.targetTexture = rt;
                    break;
                }
            }
        }
    }

    void Update()
    {
        if (HasAmmoCounter) AmmoCounter.text = ammoCount.ToString("00");
        if (HasMuzzleFlash)
        {
            float val = Mathf.SmoothStep(0.0f, 1.0f, shotTimer.GetValue());
            muzzleMat?.SetFloat("_Alpha", val * 0.8f);
            if (muzzleFlash != null) muzzleFlash.transform.localScale = initialScale * Mathf.Clamp01(val + 0.4f);
        }
        if (shotTimer.GetValue() >= 1.0f)
        {
            shotTimer.Start(Timer.TimerDirection.Reverse);
        }
    }

    void OnDestroy()
    {
        if (rt != null)
        {
            Destroy(rt);
        }
    }

    public void PlayMuzzleFlash()
    {
        shotTimer.Start();
        shotTimer.Rewind(0.375f);
        float angle = muzzleFlash.transform.localRotation.eulerAngles.z;
        muzzleFlash.transform.localRotation *= Quaternion.AngleAxis(angle + Random.Range(-10.0f, 10.0f), Vector3.forward);
    }
}
