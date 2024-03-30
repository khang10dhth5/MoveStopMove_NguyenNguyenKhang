using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    public override void OnDead()
    {
        base.OnDead();
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
                ChangeAmin(AminState.run);

            }
            else
            {
                ChangeAmin(AminState.idle);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Throw();
                ChangeAmin(AminState.attack);
            }
        }
        
    }
}
