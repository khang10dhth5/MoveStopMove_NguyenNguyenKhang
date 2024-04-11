using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : SingletonMono<ShopManager>
{
    [HideInInspector] public ShopItemUI shopItemSelected;

    public List<ShopItemUI> listItemUI = new List<ShopItemUI>();

    internal void ChangeItemShop(ItemType itemType)
    {
        for (int i = 0; i < listItemUI.Count; i++)
        {
            if (listItemUI[i].shopItem.itemType == itemType)
            {
                listItemUI[i].gameObject.SetActive(true);
            }
            else
            {
                listItemUI[i].gameObject.SetActive(false);
            }
        }
    }
}
