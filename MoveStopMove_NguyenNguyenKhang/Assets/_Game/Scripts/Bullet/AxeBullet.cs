using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBullet :BulletBase
{
    public override void OnEnable()
    {
        base.OnEnable();
        Invoke(nameof(OnDespawn), timeActive);
    }
    // Update is called once per frame
    void Update()
    {
        TF.position = Vector3.MoveTowards(TF.position, targetPos, moveSpeed * Time.deltaTime);
        

    }
}
