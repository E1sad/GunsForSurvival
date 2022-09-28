using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Inventory
{
  public class IsInLimitEvent : GameEvent
  {
    public bool IsInLimit;

    public IsInLimitEvent(bool isInLimit)
    {
      IsInLimit = isInLimit;
    }
  }
}

