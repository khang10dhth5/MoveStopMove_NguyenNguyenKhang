using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    [SerializeField] PoolAmount[] poolAmounts;
    private void Awake()
    {
        for(int i=0;i<poolAmounts.Length;i++)
        {
            SimplePool.Preload(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
        }
    }
}
[System.Serializable]
public class PoolAmount
{
    public GameUnit prefab;
    public Transform parent;
    public int amount;
}
public enum PoolType
{
    AxeWeapon=0,
    BoomerangWeapon=1,
    SwordWeapon=2,
    AxeBullet=3,
    BoomerangBullet=4,
    SwordBullet=5,
    ArrowHat=6,
    CowboyHat=7,
    CrownHat=8,
    EarHat=9,
    HeadPhoneHat=10,
    HornHat=11,
    PolliceHat=12,
    StrawHat=13,
    Bot=14,

}