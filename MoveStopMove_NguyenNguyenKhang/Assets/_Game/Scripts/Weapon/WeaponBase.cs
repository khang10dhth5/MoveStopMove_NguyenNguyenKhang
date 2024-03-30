using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    
    public virtual void Throw( Character character, Vector3 targetPos,Action<Character,Character> onHit)
    {

    }
}
