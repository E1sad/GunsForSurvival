using DynamicBox.EventManagement;
using SOG.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlayUi.Events
{
  public class InventoryItemDeleteEvent : GameEvent
  {
    public ItemType item;

    public int amount;

    public InventoryItemDeleteEvent(ItemType _item, int _amount)
    {
      item = _item;

      amount = _amount;
    }
  }
}