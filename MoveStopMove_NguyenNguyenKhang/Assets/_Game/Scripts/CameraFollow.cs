using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : SingletonMono<CameraFollow>
{
    [SerializeField] private Transform TF;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float moveSpeed;

    [HideInInspector] public Transform target;

    private void LateUpdate()
    {
        if (target)
        {
            TF.position =Vector3.MoveTowards(TF.position, target.position + offset, moveSpeed*Time.deltaTime);
            TF.LookAt(target);
        }
    }
}
