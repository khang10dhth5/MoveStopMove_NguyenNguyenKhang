using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    private IState currentState;
    public NavMeshAgent nav;
    public bool isMoving;
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        if(currentState!=null && !isDead)
        {
            currentState.OnExcute(this);
        }
        Debug.Log(Vector3.Distance(transform.position, nav.destination));
        if(Vector3.Distance(transform.position, nav.destination)<0.5f)
        {
            isMoving = false;
        }
    }


    private void OnInit()
    {
        currentState = new IdleState();
        isMoving = false;
    }

    public Vector3 RandomDestination()
    {
          isMoving =true;

          Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * nav.radius;
          randomDirection += transform.position;
          NavMeshHit hit;
          Vector3 finalPosition = Vector3.zero;

          if (NavMesh.SamplePosition(randomDirection, out hit, nav.radius, 1))
          {
                    finalPosition = hit.position;
          }

          return finalPosition;
    }
    internal void Moving()
    {
        ChangeAmin(AminState.run);

    }

    public override void OnDead()
    {
        base.OnDead();
        Destroy(gameObject, 2f);
    }
    internal void StopMoving()
    {
        nav.destination = transform.position;
        ChangeAmin(AminState.idle);
        isMoving = false;
    }

    internal void ChangeState(IState state)
    {
        currentState = state;
        currentState.OnEnter(this);
    }
}
