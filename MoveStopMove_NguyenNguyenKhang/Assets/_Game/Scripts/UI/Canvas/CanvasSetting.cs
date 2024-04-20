using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSetting :UICanvas
{
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnSound;

    private void Start()
    {
        OnInit();
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    private void OnInit()
    {
        btnClose.onClick.AddListener(() =>
        {
            CloseButton();
        });
    }

    private void CloseButton()
    {
        Close(0);
    }
}
