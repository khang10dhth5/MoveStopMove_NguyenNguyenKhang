using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWin : UICanvas
{
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnNextLevel;
    [SerializeField] private Text txtReward;
    private void Start()
    {
        OnInit();
    }

    public override void SetUp()
    {
        base.SetUp();
        txtReward.text = LevelManager.Instance.currentMap.reward.ToString();
        GameManager.Instance.GetReward(LevelManager.Instance.currentMap.reward);
    }
    private void OnInit()
    {
        btnRetry.onClick.AddListener(() =>
        {
            RetryButton();
        });
        btnNextLevel.onClick.AddListener(() =>
        {
            NextLevelButton();
        });
    }
    private void RetryButton()
    {
        LevelManager.Instance.RetryGame();
    }
    private void NextLevelButton()
    {
        LevelManager.Instance.NextLevel();
    }
}

