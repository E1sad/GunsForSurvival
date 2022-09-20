using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class CurrentStatusOfUIEvent : GameEvent
  {
    public int CurrentGunAmount;

    public int Demand;

    public CurrentStatusOfUIEvent(int currentGunAmount, int demand)
    {
      CurrentGunAmount = currentGunAmount;

      Demand = demand;
    }
  }
}

