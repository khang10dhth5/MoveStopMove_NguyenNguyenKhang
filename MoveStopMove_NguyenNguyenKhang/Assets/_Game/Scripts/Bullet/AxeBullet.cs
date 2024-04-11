using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBullet :BulletBase
{
    private Vector3 direction;
    private void Start()
    {
        direction = (targetPos - transform.position).normalized;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position+= direction *moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime);
    }
}
