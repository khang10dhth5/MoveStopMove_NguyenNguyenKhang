using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLose : UICanvas
{
    [SerializeField] private Button btnRetry;


    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnRetry.onClick.AddListener(() =>
        {
            RetryButton();
        });
    }

    private void RetryButton()
    {
        LevelManager.Instance.RetryGame();
    }
}
