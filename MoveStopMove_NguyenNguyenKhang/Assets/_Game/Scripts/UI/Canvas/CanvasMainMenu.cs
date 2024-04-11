using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnCollect;
    [SerializeField] private Button btnPlayGame;


    public override void SetUp()
    {
        base.SetUp();
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();
        });
        btnShop.onClick.AddListener(() =>
        {
            ShopButton();
        });
        btnCollect.onClick.AddListener(() =>
        {
            CollectButton();
        });
        btnPlayGame.onClick.AddListener(() =>
        {
            PlayButton();
        });

    }

    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }

    private void ShopButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasShop>();
    }

    private void CollectButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasCollect>();
    }
    private void PlayButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasLevel>();
    }
}
