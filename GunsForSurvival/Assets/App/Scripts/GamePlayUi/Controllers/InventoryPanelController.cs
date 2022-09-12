using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SOG.GamePlayUi.Views;
using SOG.GamePlayUi.Events;
using DynamicBox.EventManagement;
using SOG.GamePlay;

namespace SOG.GamePlayUi.Controllers
{
  public class InventoryPanelController : MonoBehaviour
  {
    [Header("View reference")]
    [SerializeField] private InventoryPanelView view;

    private void Start()
    {
      view.ResetInventory();
    }

    public void BackButtonPressed()
    {
      view.SetActivePanel(false);
      EventManager.Instance.Raise(new OnInventoryBackButtonPressed());
    }

    public void DeleteOnButtonPressed(ItemType item, int amount)
    {
      EventManager.Instance.Raise(new InventoryItemDeleteEvent(item, amount));
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
      EventManager.Instance.AddListener<InventoryItemContainerEvent>(InventoryItemContainerEventHandler);
      EventManager.Instance.AddListener<InventoryResetEvent>(InventoryResetEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnGamePlayBagButtonPressed>(OnGamePlayBagButtonPressedHandler);
      EventManager.Instance.RemoveListener<InventoryItemContainerEvent>(InventoryItemContainerEventHandler);
      EventManager.Instance.RemoveListener<InventoryResetEvent>(InventoryResetEventHandler);
    }
    #endregion

    #region Event Handlers
    private void OnGamePlayBagButtonPressedHandler(OnGamePlayBagButtonPressed eventDetails)
    {
      view.SetActivePanel(true);
    }

    private void InventoryItemContainerEventHandler(InventoryItemContainerEvent eventDetails)
    {
      view.InventoryItemsCheck(eventDetails.item, eventDetails.amount);
    }

    private void InventoryResetEventHandler(InventoryResetEvent eventDetails)
    {
      view.ResetInventory();
    }
    #endregion

  }
}