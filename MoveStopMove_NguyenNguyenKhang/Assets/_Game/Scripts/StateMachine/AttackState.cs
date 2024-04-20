using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float timer;
    private float attackTime;
    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        timer = 0;
        attackTime =enemy.AttackTime;
    }
    public void OnExcute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if(enemy.currentTarget!=null && timer>=attackTime)
        {
            timer = 0;
            enemy.Throw();
        }
        else if(enemy.currentTarget==null)
        {
            enemy.ChangeState(new PatrolState());
        }
    }
    public void OnExit(Enemy enemy)
    {

    }
}
