using DynamicBox.EventManagement;
using SOG.Characters.Player;
using SOG.GamePlay.BorderController;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.Employee;
using SOG.GamePlay.Inventory;
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
    private int factorySizeLevel;
    private int bagLimitSizeLevel;

    private int newEmployeeUpgradeLevelLimit;

    private void Start()
    {
      money = 10000;
      satisfactoryUpgradeLevel = 0;
      newEmployeeUpgradeLevel = 0;
      playerSpeedLevel = 0;
      produseSpeedLevel = 0;
      factorySizeLevel = 0;
      newEmployeeUpgradeLevelLimit = 2;
      bagLimitSizeLevel = 0;
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
      EventManager.Instance.AddListener<OnFactorySizeButtonPressedEvent>(OnFactorySizeButtonPressedEventHandler);
      EventManager.Instance.AddListener<OnBagButtonPressed>(OnBagButtonPressedHandler);
      
    }

    private void OnDisable()
    {
      //EventManager.Instance.RemoveListener<CurrentStatusOfUIEvent>(CurrentStatusOfUIEventHandler);
      EventManager.Instance.RemoveListener<OnSatisfactoryCourseButtonPressedEvent>(OnSatisfactoryCourseButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<DailyObtainedGunAmountEvent>(DailyObtainedGunAmountEventHandler);
      EventManager.Instance.RemoveListener<OnNewEmployeeButtonPressed>(OnNewEmployeeButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnSpeedGymButtonPressedEvent>(OnSpeedGymButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeCourseButtonPressedEvent>(OnEmployeeCourseButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnFactorySizeButtonPressedEvent>(OnFactorySizeButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnBagButtonPressed>(OnBagButtonPressedHandler);
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
        else if (satisfactoryUpgradeLevel > 5)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
        }
      }
    }

    private void OnNewEmployeeButtonPressedHandler(OnNewEmployeeButtonPressed eventDetails)
    {
      if (money >= 120 && newEmployeeUpgradeLevel < newEmployeeUpgradeLevelLimit)
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
        else if (newEmployeeUpgradeLevel >= newEmployeeUpgradeLevelLimit)
        {
          if (newEmployeeUpgradeLevel >= 7)
          {
            EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
          }
          else if (newEmployeeUpgradeLevel >= 2)
          {
            EventManager.Instance.Raise(new MaxEmployeeInFactoryEvent());
            
          }
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

    private void OnFactorySizeButtonPressedEventHandler(OnFactorySizeButtonPressedEvent eventDetails)
    {
      if (money >= 400 && factorySizeLevel < 1)
      {
        EventManager.Instance.Raise(new BorderUpgradeEvent());
        money -= 400;
        factorySizeLevel++;
        newEmployeeUpgradeLevelLimit = 7;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 400)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (factorySizeLevel >= 1)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
          //Debug.Log(newEmployeeUpgradeLevel);
        }
      }
    }

    private void OnBagButtonPressedHandler(OnBagButtonPressed eventDetails)
    {
      if (money >= 60 && bagLimitSizeLevel < 5)
      {
        EventManager.Instance.Raise(new IncreaseBagLimitEvent());
        money -= 60;
        bagLimitSizeLevel++;
        EventManager.Instance.Raise(new ResetEndOfDayUiEvent(money, dailyMoney));
      }
      else
      {
        if (money < 60)
        {
          EventManager.Instance.Raise(new NotEnoughMoneyEvent());
        }
        else if (bagLimitSizeLevel >= 5)
        {
          EventManager.Instance.Raise(new MaxLevelUpgradeEvent());
        }
      }
    }



    #endregion
  }
}

