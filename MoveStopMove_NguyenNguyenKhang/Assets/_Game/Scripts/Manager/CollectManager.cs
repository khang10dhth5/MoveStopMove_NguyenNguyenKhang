using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : SingletonMono<CollectManager>
{
    [HideInInspector] public CollectItemUI collectItemSelected;

    public List<CollectItemUI> listItemUI = new List<CollectItemUI>();


    public void SetUseItem()
    {
        for (int i = 0; i < listItemUI.Count; i++)
        {
            if(CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == true && listItemUI[i].collectItem.itemType ==ItemType.Weapon)
            {
                if(UnitDataManager.Instance.UnitData.currentWeaponIndex== listItemUI[i].collectItem.itemIndex)
                {
                    listItemUI[i].Use();
                }
                else
                {
                    listItemUI[i].NonUse();
                }
            }

            if (CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == true && listItemUI[i].collectItem.itemType == ItemType.Hat)
            {
                if (UnitDataManager.Instance.UnitData.currentHatIndex== listItemUI[i].collectItem.itemIndex)
                {
                    listItemUI[i].Use();
                }
                else
                {
                    listItemUI[i].NonUse();
                }
            }

            if (CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == true && listItemUI[i].collectItem.itemType == ItemType.Pant)
            {
                if (UnitDataManager.Instance.UnitData.currentPantIndex == listItemUI[i].collectItem.itemIndex)
                {
                    listItemUI[i].Use();
                }
                else
                {
                    listItemUI[i].NonUse();
                }
            }
        }
    }
    
    internal void ChangeItemCollect(ItemType itemType)
    {
        for (int i = 0; i < listItemUI.Count; i++)
        {
            if (listItemUI[i].collectItem.itemType == itemType && CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex)==true)
            {
                listItemUI[i].gameObject.SetActive(true);
            }
            else
            {
                listItemUI[i].gameObject.SetActive(false);
            }
        }
    }

    public bool CheckCollect(ItemType itemType, int index)
    {
        if(itemType==ItemType.Weapon)
        {
            return UnitDataManager.Instance.UnitData.listWeapon[index];
        }
        if (itemType == ItemType.Hat)
        {
            return UnitDataManager.Instance.UnitData.listHat[index];
        }
        if (itemType == ItemType.Pant)
        {
            return UnitDataManager.Instance.UnitData.listPant[index];
        }
        return false;
    }
}
