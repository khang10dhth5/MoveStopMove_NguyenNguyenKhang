using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public NavMeshAgent nav;
    public bool isMoving;

    [SerializeField] private float radius;
    private IState currentState;

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
        if(Vector3.Distance(transform.position, nav.destination)<0.5f)
        {
            isMoving = false;
        }
    }
    private void Awake()
    {
    }

    public override void OnInit()
    {
        GetSkin();

        base.OnInit();
        currentState = new IdleState();
        isMoving = false;
        
    }

    public  void GetSkin()
    {

        int weaponIndex = UnityEngine.Random.Range(0, SkinData.Instance.weaponSO.listWeapon.Count);
        WeaponBase weapon = SkinData.Instance.GetWeapon((WeaponType)0);
        currentSkin.weapon = Instantiate(weapon,weaponTransform);

        int hatIndex = UnityEngine.Random.Range(0, SkinData.Instance.hatSO.listHat.Count);
        GameObject hat = Instantiate(SkinData.Instance.GetHat((HatType)hatIndex), hatTransform);
        currentSkin.hat = hat;


        int pantIndex = UnityEngine.Random.Range(0, SkinData.Instance.pantSO.listPant.Count);
        currentSkin.pant = SkinData.Instance.GetPant((PantType)pantIndex);
        pant.material= currentSkin.pant;

    }

    public Vector3 RandomDestination()
    {
          isMoving =true;

          Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
          randomDirection += transform.position;
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
        ChangeAmin(AminState.run);

    }

    public override void OnDead()
    {
        base.OnDead();
        //Destroy(gameObject, 2f);
        Invoke("DestroyEnemy", 2f);
    }
    private void DestroyEnemy()
    {
        SimplePool.Despawn(this);
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
