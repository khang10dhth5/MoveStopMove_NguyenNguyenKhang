using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCollect : UICanvas
{
    [SerializeField] private Button btnBackMainMenu;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnUseItem;
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private ToggleGroup SkinToggleGroup;
    [SerializeField] private ToggleGroup collectItemUIToggleGroup;
    [SerializeField] private SkinItemUI skinItemUIPrefab;
    [SerializeField] private CollectItemUI collectItemUIPrefab;
    private void Awake()
    {
        OnInit();
    }
    public override void SetUp()
    {
        base.SetUp();
        btnSetting.onClick.AddListener(() =>
        {
            SettingButton();
        });
        btnBackMainMenu.onClick.AddListener(() =>
        {
            BackMainMenuButton();
        });
        btnUseItem.onClick.AddListener(() =>
        {
            UseButton();
        });
    }

    private void UseButton()
    {
        CollectItem collectIem = CollectManager.Instance.collectItemSelected.collectItem;
        if (collectIem.itemType==ItemType.Weapon)
        {
            PlayerPrefs.SetInt(KeyConstant.CURRENT_WEAPON, collectIem.itemIndex);
        }
        if (collectIem.itemType == ItemType.Hat)
        {
            PlayerPrefs.SetInt(KeyConstant.CURRENT_HAT, collectIem.itemIndex);
        }
        if (collectIem.itemType == ItemType.Pant)
        {
            PlayerPrefs.SetInt(KeyConstant.CURRENT_PANT, collectIem.itemIndex);
        }
        CollectManager.Instance.SetUseItem();
    }

    private void BackMainMenuButton()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
    }
    private void SettingButton()
    {
        UIManager.Instance.OpenUI<CanvasSetting>();
    }
    private void OnEnable()
    {
        for(int i=0;i< CollectManager.Instance.listItemUI.Count;i++)
        {
            if(CollectManager.Instance.CheckCollect(CollectManager.Instance.listItemUI[i].collectItem.itemType, CollectManager.Instance.listItemUI[i].collectItem.itemIndex)==1)
            {
                CollectManager.Instance.listItemUI[i].gameObject.SetActive(true);
            }
        }
        CollectManager.Instance.SetUseItem();
    }
    private void OnInit()
    {
        //load weapon, hat, pant
        for (int i = 0; i < SkinData.Instance.weaponSO.listWeapon.Count; i++)
        {
            WeaponItemData weaponItemData = SkinData.Instance.weaponSO.listWeapon[i];
            CollectItem collectItem = new CollectItem(ItemType.Weapon, i, weaponItemData.imgWeapon);

            CollectItemUI collectItemUI = Instantiate(collectItemUIPrefab, collectItemUIToggleGroup.transform);
            collectItemUI.SetShopItem(collectItem, collectItemUIToggleGroup);
            collectItemUI.gameObject.SetActive(false);
            CollectManager.Instance.listItemUI.Add(collectItemUI);
        }

        for (int i = 0; i < SkinData.Instance.hatSO.listHat.Count; i++)
        {
            HatItemData hatItemData = SkinData.Instance.hatSO.listHat[i];
            CollectItem collectItem = new CollectItem(ItemType.Hat, i, hatItemData.imgHat);

            CollectItemUI collectItemUI = Instantiate(collectItemUIPrefab, collectItemUIToggleGroup.transform);
            collectItemUI.SetShopItem(collectItem, collectItemUIToggleGroup);
            collectItemUI.gameObject.SetActive(false);
            CollectManager.Instance.listItemUI.Add(collectItemUI);
        }

        for (int i = 0; i < SkinData.Instance.pantSO.listPant.Count; i++)
        {
            PantItemData pantItemData = SkinData.Instance.pantSO.listPant[i];
            CollectItem collectItem = new CollectItem(ItemType.Pant, i, pantItemData.imgPant);

            CollectItemUI collectItemUI = Instantiate(collectItemUIPrefab, collectItemUIToggleGroup.transform);
            collectItemUI.SetShopItem(collectItem, collectItemUIToggleGroup);
            collectItemUI.gameObject.SetActive(false);
            CollectManager.Instance.listItemUI.Add(collectItemUI);
        }
        for (int i = 0; i < 3; i++)
        {
            SkinItemUI skinItemUI = Instantiate(skinItemUIPrefab, SkinToggleGroup.transform);
            skinItemUI.SetSkinItemUI((ItemType)i, SkinToggleGroup, ((ItemType)i).ToString());

        }

    }
}
