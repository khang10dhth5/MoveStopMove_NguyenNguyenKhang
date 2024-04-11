using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : SingletonMono<LevelManager>
{
    public int characterAmount;

    private Map currentMap;
    private int currentLevel;
    
    internal void CreateGame(int index)
    {
        Map map = Resources.Load<Map>(KeyConstant.MAP_PATH + index);
        currentMap = Instantiate(map);
        currentLevel = index;

        NavMesh.RemoveAllNavMeshData();
        NavMesh.AddNavMeshData(currentMap.navMesh);

        characterAmount = currentMap.enemyAmount + 1;

        UIManager.Instance.OpenUI<CanvasGamePlay>();
    }
    public void countCharacter()
    {
        characterAmount--;
        if(characterAmount==1 && !currentMap.player.isDead)
        {
            GameManager.Instance.EndGame(true);
        }
    }
    public void DestroyMap()
    {
        UIManager.Instance.CloseAll();
        Destroy(currentMap.player.gameObject);
        Destroy(currentMap.gameObject);
    }
    public void RetryGame()
    {
        DestroyMap();
        CreateGame(currentLevel);
    }
    public void NextLevel()
    {
        DestroyMap();
        currentLevel += 1;
        CreateGame(currentLevel);
    }
}
