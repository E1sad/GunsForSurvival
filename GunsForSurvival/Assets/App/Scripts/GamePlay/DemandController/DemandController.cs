using DynamicBox.EventManagement;
using SOG.GamePlay.EndOfDayManager;
using SOG.GamePlay.MoneyAndUpgrade;
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

    private void Awake()
    {
      demandAmount = 0;

      satisfactoryPercent = 100;
    }

    private void EndOfDayReset()
    {
      demandAmount = 0;
      currentAmount = 0;
      finalDemand = 0;
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
      satisfactoryPercent -= eventDetails.satisfactoryPercent;
    }

    private void DemandAmountEventHandler(DemandAmountEvent eventDetails)
    {
      float SFP = (float)satisfactoryPercent;
      demandAmount = eventDetails.demandAmount;
      finalDemand = (int)(demandAmount * (SFP / 100.0));
      Debug.Log("Final Demand: "+finalDemand + "Satisfactory: " + satisfactoryPercent);
      //Debug.Log("Calculations: " + (22*(50/100.0)));
      //TEMPORARY
      EventManager.Instance.Raise(new CurrentStatusOfUIEvent(currentAmount, finalDemand));
      //TEMPORARY
    }

    private void EndOfDayMessageEventHandler(EndOfDayMessageEvent eventDetails)
    {
      Debug.Log(currentAmount + "/" + finalDemand);
      EventManager.Instance.Raise(new CurrentStatusOfUIEvent(currentAmount, finalDemand));
      EventManager.Instance.Raise(new DailyObtainedGunAmountEvent(currentAmount));
      if (currentAmount >= finalDemand)
      {
        EventManager.Instance.Raise(new DemandCompleteEvent(true));
      }
      else
      {
        EventManager.Instance.Raise(new DemandCompleteEvent(false));
      }
      EndOfDayReset();
    }

    private void CurrentAmountEventHandler(CurrentAmountEvent eventDetails)
    {
      currentAmount = eventDetails.currentAmount;
      EventManager.Instance.Raise(new CurrentStatusOfUIEvent(currentAmount, finalDemand));
    }

    private void OnNextDayButtonPressendEventHandler(OnNextDayButtonPressendEvent eventDetails)
    {
      currentAmount = 0;
      EventManager.Instance.Raise(new FinalDemandEvent(finalDemand));
      EventManager.Instance.Raise(new CurrentStatusOfUIEvent(currentAmount, finalDemand));
    }
    #endregion
  }
}

