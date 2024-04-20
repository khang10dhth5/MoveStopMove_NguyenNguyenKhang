using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBullet : BulletBase
{

    public override void OnEnable()
    {
        base.OnEnable();
        Invoke(nameof(OnDespawn), timeActive);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
