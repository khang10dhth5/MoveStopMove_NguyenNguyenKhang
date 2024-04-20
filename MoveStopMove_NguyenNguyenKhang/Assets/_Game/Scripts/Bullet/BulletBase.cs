using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : GameUnit
{

    [SerializeField] protected float timeActive;
    [SerializeField] protected float moveSpeed;

    protected Character attacker;
    protected Vector3 targetPos;
    protected Action<Character, Character> onHit;

    public virtual void OnEnable()
    {
        if (attacker != null)
        {
            TF.localScale = new Vector3(1, 1, 1) + new Vector3(0.1f, 0.1f, 0.1f) * (attacker.currentLevel);
        }
    }
    public virtual void OnInit(Character attacker, Vector3 targetPos, Action<Character, Character> onHit)
    {
        this.attacker = attacker;
        this.targetPos = targetPos;
        this.onHit = onHit;
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(KeyConstant.TAG_CHACRACTER))
        {
            Character victim = Cache.GetCharacter(other);
            if(victim!=attacker)
            {
                onHit?.Invoke(attacker, victim);
                OnDespawn();
            }
        }
    }

}

public static class Cache
{
    public static Dictionary<Collider, Character> characters = new Dictionary<Collider, Character>();
    public static Character GetCharacter(Collider collider)
    {
        if(!characters.ContainsKey(collider))
        {
            characters.Add(collider, collider.GetComponent<Character>());
        }
        return characters[collider];
    }
}
