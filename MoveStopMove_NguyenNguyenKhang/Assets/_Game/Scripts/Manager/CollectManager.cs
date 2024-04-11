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
            if(CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == 1 && listItemUI[i].collectItem.itemType ==ItemType.Weapon)
            {
                if(PlayerPrefs.GetInt(KeyConstant.CURRENT_WEAPON)== listItemUI[i].collectItem.itemIndex)
                {
                    listItemUI[i].Use();
                }
                else
                {
                    listItemUI[i].NonUse();
                }
            }

            if (CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == 1 && listItemUI[i].collectItem.itemType == ItemType.Hat)
            {
                if (PlayerPrefs.GetInt(KeyConstant.CURRENT_HAT) == listItemUI[i].collectItem.itemIndex)
                {
                    listItemUI[i].Use();
                }
                else
                {
                    listItemUI[i].NonUse();
                }
            }

            if (CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex) == 1 && listItemUI[i].collectItem.itemType == ItemType.Pant)
            {
                if (PlayerPrefs.GetInt(KeyConstant.CURRENT_PANT) == listItemUI[i].collectItem.itemIndex)
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
            if (CheckCollect(listItemUI[i].collectItem.itemType, listItemUI[i].collectItem.itemIndex)==1 &&listItemUI[i].collectItem.itemType == itemType)
            {
                listItemUI[i].gameObject.SetActive(true);
            }
            else
            {
                listItemUI[i].gameObject.SetActive(false);
            }
        }
    }

    public int CheckCollect(ItemType itemType, int index)
    {
        if(itemType==ItemType.Weapon)
        {
            return PlayerPrefs.GetInt(KeyConstant.WEAPON+index);
        }
        if (itemType == ItemType.Hat)
        {
            return PlayerPrefs.GetInt(KeyConstant.HAT+index);
        }
        if (itemType == ItemType.Pant)
        {
            return PlayerPrefs.GetInt(KeyConstant.PANT+index);
        }
        return 0;
    }
}
