using DynamicBox.EventManagement;
using SOG.GamePlay.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Employee.Ui.Events
{
  public class InventoryListContainerEvent : GameEvent
  {
    public List<Item> inventoryList = new List<Item>();

    public InventoryListContainerEvent(List<Item> _inventoryList)
    {
      inventoryList = _inventoryList;
    }
  }
}