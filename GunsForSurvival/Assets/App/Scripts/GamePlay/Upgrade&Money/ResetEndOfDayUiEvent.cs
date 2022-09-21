using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.MoneyAndUpgrade
{
  public class ResetEndOfDayUiEvent : GameEvent
  {
    public int money;

    public int dailyMoney;

    public ResetEndOfDayUiEvent(int _money, int _dailyMoney)
    {
      money = _money;

      dailyMoney = _dailyMoney;
    }
  }
}

