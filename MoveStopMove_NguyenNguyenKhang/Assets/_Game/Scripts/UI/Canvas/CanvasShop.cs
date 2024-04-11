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
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private ToggleGroup SkinToggleGroup;
    [SerializeField] private ToggleGroup shopItemUIToggleGroup;
    [SerializeField] private SkinItemUI skinItemUIPrefab;
    [SerializeField] private ShopItemUI shopItemUIPrefab;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {

        //load weapon, hat, pant
        for (int i = 0; i < SkinData.Instance.weaponSO.listWeapon.Count; i++)
        {
            if (PlayerPrefs.GetInt(KeyConstant.WEAPON + i) == 0)
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

            if (PlayerPrefs.GetInt(KeyConstant.HAT + i) == 0)
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

            if (PlayerPrefs.GetInt(KeyConstant.PANT + i) == 0)
            {
                PantItemData pantItemData = SkinData.Instance.pantSO.listPant[i];
                ShopItem shopItem = new ShopItem(ItemType.Pant, i, pantItemData.imgPant, pantItemData.price);

                ShopItemUI shopItemUI = Instantiate(shopItemUIPrefab, shopItemUIToggleGroup.transform);
                shopItemUI.SetShopItem(shopItem, shopItemUIToggleGroup);
                ShopManager.Instance.listItemUI.Add(shopItemUI);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            SkinItemUI skinItemUI = Instantiate(skinItemUIPrefab, SkinToggleGroup.transform);
            skinItemUI.SetSkinItemUI((ItemType)i, SkinToggleGroup, ((ItemType)i).ToString());

        }
    }

    public override void SetUp()
    {
        base.SetUp();

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
