using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;

namespace SOG.GamePlay.Employee
{
  public class GunAmountEvent : GameEvent
  {
    public int amount; 

    public GunAmountEvent(int _amount)
    {
      amount = _amount;
    }
  }
}

