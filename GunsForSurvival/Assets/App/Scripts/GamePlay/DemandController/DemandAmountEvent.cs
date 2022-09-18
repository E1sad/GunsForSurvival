using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class DemandAmountEvent : GameEvent
  {
    public int demandAmount;

    public DemandAmountEvent(int _demandAmount)
    {
      demandAmount = _demandAmount;
    }
  }
}
