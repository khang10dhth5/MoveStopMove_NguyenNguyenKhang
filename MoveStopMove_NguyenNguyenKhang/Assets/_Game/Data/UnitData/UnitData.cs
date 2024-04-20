using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData
{
    public int currentWeaponIndex;
    public int currentHatIndex;
    public int currentPantIndex;

    public List<bool> listWeapon = new List<bool>();
    public List<bool> listHat = new List<bool>();
    public List<bool> listPant = new List<bool>();
    public UnitData()
    {
        currentWeaponIndex = 0;
        currentHatIndex = -1;
        currentPantIndex = -1;
        //weapon
        for(int i=0;i<SkinData.Instance.weaponSO.listWeapon.Count;i++)
        {
            if(i==0)
            {
                listWeapon.Add(true);
            }
            else
            {
                listWeapon.Add(false);
            }
        }

        //hat
        for (int i = 0; i < SkinData.Instance.hatSO.listHat.Count; i++)
        {
            listHat.Add(false);
        }

        //pant
        for (int i = 0; i < SkinData.Instance.pantSO.listPant.Count; i++)
        {
            listPant.Add(false);
        }

    }
    
}
