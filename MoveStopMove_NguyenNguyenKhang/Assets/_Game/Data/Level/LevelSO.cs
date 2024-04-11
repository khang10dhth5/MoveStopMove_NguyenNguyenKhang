using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO :ScriptableObject
{
    public List<LevelItem> listLevel;
}
[System.Serializable]
public class LevelItem
{
    public int levelIndex;
    public Sprite imgLevel;
}
