using DynamicBox.EventManagement;
using SOG.GamePlay.EndOfDayController;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.DemandController
{
  public class DemandController : MonoBehaviour
  {
    [SerializeField] private int demandAmount;

    [SerializeField] private int currentAmount;

    [SerializeField] private int satisfactoryPercent;

    private int finalDemand;

    private void Start()
    {
      demandAmount = 0;

      satisfactoryPercent = 0;
    }



    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<SatisfactoryPercentEvent>(SatisfactoryPercentEventHandler);
      EventManager.Instance.AddListener<DemandAmountEvent>(DemandAmountEventHandler);
      EventManager.Instance.AddListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.AddListener<CurrentAmountEvent>(CurrentAmountEventHandler);
      EventManager.Instance.AddListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<SatisfactoryPercentEvent>(SatisfactoryPercentEventHandler);
      EventManager.Instance.RemoveListener<DemandAmountEvent>(DemandAmountEventHandler);
      EventManager.Instance.RemoveListener<EndOfDayMessageEvent>(EndOfDayMessageEventHandler);
      EventManager.Instance.RemoveListener<CurrentAmountEvent>(CurrentAmountEventHandler);
      EventManager.Instance.RemoveListener<OnNextDayButtonPressendEvent>(OnNextDayButtonPressendEventHandler);
    }
    #endregion

    #region Event Handlers
    private void SatisfactoryPercentEventHandler(SatisfactoryPercentEvent eventDetails)
    {
      satisfactoryPercent = eventDetails.satisfactoryPercent;
      if (demandAmount != 0)
      {
        finalDemand = demandAmount * (satisfactoryPercent / 100);
      }
    }

    private void DemandAmountEventHandler(DemandAmountEvent eventDetails)
    {
      demandAmount = eventDetails.demandAmount;
      if (satisfactoryPercent != 0)
      {
        finalDemand = demandAmount * (satisfactoryPercent / 100);
      }
    }

    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      if (currentAmount >= finalDemand)
      {
        EventManager.Instance.Raise(new DemandCompleteEvent(true));
      }
      else
      {
        EventManager.Instance.Raise(new DemandCompleteEvent(false));
      }
    }

    private void CurrentAmountEventHandler(CurrentAmountEvent eventDetails)
    {
      currentAmount = eventDetails.currentAmount;
      Debug.Log(currentAmount);
    }

    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {
      EventManager.Instance.Raise(new FinalDemandEvent(finalDemand));
    }
    #endregion
  }
}

