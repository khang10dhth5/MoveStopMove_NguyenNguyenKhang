using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBuyItem : UICanvas
{
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnNo.onClick.AddListener(() =>
        {
            Close(0);
        });

        btnYes.onClick.AddListener(() =>
        {
            ShopItem shopItem = ShopManager.Instance.shopItemSelected.shopItem;

            if (shopItem.itemType == ItemType.Weapon)
            {
                UnitDataManager.Instance.UnitData.listWeapon[shopItem.itemIndex]= true;
            }
            if (shopItem.itemType == ItemType.Hat)
            {
                UnitDataManager.Instance.UnitData.listHat[shopItem.itemIndex] = true;
            }
            if (shopItem.itemType == ItemType.Pant)
            {
                UnitDataManager.Instance.UnitData.listPant[shopItem.itemIndex] = true;
            }
            UnitDataManager.Instance.SaveUnitData();

            GameManager.Instance.GetReward(-shopItem.price);
            ShopManager.Instance.listItemUI.Remove(ShopManager.Instance.shopItemSelected);
            Destroy(ShopManager.Instance.shopItemSelected.gameObject);
            Close(0);
        });
    }
}
