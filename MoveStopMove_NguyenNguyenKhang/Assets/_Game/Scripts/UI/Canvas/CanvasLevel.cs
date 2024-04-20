using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLevel : UICanvas
{
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnBackMainMenu;
    [SerializeField] private Text txtCoin;
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private LevelItemUI levelItemUI;
    [SerializeField] private LevelSO levelSO;


    private void Start()
    {
        OnInit();
    }

    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
    private void BackMainMenuButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    public override void SetUp()
    {
        base.SetUp();
        txtCoin.text = GameManager.Instance.Coin.ToString();
    }
    private void OnInit()
    {

        btnBackMainMenu.onClick.AddListener(() =>
        {
            BackMainMenuButton();
        });
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();
        });
        for (int i = 0; i < levelSO.listLevel.Count; i++)
        {
            LevelItemUI level = Instantiate(levelItemUI, gridLayoutGroup);
            level.SetLevel(levelSO.listLevel[i], OnClickLevelItemUI);
        }
    }
    private void OnClickLevelItemUI(int index)
    {
        LevelManager.Instance.CreateGame(index);
        gameObject.SetActive(false);
        Close(0);
    }
} 
