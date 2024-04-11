using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinData : SingletonMono<SkinData>
{
    public HatSO hatSO;
    public PantSO pantSO;
    public WeaponSO weaponSO;

    public GameObject GetHat(HatType hatType)
    {
        for (int i = 0; i < hatSO.listHat.Count; i++)
        {
            if (hatSO.listHat[i].hatType == hatType)
            {
                return hatSO.listHat[i].hatPrefab;
            }
        }
        return null;
    }

    public Material GetPant(PantType pantType)
    {
        Debug.Log(pantType);
        for (int i = 0; i < pantSO.listPant.Count; i++)
        {
            if (pantSO.listPant[i].pantType == pantType)
            {
                return pantSO.listPant[i].material;
            }
        }
        return null;
    }

    public WeaponBase GetWeapon(WeaponType weaponType)
    {
        for (int i = 0; i < weaponSO.listWeapon.Count; i++)
        {
            if (weaponSO.listWeapon[i].weaponType == weaponType)
            {
                return weaponSO.listWeapon[i].weaponPrefab;
            }
        }
        return null;
    }
}
