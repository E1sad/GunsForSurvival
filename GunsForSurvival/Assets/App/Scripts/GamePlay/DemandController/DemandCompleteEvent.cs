using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class DemandCompleteEvent : GameEvent
  {
    public bool IsComplete;

    public DemandCompleteEvent(bool isComplete)
    {
      IsComplete = isComplete;
    }
  }
}

