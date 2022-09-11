using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay.Employee;
using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlayUi.Events;

namespace SOG.GamePlay.Employee.Ui
{
  public class EmployeePanelController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private EmployeePanelView view;

    public void OnWoodButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.WOOD, 1));
    }

    public void OnIronButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.IRON, 1));
    }

    public void OnAluminumButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.ALUMINUM, 1));
    }

    public void OnChoclateButtonPressed()
    {
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.CHOCOLATE, 1));
    }


    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnEmployeeBagButtonPressedEvent>(OnEmployeeBagButtonPressedEventHandler);
      EventManager.Instance.AddListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.AddListener<FullResourceEvent>(FullResourceEventHandler);
      EventManager.Instance.AddListener<TriggerExitResetResourcesEvent>(TriggerExitResetResourcesEventHandler);
      EventManager.Instance.AddListener<OnGamePlayEmployeeButtonPressed>(OnGamePlayEmployeeButtonPressedHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnEmployeeBagButtonPressedEvent>(OnEmployeeBagButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.RemoveListener<FullResourceEvent>(FullResourceEventHandler);
      EventManager.Instance.RemoveListener<TriggerExitResetResourcesEvent>(TriggerExitResetResourcesEventHandler);
      EventManager.Instance.RemoveListener<OnGamePlayEmployeeButtonPressed>(OnGamePlayEmployeeButtonPressedHandler);
    }
    #endregion

    #region Event Handlers
    private void OnEmployeeBagButtonPressedEventHandler(OnEmployeeBagButtonPressedEvent eventDetails)
    {
      view.SetActivePanel(true);
    }

    private void OnEmployeeBagExitEventHandler(OnEmployeeBagExitEvent eventDetails)
    {
      view.SetActivePanel(false);
    }

    private void FullResourceEventHandler(FullResourceEvent eventDetails)
    {
      view.SetInteractable(eventDetails.item, eventDetails.active);
    }

    private void TriggerExitResetResourcesEventHandler(TriggerExitResetResourcesEvent eventDetails)
    {
      view.ResetInteractable(true);
    }

    private void OnGamePlayEmployeeButtonPressedHandler(OnGamePlayEmployeeButtonPressed eventDetails)
    {
      view.SetActivePanel(true);
    }

    #endregion

  }
}