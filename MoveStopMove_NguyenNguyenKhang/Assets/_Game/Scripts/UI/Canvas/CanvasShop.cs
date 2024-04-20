using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasShop : UICanvas
{
    [SerializeField] private Button btnBackMainMenu;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnBuyItem;
    [SerializeField] private Text txtCoin;
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private ToggleGroup SkinToggleGroup;
    [SerializeField] private ToggleGroup shopItemUIToggleGroup;
    [SerializeField] private SkinItemUI skinItemUIPrefab;
    [SerializeField] private ShopItemUI shopItemUIPrefab;

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
        btnBackMainMenu.onClick.AddListener(() =>
        {
            BackMainMenuButton();
        });
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();
        });
        btnBuyItem.onClick.AddListener(() =>
        {
            BuyItemButton();
        });
        //load weapon, hat, pant
        for (int i = 0; i < SkinData.Instance.weaponSO.listWeapon.Count; i++)
        {
            if (UnitDataManager.Instance.UnitData.listWeapon[i] == false)
            {
                WeaponItemData weaponItemData = SkinData.Instance.weaponSO.listWeapon[i];
                ShopItem shopItem = new ShopItem(ItemType.Weapon, i, weaponItemData.imgWeapon, weaponItemData.price);

                ShopItemUI shopItemUI = Instantiate(shopItemUIPrefab, shopItemUIToggleGroup.transform);
                shopItemUI.SetShopItem(shopItem, shopItemUIToggleGroup);
                ShopManager.Instance.listItemUI.Add(shopItemUI);
            }

        }

        for (int i = 0; i < SkinData.Instance.hatSO.listHat.Count; i++)
        {

            if (UnitDataManager.Instance.UnitData.listHat[i] == false)
            {
                HatItemData hatItemData = SkinData.Instance.hatSO.listHat[i];
                ShopItem shopItem = new ShopItem(ItemType.Hat, i, hatItemData.imgHat, hatItemData.price);

                ShopItemUI shopItemUI = Instantiate(shopItemUIPrefab, shopItemUIToggleGroup.transform);
                shopItemUI.SetShopItem(shopItem, shopItemUIToggleGroup);
                ShopManager.Instance.listItemUI.Add(shopItemUI);
            }
        }

        for (int i = 0; i < SkinData.Instance.pantSO.listPant.Count; i++)
        {

            if(UnitDataManager.Instance.UnitData.listPant[i] == false)
            {
                PantItemData pantItemData = SkinData.Instance.pantSO.listPant[i];
                ShopItem shopItem = new ShopItem(ItemType.Pant, i, pantItemData.imgPant, pantItemData.price);

                ShopItemUI shopItemUI = Instantiate(shopItemUIPrefab, shopItemUIToggleGroup.transform);
                shopItemUI.SetShopItem(shopItem, shopItemUIToggleGroup);
                ShopManager.Instance.listItemUI.Add(shopItemUI);
            }
        }
        for (int i = 2; i >=0; i--)
        {
            SkinItemUI skinItemUI = Instantiate(skinItemUIPrefab, SkinToggleGroup.transform);
            skinItemUI.SetSkinItemUI((ItemType)i, SkinToggleGroup, ((ItemType)i).ToString());
            skinItemUI.OnChangeValue();

        }
    }


    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
    private void BuyItemButton()
    {
        UIManager.Instance.OpenUI<CanvasBuyItem>();
    }
    private void BackMainMenuButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    
}
