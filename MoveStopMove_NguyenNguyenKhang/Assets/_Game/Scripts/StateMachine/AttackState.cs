using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private float timer;
    private float randomTime;
    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        timer = 0;
        randomTime = Random.Range(1f,3f);
    }
    public void OnExcute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if(enemy.currentTarget!=null && timer>=randomTime)
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
