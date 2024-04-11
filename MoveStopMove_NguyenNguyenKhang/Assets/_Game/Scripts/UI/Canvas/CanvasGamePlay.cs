using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private Button btnSetting;

    public override void SetUp()
    {
        base.SetUp();
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();

        });
    }

    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
}
