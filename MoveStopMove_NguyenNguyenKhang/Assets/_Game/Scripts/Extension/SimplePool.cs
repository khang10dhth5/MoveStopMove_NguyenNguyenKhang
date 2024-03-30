using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{
    private static Dictionary<PoolType, Pool> poolInstance = new Dictionary<PoolType, Pool>();


    //khởi tạo các Pool
    public static void Preload(GameUnit prefab, int amount, Transform parent)
    {
        if(prefab==null)
        {
            Debug.LogError("prefab is Empty");
        }
        if(!poolInstance.ContainsKey(prefab.poolType)||poolInstance[prefab.poolType]==null)
        {
            Pool p = new Pool();
            p.Preload(prefab, amount, parent);
            poolInstance[prefab.poolType] = p;
        }
    }

    //lấy phần tử từ 1 pool
    public static T Spawn<T>(PoolType poolType, Vector3 pos, Quaternion rot) where T:GameUnit
    {
        if(!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "is not Preload");
            return null;
        }
        return poolInstance[poolType].Spawn(pos, rot) as T;
    }

    //trả phần tử vể pool
    public static void Despawn(GameUnit unit)
    {
        if (!poolInstance.ContainsKey(unit.poolType))
        {
            Debug.LogError(unit.poolType + "is not Preload");
            return;
        }
        poolInstance[unit.poolType].Despawn(unit);
    }

    //thu tập phần tử của 1 pool
    public static void Collect(PoolType poolType)
    {
        if(!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "is not preload");
            return;
        }
        poolInstance[poolType].Collect();
    }

    //thu thập phần tử của tất cả pool
    public static void CollectAll()
    {
        foreach(Pool item in poolInstance.Values)
        {
            item.Collect();
        }
    }

    //xóa phần tử của 1 pool
    public static void Release(PoolType poolType)
    {
        if (!poolInstance.ContainsKey(poolType))
        {
            Debug.LogError(poolType + "is not preload");
            return;
        }
        poolInstance[poolType].Release();
    }

    //xóa phần tử của tất cả pool
    public static void ReleaseAll()
    {
        foreach(Pool item in poolInstance.Values)
        {
            item.Release();
        }
    }

}
public class Pool
{
    Transform parent;
    GameUnit prefab;
    
    //list chứa các GameUnit trong Pool
    Queue<GameUnit> inactives = new Queue<GameUnit>();
    
    //list chứa các GameUnit đang được sử dụng
    List<GameUnit> actives = new List<GameUnit>();


    //khởi tạo pool
    public void Preload(GameUnit prefab, int amount, Transform parent)
    {
        this.parent = parent;
        this.prefab = prefab;
        for(int i=0;i<amount;i++)
        {
            Despawn(GameObject.Instantiate(prefab, parent));
        }
    }
    //lấy phần tử ra từ pool
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;
        if(inactives.Count<=0)
        {
            unit = GameObject.Instantiate(prefab, parent);
        }
        else
        {
            unit=inactives.Dequeue();
        }
        unit.TF.SetPositionAndRotation(pos, rot);
        actives.Add(unit);
        unit.gameObject.SetActive(true);

        return unit;
    }

    //trả phần tử vào trong pool
    public void Despawn(GameUnit unit)
    {
        if(unit!=null && unit.gameObject.activeSelf)
        {
            actives.Remove(unit);
            inactives.Enqueue(unit);
            unit.gameObject.SetActive(false);
        }
    }

    //thu thập tất cả các phần tử đang dùng về pool
    public void Collect()
    {
        while(actives.Count>0)
        {
            Despawn(actives[0]);
        }
    }

    //destroy tất cả các phần tử
    public void Release()
    {
        Collect();
        while(inactives.Count>0)
        {
            GameObject.Destroy(inactives.Dequeue().gameObject);
        }
        inactives.Clear();
    }
}