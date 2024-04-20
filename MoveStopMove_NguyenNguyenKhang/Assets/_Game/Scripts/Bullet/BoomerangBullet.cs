using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBullet : BulletBase
{
    private Vector3 startPoint;

    public override void OnEnable()
    {
        startPoint = TF.position;
        base.OnEnable();
        Invoke(nameof(OnDespawn), timeActive);
    }
    // Update is called once per frame
    void Update()
    {
        TF.position = Vector3.MoveTowards(TF.position, targetPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < 0.5f)
        {
            targetPos = startPoint;
        }
    }
}
