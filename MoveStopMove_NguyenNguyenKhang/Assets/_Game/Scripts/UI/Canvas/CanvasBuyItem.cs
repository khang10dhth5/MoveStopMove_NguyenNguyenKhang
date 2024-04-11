using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBuyItem : UICanvas
{
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;

    public override void SetUp()
    {
        base.SetUp();
        btnNo.onClick.AddListener(() =>
        {
            Close(0);
        });

        btnYes.onClick.AddListener(() =>
        {
            if (ShopManager.Instance.shopItemSelected.shopItem.itemType == ItemType.Weapon)
            {
                PlayerPrefs.SetInt(KeyConstant.WEAPON + ShopManager.Instance.shopItemSelected.shopItem.itemIndex, 1);
            }
            if (ShopManager.Instance.shopItemSelected.shopItem.itemType == ItemType.Hat)
            {
                PlayerPrefs.SetInt(KeyConstant.HAT + ShopManager.Instance.shopItemSelected.shopItem.itemIndex, 1);
            }
            if (ShopManager.Instance.shopItemSelected.shopItem.itemType == ItemType.Pant)
            {
                PlayerPrefs.SetInt(KeyConstant.PANT + ShopManager.Instance.shopItemSelected.shopItem.itemIndex, 1);
            }

            ShopManager.Instance.listItemUI.Remove(ShopManager.Instance.shopItemSelected);
            Destroy(ShopManager.Instance.shopItemSelected.gameObject);
            Close(0);
        });
    }
}
