using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCharacter : MonoBehaviour
{
    [SerializeField] private Transform TF;
    [SerializeField] private Text txtLevel;
    // Update is called once per frame
    void Update()
    {
        TF.rotation =Quaternion.Euler( Vector3.zero);
    }
    public void SetLevel(string strLevel)
    {
        txtLevel.text = strLevel;
    }
}
