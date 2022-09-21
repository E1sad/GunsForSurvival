using DynamicBox.EventManagement;
using SOG.GamePlay.DemandController;
using SOG.GamePlayUi.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.GamePlay.MoneyAndUpgrade
{
  public class MoneyAndUpgradeManager : MonoBehaviour
  {
    [SerializeField] private int money;

    private int dailyMoney;
    private int satisfactoryUpgradeLevel;
    private int newEmployeeUpgradeLevel;



    private void Start()
    {
      money = 0;
      satisfactoryUpgradeLevel = 0;
      newEmployeeUpgradeLevel = 0;
    }


    #region Unity Events
    private void OnEnable()
    {
      //EventManager.Instance.AddListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.AddListener<OnSatisfactoryCourseButtonPressedEvent>(OnSatisfactoryCourseButtonPressedEventHandler);
      EventManager.Instance.AddListener<DailyObtainedGunAmountEvent>(DailyObtainedGunAmountEventHandler);
      EventManager.Instance.AddListener<OnNewEmployeeButtonPressed>(OnNewEmployeeButtonPressedHandler);
    }

    private void OnDisable()
    {
      //EventManager.Instance.RemoveListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.RemoveListener<OnSatisfactoryCourseButtonPressedEvent>(OnSatisfactoryCourseButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<DailyObtainedGunAmountEvent>(DailyObtainedGunAmountEventHandler);
      EventManager.Instance.RemoveListener<OnNewEmployeeButtonPressed>(OnNewEmployeeButtonPressedHandler);
    }
    #endregion

    #region Event Handlers
    private void DailyObtainedGunAmountEventHandler(DailyObtainedGunAmountEvent eventDetails)
    {
      money += eventDetails.GunAmount * 5;
      dailyMoney = eventDetails.GunAmount * 5;
      EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
    }

    private void OnSatisfactoryCourseButtonPressedEventHandler(OnSatisfactoryCourseButtonPressedEvent eventDetails)
    {
      if (money > 90 && satisfactoryUpgradeLevel < 5)
      {
        EventManager.Instance.Raise(new SatisfactoryPercentEvent(5));
        money -= 90;
        satisfactoryUpgradeLevel++;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 90)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (satisfactoryUpgradeLevel >= 5)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
        }
      }
    }

    private void OnNewEmployeeButtonPressedHandler(OnNewEmployeeButtonPressed eventDetails)
    {
      if (money > 120 && newEmployeeUpgradeLevel < 7)
      {
        EventManager.Instance.Raise(new newEmployeeEvent());
        money -= 120;
        newEmployeeUpgradeLevel++;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 120)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (newEmployeeUpgradeLevel >= 7)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
          //Debug.Log(newEmployeeUpgradeLevel);
        }
      }
    }
    #endregion
  }
}

