using DynamicBox.EventManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.FetchGun
{
  public class GunCheckInventoryEvent : GameEvent
  {
    public bool active;

    public GunCheckInventoryEvent(bool _active)
    {
      active = _active;
    }
  }
}

