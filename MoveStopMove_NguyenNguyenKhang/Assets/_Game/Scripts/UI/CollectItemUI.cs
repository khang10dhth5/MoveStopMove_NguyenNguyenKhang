using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItemUI : MonoBehaviour
{
    [HideInInspector] public CollectItem collectItem;
    [SerializeField] private Image imgCollectItem;
    [SerializeField] private GameObject imgUse;
    [SerializeField] private Toggle toggle;



    public void Use()
    {
        imgUse.SetActive(true);
    }
    public void NonUse()
    {

        imgUse.SetActive(false);
    }
    public void SetShopItem(CollectItem collectItem, ToggleGroup toggleGroup)
    {
        this.collectItem= collectItem;
        imgCollectItem.sprite = collectItem.imgShopItem;
        toggle.group = toggleGroup;
    }
    public void OnValueChange()
    {
        if (toggle.isOn)
        {
           CollectManager.Instance.collectItemSelected = this;
        }
    }
}
[System.Serializable]
public class CollectItem
{
    public ItemType itemType;
    public int itemIndex;
    public Sprite imgShopItem;

    public CollectItem(ItemType itemType, int itemIndex, Sprite imgShop)
    {
        this.itemType = itemType;
        this.itemIndex = itemIndex;
        this.imgShopItem = imgShop;
    }
}