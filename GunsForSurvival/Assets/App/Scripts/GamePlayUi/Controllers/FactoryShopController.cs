using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using DynamicBox.EventManagement;
using SOG.GamePlayUi.Events;
using SOG.GamePlay.MoneyAndUpgrade;

namespace SOG.GamePlayUi.Controllers
{
  public class FactoryShopController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private FactoryShopView view;



    public void OnBackButtonPressed()
    {
      view.SetActiveFacoryShopView(false);
      EventManager.Instance.Raise(new OnShopsBackbuttonPressedEvent());
    }

    public void OnNewEmployeeButtonPressed()
    {
      EventManager.Instance.Raise(new OnNewEmployeeButtonPressed());
    }

    public void OnEmployeeCourseButtonPressed()
    {
      EventManager.Instance.Raise(new OnEmployeeCourseButtonPressedEvent());
    }

    //public void OnBagButtonPressed()
    //{
      
    //}

    public void OnFactorySizeButtonPressed()
    {
      EventManager.Instance.Raise(new OnFactorySizeButtonPressedEvent());
    }

    #region Unity Events

    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnFactoryUpgradesButtonPressedEvent>(OnFactoryUpgradesButtonPressedEventHandler);
      EventManager.Instance.AddListener<NotEnoughMoneyEvent>(NotEnoughMoneyEventHandler);
      EventManager.Instance.AddListener<MaxLevelUpgradeEvent>(MaxLevelUpgradeEventHandler);
      EventManager.Instance.AddListener<ResetEndOfDayUiEvent>(ResetEndOfDayUiEventHandler);
      EventManager.Instance.AddListener<MaxEmployeeInFactoryEvent>(MaxEmployeeInFactoryEventHandler);


    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnFactoryUpgradesButtonPressedEvent>(OnFactoryUpgradesButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<NotEnoughMoneyEvent>(NotEnoughMoneyEventHandler);
      EventManager.Instance.RemoveListener<MaxLevelUpgradeEvent>(MaxLevelUpgradeEventHandler);
      EventManager.Instance.RemoveListener<ResetEndOfDayUiEvent>(ResetEndOfDayUiEventHandler);
      EventManager.Instance.RemoveListener<MaxEmployeeInFactoryEvent>(MaxEmployeeInFactoryEventHandler);
    }
    #endregion

    #region Event Handlers
    private void OnFactoryUpgradesButtonPressedEventHandler(OnFactoryUpgradesButtonPressedEvent eventDetails)
    {
      view.SetActiveFacoryShopView(true);
    }

    private void NotEnoughMoneyEventHandler(NotEnoughMoneyEvent eventDetails)
    {
      view.SetInformationText("Not enough money!");
    }

    private void MaxLevelUpgradeEventHandler(MaxLevelUpgradeEvent eventDetails)
    {
      view.SetInformationText("This upgrade is already max!");
    }

    private void ResetEndOfDayUiEventHandler(ResetEndOfDayUiEvent eventDetails)
    {
      view.SetMoneyText(eventDetails.money);
    }

    private void MaxEmployeeInFactoryEventHandler(MaxEmployeeInFactoryEvent eventDetails)
    {
      view.SetInformationText("You need to upgrade size of factory first!");
    }
    #endregion

  }
}
