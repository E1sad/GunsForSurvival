using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.MoneyAndUpgrade
{
  public class DailyObtainedGunAmountEvent : GameEvent
  {
    public int GunAmount;

    public DailyObtainedGunAmountEvent(int gunAmount)
    {
      GunAmount = gunAmount;
    }
  }
}

