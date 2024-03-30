using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator amin;
    [SerializeField] private AminState currentAmin;
    [SerializeField] private WeaponBase currentWeapon;

    public Character currentTarget;
    public List<Character> listTarget;

    public bool isDead;
    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        isDead = false;

    }

    public void AddTarget(Character target)
    {
        listTarget.Add(target);
    }
    public void RemoveTarget(Character target)
    {
        listTarget.Remove(target);
    }
    private void Dead()
    {
        OnDead();
    }
    public virtual void OnDead()
    {
        ChangeAmin(AminState.dead);
        isDead = true;
    }

    public void Throw()
    {
        if(currentTarget==null)
        {
            return;
        }
        ChangeAmin(AminState.attack);
        transform.LookAt(currentTarget.transform.position);

        Vector3 target=currentTarget.transform.position+Vector3.up;
        currentWeapon.Throw(this,target ,OnHitVictim);
        
    }

    private void OnHitVictim(Character attacker, Character victim)
    {
        victim.Dead();
        attacker.RemoveTarget(victim);
        attacker.SetNewTarget();
    }

    protected void ChangeAmin(AminState animation)
    {
        Debug.Log(animation);
        if(currentAmin==null)
        {
            currentAmin = AminState.idle;
        }
        if(currentAmin!=animation)
        {
            amin.ResetTrigger(currentAmin.ToString());
            currentAmin = animation;
            amin.SetTrigger(animation.ToString());
        }
    }

    internal void SetNewTarget()
    {
        currentTarget = null;
        if(listTarget.Count>0)
        {
            currentTarget = listTarget[UnityEngine.Random.Range(0, listTarget.Count)];
        }
    }
}
