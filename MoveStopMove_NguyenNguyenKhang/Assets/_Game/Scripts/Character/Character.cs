using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    [SerializeField] private LevelCharacter levelCharacter;
    [SerializeField] private GameObject model;
    [SerializeField] private Animator amin;
    [SerializeField] private AminState currentAmin;
    [SerializeField] protected Transform weaponTransform;
    [SerializeField] protected Transform hatTransform;
    [SerializeField] protected Renderer pant;

    public Character currentTarget;
    public List<Character> listTarget;
    public int currentLevel;
    public bool isDead;

    protected Skin currentSkin = new Skin();

    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        isDead = false;
        currentLevel = 1;
        currentAmin = AminState.Idle;
        levelCharacter.SetLevel(currentLevel.ToString());
        model.transform.localScale = new Vector3(1, 1, 1);
    }
    public void SetLevel(int level)
    {
        currentLevel += level;
        model.transform.localScale =new Vector3(1,1,1)+ new Vector3(0.1f, 0.1f, 0.1f) * ( currentLevel);
        levelCharacter.SetLevel(currentLevel.ToString());
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
        ChangeAmin(AminState.Dead);
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
        ChangeAmin(AminState.Attack);
        transform.LookAt(currentTarget.transform.position);

        Vector3 target=currentTarget.transform.position+Vector3.up;
        currentSkin.weapon.Throw(this,target ,OnHitVictim);
        
    }

    private void OnHitVictim(Character attacker, Character victim)
    {
        victim.Dead();
        attacker.RemoveTarget(victim);
        attacker.SetLevel(victim.currentLevel);
        attacker.SetNewTarget();
        LevelManager.Instance.RemoveCharacter(victim);
        
    }

    protected void ChangeAmin(AminState animation)
    {
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
            if(currentTarget.isDead)
            {
                listTarget.Remove(currentTarget);
                SetNewTarget();
            }
        }

    }
}
