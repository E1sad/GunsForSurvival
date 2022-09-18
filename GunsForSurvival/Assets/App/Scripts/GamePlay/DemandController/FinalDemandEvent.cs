using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class FinalDemandEvent : GameEvent
  {
    public int finalDemand;

    public FinalDemandEvent(int _finalDemand)
    {
      finalDemand = _finalDemand;
    }
  }
}