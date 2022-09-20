using DynamicBox.EventManagement;
using SOG.GamePlay.EndOfDayManager;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.Employee
{
  public class EndDayReosurcesManager : MonoBehaviour
  {
    [SerializeField] private EmployeeController controller;


    private void OnEnable()
    {
      EventManager.Instance.AddListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.AddListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.RemoveListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }


    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      controller.EndofDayReset();
    }


    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {

    }
  }
}

