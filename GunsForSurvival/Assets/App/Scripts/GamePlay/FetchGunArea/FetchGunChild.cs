using DynamicBox.EventManagement;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.EndOfDayManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.FetchGun
{
  public class FetchGunChild : MonoBehaviour
  {
    [SerializeField] private FetchGunController controller;

    private void OnEnable()
    {
      EventManager.Instance.AddListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
    }

    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      controller.EndOfDay();
    }


  }
}

