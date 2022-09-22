using DynamicBox.EventManagement;
using SOG.Characters.Player;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.Employee;
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
    private int playerSpeedLevel;
    private int produseSpeedLevel;


    private void Start()
    {
      money = 0;
      satisfactoryUpgradeLevel = 0;
      newEmployeeUpgradeLevel = 0;
      playerSpeedLevel = 0;
      produseSpeedLevel = 0;
    }


    #region Unity Events
    private void OnEnable()
    {
      //EventManager.Instance.AddListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.AddListener<OnSatisfactoryCourseButtonPressedEvent>(OnSatisfactoryCourseButtonPressedEventHandler);
      EventManager.Instance.AddListener<DailyObtainedGunAmountEvent>(DailyObtainedGunAmountEventHandler);
      EventManager.Instance.AddListener<OnNewEmployeeButtonPressed>(OnNewEmployeeButtonPressedHandler);
      EventManager.Instance.AddListener<OnSpeedGymButtonPressedEvent>(OnSpeedGymButtonPressedEventHandler);
      EventManager.Instance.AddListener<OnEmployeeCourseButtonPressedEvent>(OnEmployeeCourseButtonPressedEventHandler);

      
    }

    private void OnDisable()
    {
      //EventManager.Instance.RemoveListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.RemoveListener<OnSatisfactoryCourseButtonPressedEvent>(OnSatisfactoryCourseButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<DailyObtainedGunAmountEvent>(DailyObtainedGunAmountEventHandler);
      EventManager.Instance.RemoveListener<OnNewEmployeeButtonPressed>(OnNewEmployeeButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnSpeedGymButtonPressedEvent>(OnSpeedGymButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeCourseButtonPressedEvent>(OnEmployeeCourseButtonPressedEventHandler);
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
      if (money >= 90 && satisfactoryUpgradeLevel < 5)
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
      if (money >= 120 && newEmployeeUpgradeLevel < 7)
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

    private void OnSpeedGymButtonPressedEventHandler(OnSpeedGymButtonPressedEvent eventDetails)
    {
      if (money >= 100 && playerSpeedLevel < 5)
      {
        EventManager.Instance.Raise(new PlayerSpeedEvent());
        money -= 100;
        playerSpeedLevel++;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 100)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (playerSpeedLevel >= 5)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
          //Debug.Log(newEmployeeUpgradeLevel);
        }
      }
    }

    private void OnEmployeeCourseButtonPressedEventHandler(OnEmployeeCourseButtonPressedEvent eventDetails)
    {
      if (money >= 150 && produseSpeedLevel < 5)
      {
        EventManager.Instance.Raise(new ProduceSpeedEvent());
        money -= 150;
        produseSpeedLevel++;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 150)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (produseSpeedLevel >= 5)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
          //Debug.Log(newEmployeeUpgradeLevel);
        }
      }
    }


    #endregion
  }
}

