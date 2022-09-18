using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class CurrentAmountEvent : GameEvent
  {
    public int currentAmount;

    public CurrentAmountEvent(int _currentAmount)
    {
      currentAmount = _currentAmount;
    }
  }
}