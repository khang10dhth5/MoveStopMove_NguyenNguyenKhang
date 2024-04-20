using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnPauseGame;
    [SerializeField] private Text txtCoin;
    private void Start()
    {
        OnInit();
    }
    public override void SetUp()
    {
        base.SetUp();
        txtCoin.text = GameManager.Instance.Coin.ToString();
    }
    private void OnInit()
    {
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();

        });
        btnPauseGame.onClick.AddListener(() =>
        {
            PauseGameButton();
        });
    }

    private void PauseGameButton()
    {
        UIManager.Instance.OpenUI<CanvasPauseGame>();
    }
    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
}
