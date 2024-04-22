using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private float radius;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private float idleTime;
    [SerializeField] private float attackTime;
    private bool isMoving;

    public NavMeshAgent Nav { get => nav; set => nav = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public float IdleTime { get => idleTime; set => idleTime = value; }
    public float AttackTime { get => attackTime; set => attackTime = value; }

    private IState currentState;

    private void Update()
    {
        if(currentState!=null && !isDead)
        {
            currentState.OnExcute(this);
        }
        if(Vector3.Distance(TF.position, Nav.destination)<0.5f)
        {
            IsMoving = false;
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        currentState = new IdleState();
        IsMoving = false;
        GetSkin();
    }

    public  void GetSkin()
    {

        int weaponIndex = UnityEngine.Random.Range(0, SkinData.Instance.weaponSO.listWeapon.Count);
        currentSkin.weapon = SimplePool.Spawn<WeaponBase>(KeyConstant.ConvertWeaponTypeToPoolType((WeaponType)weaponIndex), weaponTransform.position, weaponTransform.rotation);
        currentSkin.weapon.TF.SetParent(weaponTransform);

        int hatIndex = UnityEngine.Random.Range(0, SkinData.Instance.hatSO.listHat.Count);
        currentSkin.hat = SimplePool.Spawn<Hat>(KeyConstant.ConvertHatTypeToPoolType((HatType)hatIndex), hatTransform.position, hatTransform.rotation);
        currentSkin.hat.TF.SetParent(hatTransform);


        int pantIndex = UnityEngine.Random.Range(0, SkinData.Instance.pantSO.listPant.Count);
        currentSkin.pant = SkinData.Instance.GetPant((PantType)pantIndex);
        pant.material= currentSkin.pant;

    }

    public Vector3 RandomDestination()
    {
          IsMoving =true;

          Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
          randomDirection += TF.position;
          NavMeshHit hit;
          Vector3 finalPosition = Vector3.zero;

          if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
          {
                    finalPosition = hit.position;
          }

          return finalPosition;
    }
    internal void Moving()
    {
        ChangeAmin(AminState.Run);

    }

    public override void OnDead()
    {
        base.OnDead();
        Invoke(nameof(DestroyEnemy), 2f);
    }
    private void DestroyEnemy()
    {
        SimplePool.Despawn(this);
    }
    internal void StopMoving()
    {
        Nav.destination = TF.position;
        ChangeAmin(AminState.Idle);
        IsMoving = false;
    }

    internal void ChangeState(IState state)
    {
        currentState = state;
        currentState.OnEnter(this);
    }
}
