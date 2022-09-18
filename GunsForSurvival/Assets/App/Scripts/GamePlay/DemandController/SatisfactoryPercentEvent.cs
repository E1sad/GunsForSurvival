using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class SatisfactoryPercentEvent : GameEvent
  {
    public int satisfactoryPercent;

    public SatisfactoryPercentEvent(int _satisfactoryPercent)
    {
      satisfactoryPercent = _satisfactoryPercent;
    }
  }
}

