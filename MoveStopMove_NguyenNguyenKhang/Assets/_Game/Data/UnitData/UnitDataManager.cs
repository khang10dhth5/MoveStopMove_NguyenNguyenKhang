using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDataManager :SingletonMono<UnitDataManager>
{
    private UnitData unitData;

    public UnitData UnitData { get => unitData; set => unitData = value; }

    private void Start()
    {
        UnitData = LoadData();
    }
    public void SaveUnitData(UnitData unitData)
    {
        string s = JsonUtility.ToJson(unitData);
        PlayerPrefs.SetString(KeyConstant.KEY_DATA, s);
    }
    public void SaveUnitData()
    {
        string s = JsonUtility.ToJson(unitData);
        PlayerPrefs.SetString(KeyConstant.KEY_DATA, s);
    }

    public UnitData LoadData()
    {
        string s = PlayerPrefs.GetString(KeyConstant.KEY_DATA);
        if (string.IsNullOrEmpty(s))
        {
            return new UnitData();
        }
        return JsonUtility.FromJson<UnitData>(s);
    }
    [ContextMenu("SaveData")]
    private void Save()
    {
        UnitData data = new UnitData();
        SaveUnitData(data);
    }

    [ContextMenu("ClearData")]
    private void ClearData()
    {
        PlayerPrefs.DeleteKey(KeyConstant.KEY_DATA);
    }
}
