using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    public Character currentTarget;
    public List<Character> listTarget;

    public bool isDead;

    [SerializeField] private Animator amin;
    [SerializeField] private AminState currentAmin;
    [SerializeField] protected Transform weaponTransform;
    [SerializeField] protected Transform hatTransform;
    [SerializeField] protected Renderer pant;

    protected Skin currentSkin=new Skin();

    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
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
        if (currentTarget.isDead)
        {
            SetNewTarget();
            return;
        }
        ChangeAmin(AminState.attack);
        transform.LookAt(currentTarget.transform.position);

        Vector3 target=currentTarget.transform.position+Vector3.up;
        currentSkin.weapon.Throw(this,target ,OnHitVictim);
        
    }

    private void OnHitVictim(Character attacker, Character victim)
    {
        victim.Dead();
        attacker.RemoveTarget(victim);
        attacker.SetNewTarget();

        LevelManager.Instance.countCharacter();
    }

    protected void ChangeAmin(AminState animation)
    {
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
