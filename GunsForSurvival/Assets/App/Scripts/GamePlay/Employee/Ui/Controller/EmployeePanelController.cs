using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlay.Employee;
using DynamicBox.EventManagement;
using SOG.GamePlay.Employee.Ui.Events;
using SOG.GamePlayUi.Events;
using SOG.GamePlay.Inventory;

namespace SOG.GamePlay.Employee.Ui
{
  public class EmployeePanelController : MonoBehaviour
  {
    [Header("view reference")]
    [SerializeField] private EmployeePanelView view;

    public void OnWoodButtonPressed()
    {
      view.ResetAmountOfResources();
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.WOOD, 1));
    }

    public void OnIronButtonPressed()
    {
      view.ResetAmountOfResources();
      EventManager.Instance.Raise(new OnGiveEvent(ItemType.IRON, 1));
    }

    public void OnAluminumButtonPressed()
    {
      view.ResetAmountOfResources();
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
      EventManager.Instance.AddListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.AddListener<InventoryItemContainerEvent>(InventoryItemContainerEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnEmployeeBagButtonPressedEvent>(OnEmployeeBagButtonPressedEventHandler);
      EventManager.Instance.RemoveListener<OnEmployeeBagExitEvent>(OnEmployeeBagExitEventHandler);
      EventManager.Instance.RemoveListener<FullResourceEvent>(FullResourceEventHandler);
      EventManager.Instance.RemoveListener<TriggerExitResetResourcesEvent>(TriggerExitResetResourcesEventHandler);
      EventManager.Instance.RemoveListener<OnGamePlayEmployeeButtonPressed>(OnGamePlayEmployeeButtonPressedHandler);
      EventManager.Instance.RemoveListener<OnTriggerEnterEvent>(OnTriggerEnterEventHandler);
      EventManager.Instance.RemoveListener<InventoryItemContainerEvent>(InventoryItemContainerEventHandler);
    }
    #endregion

    #region Event Handlers
    private void OnTriggerEnterEventHandler(OnTriggerEnterEvent eventDetails)
    {
      view.ResetAmountOfResources();
      EventManager.Instance.Raise(new CheckResourcesEvent());
    }

    private void OnEmployeeBagButtonPressedEventHandler(OnEmployeeBagButtonPressedEvent eventDetails)
    {
      view.ResetAmountOfResources();
      EventManager.Instance.Raise(new CheckResourcesEvent());
      view.SetActivePanel(true);
    }

    private void OnEmployeeBagExitEventHandler(OnEmployeeBagExitEvent eventDetails)
    {
      //view.ResetAmountOfResources();
      view.SetActivePanel(false);
    }

    private void FullResourceEventHandler(FullResourceEvent eventDetails)
    {
      view.SetInteractable(eventDetails.item, eventDetails.active);
    }

    private void TriggerExitResetResourcesEventHandler(TriggerExitResetResourcesEvent eventDetails)
    {
      //view.ResetInteractable(true);
    }

    private void OnGamePlayEmployeeButtonPressedHandler(OnGamePlayEmployeeButtonPressed eventDetails)
    {
      view.ResetAmountOfResources();
      EventManager.Instance.Raise(new CheckResourcesEvent());
      view.SetActivePanel(true);
    }

    private void InventoryItemContainerEventHandler(InventoryItemContainerEvent eventDetails)
    {
      view.ResourceAmounts(eventDetails.item, eventDetails.amount);
    }
    #endregion

  }
}