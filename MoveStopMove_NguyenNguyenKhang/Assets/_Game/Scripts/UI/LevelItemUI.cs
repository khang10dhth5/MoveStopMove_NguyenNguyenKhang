using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    [SerializeField] private Image imgLevel;
    [SerializeField] private Text txtLevel;
    [SerializeField] private Button btnOnClick;

    internal void SetLevel(LevelItem levelItem, Action<int> onClick)
    {
        imgLevel.sprite = levelItem.imgLevel;
        txtLevel.text = (levelItem.levelIndex+1).ToString();
        btnOnClick.onClick.AddListener(() =>
        {
            onClick.Invoke(levelItem.levelIndex);
        });
    }
}
