using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public List<WeaponItemData> listWeapon;
}
[System.Serializable]
public class WeaponItemData
{
    public WeaponType weaponType;
    public int price;
    public float speed;
    public Sprite imgWeapon;
    public WeaponBase weaponPrefab;
}