using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float moveSpeed;
    private void LateUpdate()
    {
        if (target)
        {
            transform.position =Vector3.MoveTowards(transform.position, target.position + offset, moveSpeed);
            transform.LookAt(target);
        }
    }
}
