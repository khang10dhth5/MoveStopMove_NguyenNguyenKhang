using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [HideInInspector] public ShopItem shopItem;
    [SerializeField] private Image imgShopItem;
    [SerializeField] private Text txtPrice;
    [SerializeField] private Toggle toggle;
   public void SetShopItem(ShopItem shopItem, ToggleGroup toggleGroup)
    {
        this.shopItem = shopItem;
        imgShopItem.sprite = shopItem.imgShopItem;
        txtPrice.text = shopItem.price.ToString();
        toggle.group = toggleGroup;
    }
    public void OnValueChange()
    {
        if(toggle.isOn)
        {
            ShopManager.Instance.shopItemSelected = this;
            if(shopItem.itemType==ItemType.Weapon)
            {
                UIManager.Instance.characterPreview.SetWeapon((WeaponType)shopItem.itemIndex);
            }
            if (shopItem.itemType == ItemType.Hat)
            {
                UIManager.Instance.characterPreview.SetHat((HatType)shopItem.itemIndex);
            }
            if (shopItem.itemType == ItemType.Pant)
            {
                UIManager.Instance.characterPreview.SetPant((PantType)shopItem.itemIndex);
            }

        }
    }

}
[System.Serializable]
public class ShopItem
{
    public ItemType itemType;
    public int itemIndex;
    public Sprite imgShopItem;
    public int price;

    public ShopItem(ItemType itemType, int itemIndex, Sprite imgShop, int price)
    {
        this.itemType = itemType;
        this.itemIndex = itemIndex;
        this.imgShopItem = imgShop;
        this.price = price;
    }
}