using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PantData", menuName = "ScriptableObjects/PantSO")]
public class PantSO :ScriptableObject
{
    public List<PantItemData> listPant;
}
[System.Serializable]
public class PantItemData
{
    public PantType pantType;
    public int price;
    public Sprite imgPant;
    public Material material;
}