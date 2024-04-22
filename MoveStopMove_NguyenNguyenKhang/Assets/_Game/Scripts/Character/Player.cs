using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;

    public override void OnInit()
    {
        base.OnInit();
        GetSkin();
    }
    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = JoystickControl.direct * moveSpeed * Time.deltaTime;
                if (JoystickControl.direct != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(rb.velocity);
                    ChangeAmin(AminState.Run);
                }
                else
                {
                    ChangeAmin(AminState.Idle);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                ChangeAmin(AminState.Attack);
                Throw();

            }
        }

    }
    public void GetSkin()
    {
        GetWeapon();
        GetHat();
        GetPant();
    }

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
   
    private void GetPant()
    {
        if(UnitDataManager.Instance.UnitData.currentPantIndex!=-1)
        {
            currentSkin.pant = SkinData.Instance.GetPant((PantType)UnitDataManager.Instance.UnitData.currentPantIndex);
            pant.material = currentSkin.pant;
        }

    }
    private void GetHat()
    {
   
        if (UnitDataManager.Instance.UnitData.currentHatIndex!= -1)
        {
            currentSkin.hat = SimplePool.Spawn<Hat>(KeyConstant.ConvertHatTypeToPoolType((HatType)UnitDataManager.Instance.UnitData.currentHatIndex), hatTransform.position, hatTransform.rotation);
            currentSkin.hat.TF.SetParent(hatTransform);
        }
    }

    private void GetWeapon()
    {
        currentSkin.weapon = SimplePool.Spawn<WeaponBase>(KeyConstant.ConvertWeaponTypeToPoolType((WeaponType)UnitDataManager.Instance.UnitData.currentWeaponIndex), weaponTransform.position, weaponTransform.rotation);
        currentSkin.weapon.TF.SetParent(weaponTransform);
    }
    private void OnDestroy()
    {
        SimplePool.Despawn(currentSkin.weapon);
        SimplePool.Despawn(currentSkin.hat);
    }

}
