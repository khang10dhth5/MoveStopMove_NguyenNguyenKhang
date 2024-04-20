using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Map : MonoBehaviour
{
    [SerializeField] private Player playerPrefabs;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float radiusMap;

    [HideInInspector] public Player player;

    public NavMeshData navMesh;
    public int enemyAmount;
    public int reward;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {

        player = Instantiate(playerPrefabs, startPoint.position, startPoint.rotation);
        CameraFollow.Instance.target = player.transform;
        for(int i = 0; i < enemyAmount; i++)
        {
            Enemy enemy=SimplePool.Spawn<Enemy>(PoolType.Bot, startPoint.position + new Vector3(Random.Range(-radiusMap,radiusMap), 0, Random.Range(-radiusMap, radiusMap)), startPoint.rotation);
            enemy.OnInit();
            LevelManager.Instance.listCharacter.Add(enemy);
        }
        OffscreenIndicator.InstantiateIndicators();

    }
}
