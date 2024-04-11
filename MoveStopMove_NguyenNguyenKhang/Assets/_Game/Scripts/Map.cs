using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Map : MonoBehaviour
{
    public NavMeshData navMesh;
    public int enemyAmount;

    [HideInInspector] public Player player;

    [SerializeField] private Player playerPrefabs;
    [SerializeField] private Transform startPoint;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        player = Instantiate(playerPrefabs, startPoint.position, startPoint.rotation);
        //player.joystick = UIManager.Instance.joystick;
        CameraFollow.Instance.target = player.transform;
 
        for(int i = 0; i < enemyAmount; i++)
        {
            SimplePool.Spawn<Enemy>(PoolType.Bot, startPoint.position + new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), startPoint.rotation);
        }

    }
}
