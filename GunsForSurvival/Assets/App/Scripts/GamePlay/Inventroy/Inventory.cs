using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay;

namespace SOG.GamePlay.Inventory
{
  public class Inventory
  {
    private List<Item> itemList;

    private bool isContain;

    public Inventory()
    {
      itemList = new List<Item>();
      isContain = false;
    }

    public void AddItem(ItemType itemType, int amount)
    {

      for (int i = 0; i < itemList.Count; i++)
      {
        if (itemList[i].GetItemType() == itemType)
        {
          itemList[i].SetAmount((itemList[i].GetAmount()+ amount));

          Debug.Log(itemList[i].GetItemType() +" "+ itemList[i].GetAmount());

          isContain = true;

          break;
        }
        else
        {
          isContain = false;
        }
      }


      if(!isContain)
      {
        Item item = new Item(itemType, amount);

        itemList.Add(item);

        Debug.Log("Aded " + itemType);
      }
    }

    public void RemoveItem(ItemType itemType, int amount)
    {
      for (int i = 0; i < itemList.Count; i++)
      {
        if (itemList[i].GetItemType() == itemType)
        {
          if (itemList[i].GetAmount() > 1)
          {
            itemList[i].SetAmount((itemList[i].GetAmount() - amount));

            Debug.Log(itemList[i].GetItemType() + " " + itemList[i].GetAmount());

            break;
          }
          else if (itemList[i].GetAmount() == 1)
          {
            itemList.Remove(itemList[i]);

            Debug.Log("Removed " + itemList[i].GetItemType());
          }
        }
      }
    }

  }
}