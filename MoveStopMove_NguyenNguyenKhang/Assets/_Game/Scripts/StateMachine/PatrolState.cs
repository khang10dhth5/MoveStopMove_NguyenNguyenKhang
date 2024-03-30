using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    public void OnEnter(Enemy enemy)
    {
        enemy.Moving();

    }
    public void OnExcute(Enemy enemy)
    {
        if(enemy.currentTarget)
        {
            enemy.ChangeState(new AttackState());
        }
        else if(!enemy.isMoving)
        {
            enemy.nav.SetDestination(enemy.RandomDestination());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
