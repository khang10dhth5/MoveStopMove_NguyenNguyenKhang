using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatData", menuName = "ScriptableObjects/HatSO")]
public class HatSO : ScriptableObject
{
    public List<HatItemData> listHat;
}
[System.Serializable]
public class HatItemData
{
    public HatType hatType;
    public int price;
    public Sprite imgHat;
    public Hat hatPrefab;
}