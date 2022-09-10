using DynamicBox.EventManagement;
using SOG.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SOG.GamePlay.Employee.Ui.Events
{
  public class FullResourceEvent : GameEvent
  {
    public ItemType item;

    public FullResourceEvent(ItemType _item)
    {
      item = _item;
    }
  }
}