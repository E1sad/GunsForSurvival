using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;
using SOG.GamePlay.DemandController;
using SOG.GamePlay.MoneyAndUpgrade;

namespace SOG.GamePlayUi.Controllers
{
  public class PersonalShopController : MonoBehaviour
  {
    [Header ("View reference")]
    [SerializeField] private PersonalShopView view;

    public void OnBackButtonPressed()
    {
      view.SetActivePersonalShopView(false);
      EventManager.Instance.Raise(new OnShopsBackbuttonPressedEvent());
    }

    public void OnSpeedGymButtonPressed()
    {
      EventManager.Instance.Raise(new OnSpeedGymButtonPressedEvent());
    }

    public void OnEngineringButtonPressed()
    {
      EventManager.Instance.Raise(new OnEngineringCourseButtonPressedEvent());
    }

    public void OnSatisfactoryButtonPressed()
    {
      EventManager.Instance.Raise(new OnSatisfactoryCourseButtonPressedEvent());
    }

    public void OnBagLimitButtonPressed()
    {
      EventManager.Instance.Raise(new OnBagButtonPressed());
    }

    public void OnManagementButtonPressed()
    {
      EventManager.Instance.Raise(new OnManagementCourseButtonPressedEvent());
    }

    #region Unity Events
    
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnPersonalUpgradesButtonPressedEvent>(OnPersonalUpgradesButtonPressedEventHandler);
      EventManager.Instance.AddListener<NotEnoughMoneyEvent>(NotEnoughMoneyEventHandler);
      EventManager.Instance.AddListener<MaxLevelUpgradeEvent>(MaxLevelUpgradeEventHandler);
      EventManager.Instance.AddListener<ResetEndOfDayUiEvent>(ResetEndOfDayUiEventHandler);
      
      
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnPersonalUpgradesButtonPressedEvent>(OnPersonalUpgradesButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<NotEnoughMoneyEvent>(NotEnoughMoneyEventHandler);
      EventManager.Instance.RemoveListener<MaxLevelUpgradeEvent>(MaxLevelUpgradeEventHandler);
      EventManager.Instance.RemoveListener<ResetEndOfDayUiEvent>(ResetEndOfDayUiEventHandler);
    }

    #endregion

    #region Event Handlers
    
    private void OnPersonalUpgradesButtonPressedEventHandler(OnPersonalUpgradesButtonPressedEvent eventDetails)
    {
      view.SetActivePersonalShopView(true);
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


    #endregion

  }
}
