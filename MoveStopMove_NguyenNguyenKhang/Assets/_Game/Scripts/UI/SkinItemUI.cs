using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinItemUI : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Text txtName;

    public void SetSkinItemUI(ItemType itemType, ToggleGroup toggleGroup, string name)
    {
        this.itemType = itemType;
        toggle.group = toggleGroup;
        txtName.text = name;
    }
    public void OnChangValue()
    {
        if(toggle.isOn)
        {
            if(UIManager.Instance.IsUIOpened<CanvasShop>())
            {
                ShopManager.Instance.ChangeItemShop(itemType);
            }
            if (UIManager.Instance.IsUIOpened<CanvasCollect>())
            {
                CollectManager.Instance.ChangeItemCollect(itemType);
            }
        }
    }
}
