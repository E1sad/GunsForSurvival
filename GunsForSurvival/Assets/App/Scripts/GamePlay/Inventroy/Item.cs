using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay;

namespace SOG.GamePlay.Inventory
{
  public class Item
  {
    private ItemType itemType;

    private int amount;

    public Item(ItemType _itemType, int _amount)
    {
      itemType = _itemType;

      amount = _amount;
    }


    #region Getters And Setters
    public void SetItemType(ItemType _itemType)
    {
      itemType = _itemType;
    }

    public ItemType GetItemType()
    {
      return itemType;
    }

    public void SetAmount(int _amount)
    {
      amount = _amount;
    }

    public int GetAmount()
    {
      return amount;
    }
    #endregion
  }
}
