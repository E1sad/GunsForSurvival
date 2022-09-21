using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.EndOfDayManager
{
  public class GetDayEvent : GameEvent
  {
    public int Day;

    public GetDayEvent(int day)
    {
      Day = day;
    }
  }
}

