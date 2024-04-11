using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //public FixedJoystick joystick;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;

    public override void OnDead()
    {
        base.OnDead();
        EndGame();
    }

    private void EndGame()
    {
        GameManager.Instance.EndGame(false);
    }

    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
        GetSkin();
    }

    public void GetSkin()
    {
        GetWeapon();
        GetHat();
        GetPant();
    }

    public void GetPant()
    {
        for (int i = 0; i < SkinData.Instance.pantSO.listPant.Count; i++)
        {
            if (!PlayerPrefs.HasKey(KeyConstant.PANT + i))
            {
                PlayerPrefs.SetInt(KeyConstant.PANT + i, 0);
            }
            else if(!PlayerPrefs.HasKey(KeyConstant.CURRENT_PANT))
            {
                continue;
            }
            else if (PlayerPrefs.GetInt(KeyConstant.CURRENT_PANT) == i)
            {
                currentSkin.pant = SkinData.Instance.GetPant((PantType)i);
                pant.material = currentSkin.pant;
            }
        }
    }
    public void GetHat()
    {

        for (int i = 0; i < SkinData.Instance.hatSO.listHat.Count; i++)
        {
            if (!PlayerPrefs.HasKey(KeyConstant.HAT + i))
            {
                PlayerPrefs.SetInt(KeyConstant.HAT + i, 0);
            }
            else if (!PlayerPrefs.HasKey(KeyConstant.CURRENT_HAT))
            {
                continue;
            }
            else if (PlayerPrefs.GetInt(KeyConstant.CURRENT_HAT) == i)
            {
                GameObject hat = SkinData.Instance.hatSO.listHat[i].hatPrefab;
                currentSkin.hat = Instantiate(hat, hatTransform);
            }
        }
    }

    public void GetWeapon()
    {
        for (int i = 0; i < SkinData.Instance.weaponSO.listWeapon.Count; i++)
        {
            if (!PlayerPrefs.HasKey(KeyConstant.WEAPON + i))
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt(KeyConstant.WEAPON + i, 1);
                }
                else
                {
                    PlayerPrefs.SetInt(KeyConstant.WEAPON + i, 0);
                }
            }
            else if (!PlayerPrefs.HasKey(KeyConstant.CURRENT_WEAPON))
            {
                WeaponBase weapon = SkinData.Instance.weaponSO.listWeapon[0].weaponPrefab;
                currentSkin.weapon = Instantiate(weapon, weaponTransform);
                PlayerPrefs.SetInt(KeyConstant.CURRENT_WEAPON, i);
            }
            else if (PlayerPrefs.GetInt(KeyConstant.CURRENT_WEAPON) == i)
            {
                WeaponBase weapon = SkinData.Instance.weaponSO.listWeapon[i].weaponPrefab;
                currentSkin.weapon = Instantiate(weapon, weaponTransform);
            }
        }
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = JoystickControl.direct * moveSpeed * Time.deltaTime;
                if (JoystickControl.direct != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(rb.velocity);
                    ChangeAmin(AminState.run);
                }
                else
                {
                    ChangeAmin(AminState.idle);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Throw();
                ChangeAmin(AminState.attack);
            }
        }
       
    }
}
