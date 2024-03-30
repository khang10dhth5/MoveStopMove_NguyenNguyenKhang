using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponBase
{

    [SerializeField] private Transform bulletPoint;
    [SerializeField] private BulletBase bulletPrefab;

    public override void Throw(Character character, Vector3 targetPos, Action<Character, Character> onHit)
    {
        base.Throw(character,targetPos, onHit);
        BulletBase bullet = SimplePool.Spawn<BulletBase>(PoolType.ArrowBullet, bulletPoint.position, bulletPoint.rotation);
        bullet.OnInit(character,targetPos, onHit);
    }
}

