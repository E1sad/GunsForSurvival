using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.EventManagement;
using SOG.GamePlay.ResourceLine;
using SOG.GamePlay.Employee;

namespace SOG.GamePlay.Inventory
{
  public class InventoryManager : MonoBehaviour
  {
    private Inventory inventory;

    private void Start()
    {
      inventory = new Inventory();
    }

    #region Unity Events
    private void OnEnable()
    {
      EventManager.Instance.AddListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.AddListener<OnGiveEvent>(OnGiveEventHandler);
    }

    private void OnDisable()
    {
      EventManager.Instance.RemoveListener<OnTakeEvent>(OnTakeEventHandler);
      EventManager.Instance.RemoveListener<OnGiveEvent>(OnGiveEventHandler);
    }

    #endregion

    #region Events Handlers
    private void OnTakeEventHandler(OnTakeEvent eventDetails)
    {
      inventory.AddItem(eventDetails.item, eventDetails.amount);
    }

    private void OnGiveEventHandler(OnGiveEvent eventDetails)
    {
      inventory.RemoveItem(eventDetails.item, eventDetails.amount);
    }
    #endregion
  }
}