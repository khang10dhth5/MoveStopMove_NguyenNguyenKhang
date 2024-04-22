using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPreview : MonoBehaviour
{
    [SerializeField] protected Transform weaponTransform;
    [SerializeField] protected Transform hatTransform;
    [SerializeField] protected Renderer pant;
    [SerializeField] private Transform modelTransform;
    private Skin currentSkin = new Skin();


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 lookTarget = Camera.main.WorldToScreenPoint(Input.mousePosition);
            Vector3 distance = lookTarget - transform.position;//lấy hướng đến điểm nhìn

            Quaternion dir = Quaternion.LookRotation(distance);//tạo gốc xoay
            dir.x = 0;
            dir.z = 0;//chỉ xoay theo trục y

            modelTransform.localRotation = Quaternion.Slerp(modelTransform.rotation, dir, 10 * Time.deltaTime);

        }
    }
    public  void SetCurrentSkin()
    {
        if (UnitDataManager.Instance.UnitData.currentPantIndex != -1)
        {
            SetPant((PantType)UnitDataManager.Instance.UnitData.currentPantIndex);
        }
        if (UnitDataManager.Instance.UnitData.currentHatIndex != -1)
        {
            SetHat((HatType)UnitDataManager.Instance.UnitData.currentHatIndex);
        }
        SetWeapon((WeaponType)UnitDataManager.Instance.UnitData.currentWeaponIndex);
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(currentSkin.hat);
        SimplePool.Despawn(currentSkin.weapon);
        currentSkin.hat = null;
        currentSkin.weapon = null;
    }
    public void SetPant( PantType pantType)
    {
        currentSkin.pant = SkinData.Instance.GetPant(pantType);
        pant.material = currentSkin.pant;
    }
    public void SetHat(HatType hatType)
    {
        if (currentSkin.hat != null)
        {
            SimplePool.Despawn(currentSkin.hat);
        }
        currentSkin.hat = SimplePool.Spawn<Hat>(KeyConstant.ConvertHatTypeToPoolType(hatType), hatTransform.position, hatTransform.rotation);
        currentSkin.hat.TF.SetParent(hatTransform);
    }

    public void SetWeapon(WeaponType weaponType)
    {
        if (currentSkin.weapon != null)
        {
            SimplePool.Despawn(currentSkin.weapon);
        }

        currentSkin.weapon = SimplePool.Spawn<WeaponBase>(KeyConstant.ConvertWeaponTypeToPoolType(weaponType), weaponTransform.position,weaponTransform.rotation);
        currentSkin.weapon.TF.SetParent(weaponTransform);
    }
}
