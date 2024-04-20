using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : SingletonMono<LevelManager>
{
    [SerializeField] private Map[] listMapPrefab;

    [HideInInspector] public Map currentMap;

    public List<Character> listCharacter;

    private int currentLevel;
    
    internal void CreateGame(int index)
    {
        listCharacter = new List<Character>();
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        Map map = listMapPrefab[index];
        currentMap = Instantiate(map);
        currentLevel = index;

        NavMesh.RemoveAllNavMeshData();
        NavMesh.AddNavMeshData(currentMap.navMesh);
        
    }
    public void RemoveCharacter(Character character)
    {
        listCharacter.Remove(character);
        if (listCharacter.Count==0 && !currentMap.player.isDead)
        {
            GameManager.Instance.EndGame(true);
        }
    }
    public void DestroyMap()
    {
        OffscreenIndicator.DestroyIndicator();
        UIManager.Instance.CloseAll();
        Destroy(currentMap.player.gameObject);
        Destroy(currentMap.gameObject);
        SimplePool.CollectAll();
    }
    public void RetryGame()
    {
        DestroyMap();
        Invoke(nameof(CreateNewGame), 0.2f);
    }
    private void CreateNewGame()
    {
        CreateGame(currentLevel);
    }
    public void NextLevel()
    {
        
        currentLevel += 1;
        if(currentLevel>=listMapPrefab.Length)
        {
            currentLevel -= 1;
            return;
        }
        DestroyMap();
        CreateGame(currentLevel);
    }
}
