using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPauseGame : UICanvas
{
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMainMenu;


    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnResume.onClick.AddListener(() =>
        {
            ResumeButton();
        });

        btnRetry.onClick.AddListener(() =>
        {
            RetryButton();
        });
        btnMainMenu.onClick.AddListener(() =>
        {
            MainMenuButton();
        });
    
    }

    private void ResumeButton()
    {
        Close(0);
    }
    private void RetryButton()
    {
        Close(0);
        LevelManager.Instance.RetryGame();
    }

    private void MainMenuButton()
    {
        Close(0);
        LevelManager.Instance.DestroyMap();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }


}
