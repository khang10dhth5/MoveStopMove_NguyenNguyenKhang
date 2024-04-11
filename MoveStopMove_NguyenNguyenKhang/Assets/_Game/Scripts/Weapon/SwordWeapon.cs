using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponBase
{
    public override void Throw(Character character, Vector3 targetPos, Action<Character, Character> onHit)
    {
        base.Throw(character,targetPos, onHit);
        BulletBase bullet = SimplePool.Spawn<BulletBase>(PoolType.SwordBullet, bulletPoint.position, bulletPoint.rotation);
        bullet.OnInit(character,targetPos, onHit);
    }
}

